using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using ProjectManagement.DAL.DbModel;
using ProjectManagement.Infrastructures.Helper;
using ProjectManagement.Infrastructures.Interfaces;
using ProjectManagement.Infrastructures.Repositories;
using ProjectManagement.Models;
using ProjectManagement.Models.ManagementDashboard;
using ProjectManagement.ViewModels.Management;
using ProjectManagement.Models.StausObjects;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjectManagement.Controllers
{
    [Authorize(Roles = "MM,SA,PS,PM,PMHEAD,ASPM,ASPMHEAD,QCHEAD,CEO,AUDHEAD,BIHEAD,CMHEAD")]
    public class ManagementController : Controller
    {
        private readonly IManagementRepository _repository;

        private readonly IHardwareRepository _hwRepository;
        private readonly ICommercialRepository _commercialRepository;
        private readonly ICommonRepository _commonRepository;
        static String _connectionStringCellphone = ConfigurationManager.ConnectionStrings["CellPhoneForExcel"].ConnectionString;
        private readonly CellPhoneProjectEntities _cellPhoneProjectEntities;

        public ManagementController(ManagementRepository repository, CommercialRepository commercialRepository, CommonRepository commonRepository)
        {
            _repository = repository;
            _hwRepository = new HardwareRepository();
            _commercialRepository = commercialRepository;
            _commonRepository = commonRepository;
            String useridentity = System.Web.HttpContext.Current.User.Identity.Name;
            var users = Convert.ToInt64(useridentity == "" ? "0" : useridentity);
            ViewBag.ChinaQcInspectionCount = _commonRepository.GetChinaQcInspectionCount(users);
            _cellPhoneProjectEntities = new CellPhoneProjectEntities();

        }


        public ActionResult CompletedProjecstList()
        {
            var userId = HttpContext.User.Identity.Name;
            long uId;
            long.TryParse(userId, out uId);
            ViewBag.userInfo = _hwRepository.GetUserInfoByUserId(uId);
            List<ProjectMasterWithPoCustomModel> masterModels = _repository.GetCompletedProjectMasterModelList();
            return View(masterModels);
        }

        [Authorize(Roles = "MM,SA,PS,PM,PMHEAD,ASPM,ASPMHEAD,QCHEAD,AUDHEAD,BIHEAD,CEO")]
        public ActionResult Index(string projectName)
        {
            long projectId = 0;
            long userId = Convert.ToInt64(User.Identity.Name);
            ViewBag.UserInfo = _hwRepository.GetUserInfoByUserId(userId);
            var masterModels = _hwRepository.GetAllProjects();
            var items = new List<SelectListItem> { new SelectListItem { Value = "-1", Text = "Top 5 Projects" }, new SelectListItem { Value = "0", Text = "Latest 5 Projects" } };
            items.AddRange(masterModels.Select(masterModel => new SelectListItem
            {
                Value = masterModel.ProjectMasterId.ToString(CultureInfo.InvariantCulture),
                Text = masterModel.ProjectName
            }));
            ViewBag.ProjectMaster = items;
            //List<WorkProgressData> progresses = _repository.ProjectMonthlyWorkprogress(projectId);
            //ViewBag.work = JsonConvert.SerializeObject(progresses);
            var dashBoardCounter = new DashBoardCounter();
            if (User.IsInRole("MM"))
            {
                ViewBag.MmDashboardConter = dashBoardCounter.GetDashBoardCounter("Management", "MM", userId);
            }
            if (User.IsInRole("CEO"))
            {
                ViewBag.MmDashboardConter = dashBoardCounter.GetDashBoardCounter("Management", "CEO", userId);
            }
            if (User.IsInRole("PS"))
            {
                ViewBag.MmDashboardConter = dashBoardCounter.GetDashBoardCounter("Management", "PS", userId);
            }
            if (User.IsInRole("BIHEAD"))
            {
                ViewBag.MmDashboardConter = dashBoardCounter.GetDashBoardCounter("Management", "BIHEAD", userId);
            }
            ViewBag.Project = projectName;
            //---------------------------------------
            //ViewBag.ProjectNames = _commonRepository.GetAllProjectNames();
            //ViewBag.Projects = _commonRepository.GetProjectMasterModels();
            //------Unproduced Quantity----
            var unproducedAverage = new List<SixMonthsUnproducedAverageQtyModel>();
            var smartCounter = 0;
            var totalUnproducedSmart = 0;
            var totalSmartOrderQuantity = 0;
            var featureCounter = 0;
            var totalUnproducedFeature = 0;
            var totalFeatureOrderQuantity = 0;
            var model = _commonRepository.SixMonthsUnproducedAverageQty();
            for (var i = 0; i < model.Count; i++)
            {
                var partsCurrent = model[i].ProjectModel.Split(' ');
                if (partsCurrent[0].ToLower() == "primo" || partsCurrent[0].ToLower() == "orbit")
                {
                    smartCounter = smartCounter + 1;
                    totalUnproducedSmart = totalUnproducedSmart + Convert.ToInt32(model[i].UnProduced);
                    totalSmartOrderQuantity = totalSmartOrderQuantity + Convert.ToInt32(model[i].OrderQuantity);
                }
                if (partsCurrent[0].ToLower() == "olvio" || partsCurrent[0].ToLower() == "axino")
                {
                    featureCounter = featureCounter + 1;
                    totalUnproducedFeature = totalUnproducedFeature + Convert.ToInt32(model[i].UnProduced);
                    totalFeatureOrderQuantity = totalFeatureOrderQuantity + Convert.ToInt32(model[i].OrderQuantity);
                }
            }
            var smartAverage = smartCounter == 0 ? 0 : totalUnproducedSmart / smartCounter;
            var smartPercentage = (totalUnproducedSmart == 0 || totalSmartOrderQuantity==0) ? 0 : ((decimal)totalUnproducedSmart / totalSmartOrderQuantity) * 100;
            var featureAverage = featureCounter == 0 ? 0 : totalUnproducedFeature / featureCounter;
            var featurePercentage = (totalFeatureOrderQuantity==0 || totalUnproducedFeature==0)?0: ((decimal)totalUnproducedFeature / totalFeatureOrderQuantity) * 100;
            unproducedAverage.Add(new SixMonthsUnproducedAverageQtyModel
            {
                ProjectType = "Smart",
                AverageValue = Convert.ToString(smartAverage),
                Percentage = Convert.ToString(Math.Round(smartPercentage))
            });
            unproducedAverage.Add(new SixMonthsUnproducedAverageQtyModel
            {
                ProjectType = "Feature",
                AverageValue = Convert.ToString(featureAverage),
                Percentage = Convert.ToString(Math.Round(featurePercentage))
            });
            ViewBag.Unproduced = unproducedAverage;
            //======================
            //=====SMT capacity exceed log====
            ViewBag.SmtExceedLog = _commonRepository.SmtCapacityExceedLogModels();
            //=============
            return View();
        }

        int IsAnyNullOrEmpty(object myObject)
        {
            var i = 0;
            if (myObject != null)
            {
                foreach (PropertyInfo pi in myObject.GetType().GetProperties())
                {

                    var value = pi.GetValue(myObject);
                    if (value == null)
                    {
                        i++;
                    }

                }
            }
            return i;
        }

        public ActionResult HwAndSwSummaryForManagement(string projectName, long projectMasterId = 0)
        {
            ViewBag.ProjectName = projectName;
            ViewBag.HwFgTests = _repository.GetProjectForHwFinishedTestByProjectName(projectName);
            ViewBag.HwScreeningTests = _repository.GetProjectForHwScreeningTestByProjectName(projectName);
            ViewBag.HwRunningTests = _repository.GetProjectForHwRunningTestByProjectName(projectName);
            ViewBag.SwQcInchargeAssignModels =
                      _repository.GetSwQcInchargeAssignByProjectName(projectName) ?? new List<SwQcInchargeAssignModel>();
            return View();
        }

        public JsonResult MakeAllprojectGanttChart()
        {
            var cmstat = _repository.GetAllCmStatusObject();
            var stat = new List<OverallProjectStatusModel>();
            foreach (var cmStatusObject in cmstat)
            {
                var cmMmPendingActionCount = IsAnyNullOrEmpty(cmStatusObject);
                var hwscrstat = _commonRepository.GetHwScreeningStatusObject(cmStatusObject.ProjectMasterId);
                var hwrunstat = _commonRepository.GetHwRunningStatusObject(cmStatusObject.ProjectMasterId);
                var hwfinstat = _commonRepository.GetHwFinishedStatusObject(cmStatusObject.ProjectMasterId);
                var pmstat = _commonRepository.GetPmStatusObject(cmStatusObject.ProjectMasterId);
                var swqcstat = _commonRepository.GetSwStatusObject(cmStatusObject.ProjectMasterId);

                DateTime? lastactiondate = _repository.GetLastActionDate(cmStatusObject.ProjectMasterId);

                if (cmStatusObject.ApproxProjectFinishDate == null)
                {
                    cmMmPendingActionCount = cmMmPendingActionCount - 1;
                }
                if (cmStatusObject.SourcingType == null)
                {
                    cmMmPendingActionCount = cmMmPendingActionCount - 1;
                }
                if (cmStatusObject.PoClosingDate == null)
                {
                    cmMmPendingActionCount = cmMmPendingActionCount - 1;
                }
                var hwscrPendingActionCount = 0;
                hwscrPendingActionCount = hwscrstat != null ? IsAnyNullOrEmpty(hwscrstat) : 6;
                var hwRunPendingActionCount = 0;
                hwRunPendingActionCount = hwrunstat != null ? IsAnyNullOrEmpty(hwrunstat) : 6;
                var hwfinPendingActionCount = 0;
                hwfinPendingActionCount = hwfinstat != null ? IsAnyNullOrEmpty(hwfinstat) : 6;
                var pmPendingActionCount = 0;
                pmPendingActionCount = pmstat != null ? IsAnyNullOrEmpty(pmstat) : 4;
                var swPendingActionCOunt = 0;
                swPendingActionCOunt = swqcstat != null ? IsAnyNullOrEmpty(swqcstat) : 3;


                if (cmStatusObject.ApproxProjectFinishDate == null || cmStatusObject.ApproxProjectFinishDate < cmStatusObject.ProjectInitialize)
                {
                    cmStatusObject.ApproxProjectFinishDate = Convert.ToDateTime(cmStatusObject.ProjectInitialize).AddDays(1).AddMonths(3).AddDays(-1);
                }
                var overallPendingActionCount = 0;
                if ((cmStatusObject.SourcingType == "OEM" || cmStatusObject.SourcingType == null) && cmStatusObject.OrderNuber == 1)
                {
                    overallPendingActionCount = cmMmPendingActionCount + hwscrPendingActionCount + hwRunPendingActionCount + hwfinPendingActionCount +
                                                    pmPendingActionCount + swPendingActionCOunt;

                    stat.Add(new OverallProjectStatusModel()
                    {
                        ProjectMasterId = cmStatusObject.ProjectMasterId,
                        ProjectName = cmStatusObject.ProjectName + "( Order " + cmStatusObject.OrderNuber + ")",
                        ActionCount = Math.Round(((34 - Convert.ToDouble(overallPendingActionCount)) / 34) * 100, 2),
                        StartDate = cmStatusObject.PurchaseOrder,
                        EndDate = cmStatusObject.ApproxProjectFinishDate,
                        LastActionDate = lastactiondate,
                        PoClosingDate = cmStatusObject.PoClosingDate,
                        IsCompleted = cmStatusObject.IsCompleted 
                    });
                }
                if (cmStatusObject.OrderNuber > 1)
                {
                    overallPendingActionCount = (cmMmPendingActionCount - 2) + hwRunPendingActionCount + hwfinPendingActionCount +
                                                    pmPendingActionCount + swPendingActionCOunt;
                    stat.Add(new OverallProjectStatusModel()
                    {
                        ProjectMasterId = cmStatusObject.ProjectMasterId,
                        ProjectName = cmStatusObject.ProjectName + "( Order " + cmStatusObject.OrderNuber + ")",
                        ActionCount = Math.Round(((26 - Convert.ToDouble(overallPendingActionCount)) / 26) * 100, 2),
                        StartDate = cmStatusObject.ProjectInitialize,
                        EndDate = cmStatusObject.ApproxProjectFinishDate,
                        LastActionDate = lastactiondate,
                        PoClosingDate = cmStatusObject.PoClosingDate,
                        IsCompleted = cmStatusObject.IsCompleted
                    });
                }
                if (cmStatusObject.SourcingType == "ODM" && cmStatusObject.OrderNuber == 1)
                {
                    overallPendingActionCount = (cmMmPendingActionCount - 1) + hwRunPendingActionCount + hwfinPendingActionCount +
                                                     pmPendingActionCount + swPendingActionCOunt;
                    stat.Add(new OverallProjectStatusModel()
                    {
                        ProjectMasterId = cmStatusObject.ProjectMasterId,
                        ProjectName = cmStatusObject.ProjectName + "( Order " + cmStatusObject.OrderNuber + ")",
                        ActionCount = Math.Round(((27 - Convert.ToDouble(overallPendingActionCount)) / 27) * 100, 2),
                        StartDate = cmStatusObject.ProjectInitialize,
                        EndDate = cmStatusObject.ApproxProjectFinishDate,
                        LastActionDate = lastactiondate,
                        PoClosingDate = cmStatusObject.PoClosingDate,
                        IsCompleted = cmStatusObject.IsCompleted
                    });
                }
            }
            //---------------------------------------
            var json = JsonConvert.SerializeObject(stat);
            return new JsonResult { Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult GetDataByModule(long id)
        {
            var combinedstat = new CombinedStatusObject();
            combinedstat.CmStatusObject = _commonRepository.GetCmStatusObject(id);
            combinedstat.PmStatusObject = _commonRepository.GetPmStatusObject(id);
            combinedstat.HwScreeningStatusObject = _commonRepository.GetHwScreeningStatusObject(id);
            combinedstat.HwRunningStatusObject = _commonRepository.GetHwRunningStatusObject(id);
            combinedstat.HwFinishedStatusObject = _commonRepository.GetHwFinishedStatusObject(id);
            combinedstat.SwStatusObject = _commonRepository.GetSwStatusObject(id);
            combinedstat.SwStatusObjects = _commonRepository.GetSwStatusObjects(id);

            string jsonStr = JsonConvert.SerializeObject(combinedstat);
            return new JsonResult { Data = jsonStr, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        

        #region Dashboard Ajax Functions
        [HttpPost]
        public JsonResult GetWorkProgress(long projectId)
        {
            List<WorkProgressData> progresses = _repository.ProjectMonthlyWorkprogress(projectId);
            var json = JsonConvert.SerializeObject(progresses);
            return new JsonResult { Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult GetRecentNofificationAsFeed()
        {
            var feeds = _repository.GetRecentNotifications();
            string jsonData = JsonConvert.SerializeObject(feeds);
            return new JsonResult { Data = jsonData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetProjectWiseRecentNofificationAsFeed(long projectId)
        {
            var feeds = _repository.GetProjectWiseRecentNotifications(projectId);
            string jsonData = JsonConvert.SerializeObject(feeds);
            return new JsonResult { Data = jsonData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetProjectsByIssueCount()
        {
            string issuesJsonString = _repository.GetProjectsCountByIssueOccured();
            return new JsonResult { Data = issuesJsonString, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetProjectsByCommentCount()
        {
            string commentJsonString = _repository.GetProjectsCountByCommentOccured();
            return new JsonResult { Data = commentJsonString, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        public JsonResult GetIssuePieData(string projectName, string status)
        {
            List<PieSlideDataModel> issueModels = _repository.GetIssuesForManagerPieSlide(projectName, status);
            string jsonData = JsonConvert.SerializeObject(issueModels);
            return new JsonResult { Data = jsonData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion


        #region Final Approved
        [Authorize(Roles = "MM,SA,PM,PMHEAD,QCHEAD")]
        [HttpGet]
        public ActionResult RunningProjecstList()
        {

            var userId = HttpContext.User.Identity.Name;
            long uId;
            long.TryParse(userId, out uId);
            ViewBag.userInfo = _hwRepository.GetUserInfoByUserId(uId);
            List<ProjectMasterWithPoCustomModel> masterModels = _repository.GetRunningProjectMasterModelList();
            foreach (var m in masterModels)
            {
                m.OrderQuantity = Convert.ToInt64(m.OrderQuantity);
            }
            return View(masterModels);
        }
        #endregion


        #region SampleSetApproval Page

        [Authorize(Roles = "MM,SA,PS,BIHEAD,CEO,CMHEAD")]
        [HttpGet]
        public ActionResult SampleSetApprovalDecision()
        {

            var userId = HttpContext.User.Identity.Name;
            long uId;
            long.TryParse(userId, out uId);
            ViewBag.userInfo = _hwRepository.GetUserInfoByUserId(uId);
            List<ProjectMasterModel> masterModels = _repository.GetInitialApprovalPendingProjectList();
            if (User.IsInRole("BIHEAD"))
            {
                masterModels = masterModels.Where(x => x.BiApprovalBy == null).ToList();
            }
            if (User.IsInRole("PS"))
            {
                //masterModels = masterModels.Where(x => x.BiApprovalBy != null && x.PsApprovalBy==null).ToList();
                masterModels = new List<ProjectMasterModel>();
            }
            if (User.IsInRole("CEO"))
            {
                masterModels = masterModels.Where(x => x.CeoApprovalBy == null && x.BiApprovalBy != null).ToList();
            }
            if (User.IsInRole("MM"))
            {
                masterModels = masterModels.Where(x => x.CeoApprovalBy != null && x.BiApprovalBy != null && x.InitialApprovalBy==null).ToList();
            }
            ViewBag.InitialApprovedProjects = _commonRepository.GetAllProjects();
            return View(masterModels);
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        [NotificationActionFilter(ReceiverRoles = "HWHEAD,CM,MM,QCHEAD,CMBTRC,QC,HW,PS,CEO")]
        public JsonResult SampleSetRejection(long projectId, String comment)
        {
            try
            {
                String updatedMessage = _repository.SetProjectMaster(projectId, comment);//Reject project
                var notificationObject = new NotificationObject
                {

                    ProjectId = projectId,
                    ToUser = "-1",
                };
                notificationObject.Message = "  rejected sample set for screening test ";
                notificationObject.AdditionalMessage = "";
                ViewBag.ControllerVariable = notificationObject;
                return Json(new { Status = "success" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json(new { Status = "failure" }, JsonRequestBehavior.AllowGet);
            }
        }

        [NotificationActionFilter(ReceiverRoles = "HWHEAD,CM,MM,QCHEAD,CMBTRC,QC,HW,PS,CEO")]
        [HttpPost]
        public JsonResult SampleSetApproval(long projectId, String comment)
        {
            long userId = Convert.ToInt64(User.Identity.Name);
            try
            {
                _repository.SetSampleSetApproval(projectId, comment);//Approve project

                var notificationObject = new NotificationObject
                {

                    ProjectId = projectId,
                    ToUser = "-1",
                };
                notificationObject.Message = "  has approved sample set for screening test ";
                notificationObject.AdditionalMessage = "";
                ViewBag.ControllerVariable = notificationObject;

                return Json(new { Status = "success" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception exception)
            {

                return Json(new { Status = exception.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        #endregion


        #region ProjectAlive
        [Authorize(Roles = "MM,SA")]
        [HttpGet]
        public ActionResult ProjectAlive()
        {

            List<ProjectMasterModel> models = _repository.GetProjectAlive();

            // models = models.Where(x => x.ProjectStatus == "REJECTED").ToList();
            return View(models);
        }
        [HttpPost]
        public JsonResult ProjectAlive(String comment, String concerns)
        {
            if (concerns == "Commercial")
            {
                //Send Project To Commercial
            }
            else if (concerns == "Hardware")
            {
                //Send Project To Screeningtest
            }

            return Json(new { Status = "failure" }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region HwCmProjectFinalApproval
        [Authorize(Roles = "MM,SA")]
        [HttpGet]
        public ActionResult Approval()
        {
            List<HwCmProjectFinalApprovalViewModel> viewModel = _repository.GetHwCmProjectFinalApprovalViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [NotificationActionFilter(ReceiverRoles = "HWHEAD,CM,MM,QCHEAD,CMBTRC,QC,HW,PS")]
        public JsonResult HwCmProjectFinalApproval(string status, string projectId, string comment)
        {
            //{"status":1,"projectId":"1","comment":"SSSSSSSSSS"}

            try
            {
                long pId = 0;
                long.TryParse(projectId, out pId);
                var notificationObject = new NotificationObject
                {

                    ProjectId = pId,
                    ToUser = "-1",
                };
                if (status == "1")
                {
                    _repository.SetHwCmProjectFinalApproval(pId, comment, "APPROVED");

                    notificationObject.Message = "  approved a project from final approval section.";
                    notificationObject.AdditionalMessage = "";
                    ViewBag.ControllerVariable = notificationObject;

                    return Json(new { Status = "success" }, JsonRequestBehavior.AllowGet);

                }
                _repository.SetHwCmProjectFinalApproval(pId, comment, "REJECTED");
                notificationObject.Message = "  rejected a project from final approval section";
                notificationObject.AdditionalMessage = "";
                ViewBag.ControllerVariable = notificationObject;
                return Json(new { Status = "declined" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return Json(new { Status = exception.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        #endregion


        [HttpGet]
        public ActionResult FinalDecision(long id = 0)
        {
            var issues = new VmFinalApproval();
            if (id > 0)
            {
                issues.ProjectMasterId = id;
                issues.HwInchargeIssueModels = _commercialRepository.GetScreeningIssues(id);
                return PartialView(issues);
            }

            return PartialView(new VmFinalApproval());
        }
        [NotificationActionFilter(ReceiverRoles = "HWHEAD,CM,MM,QCHEAD,CMBTRC,QC,HW,PS")]
        [HttpPost]
        public ActionResult FinalDecision(VmFinalApproval model)
        {
            if (ModelState.IsValid)
            {
                long result = _repository.SaveFinalDecision(model);
                var notificationObject = new NotificationObject();
                if (result > 0)
                {
                    notificationObject.ProjectId = model.ProjectMasterId;
                    notificationObject.ToUser = "-1";
                    notificationObject.Message = "  approved a project from final approval section.";
                    notificationObject.AdditionalMessage = "";
                    ViewBag.ControllerVariable = notificationObject;
                    return new JsonResult { Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                notificationObject.ProjectId = model.ProjectMasterId;
                notificationObject.ToUser = "-1";
                notificationObject.Message = "  rejected a project from final approval section";
                notificationObject.AdditionalMessage = "";
                ViewBag.ControllerVariable = notificationObject;
                return new JsonResult { Data = "err", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "err", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public ActionResult MarketPriceCalculator()
        {
            var models = new List<MarketPriceModel>();
            models = _repository.GetMarketPriceModels();
            return View(models);
        }
        [HttpPost]
        public JsonResult SaveMarketPrice(int type, long projectId, decimal price, decimal mul, decimal marketPrice)
        {
            string result = _repository.SaveMarketPrice(type, projectId, price, mul, marketPrice);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetPrice(string pName)
        {
            string result = _repository.GetLockedPrice(pName);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult SparePartsWorkProgress()
        {
            var model = _repository.SpareOrderStatus();
            return View(model);
        }

        public ActionResult ProjectSpec(long id)
        {
            ProjectMasterModel model = _commonRepository.GetProjectInfoByProjectId(id);
            MarketPriceModel marketPriceModel = _commonRepository.GetMarketPriceModelByProjectId(id);
            return View(model);
        }

        public ActionResult GetAllPriceTogether(long projectId)
        {
            List<AccessoriesPricesModel> result = _repository.GetAccessoriesPrices(projectId);
            return View(result);
        }

        public ActionResult ProjectVariantLists()
        {
            var model = _commonRepository.GetOrderQuantityDetailsVms();
            foreach (var m in model)
            {
                var rowSpan = 0;
                //foreach (var v in model)
                //{
                //    if (m.OrderNuber == v.OrderNuber && m.ProjectModel == v.ProjectModel)
                //    {
                //        rowSpan = rowSpan + 1;
                //    }
                //}
                if (m.ProjectModel == "Primo HM5")
                {
                    var a = "hello world";
                }
                rowSpan = model.Count(i => i.OrderNuber == m.OrderNuber && i.ProjectModel == m.ProjectModel);
                m.RowSpan = rowSpan;
            }

            var distinctList = model.Select(i =>  new VarientViewModel
                {
                    ModelName = i.ProjectModel,
                    OrderNo = (int) i.OrderNuber
                }).ToList();


            distinctList = distinctList.DistinctBy(x => new {x.ModelName, x.OrderNo}).ToList();
            ViewBag.DistinctList = distinctList;
            return View(model);
        }

        public ActionResult AddVariant(long projectId = 0)
        {
            var model = _commonRepository.GetOrderQuantityDetailsVmsByProjectId(projectId);
            ViewBag.ProjectId = projectId;
            return View(model);
        }

        public JsonResult GetVariantCalculator(long projectId = 0)
        {
            var model = _commonRepository.GetVariantCalculatorByProjectId(projectId);
            return Json(model);
        }

        public JsonResult SaveVariant(string variantName,bool isLocked, long quantity=0,long variantId=0, long projectId = 0)
        {
            var model = new ProjectVariantCalculatorModel();
            var userId = HttpContext.User.Identity.Name;
            long uId;
            long.TryParse(userId, out uId);
            if (variantId == 0)
            {
                model.ProjectId = projectId;
                model.VariantName = variantName;
                model.Quantity = quantity;
                model.AddedBy = uId;
                model.AddedDate = DateTime.Now;
                model.IsLocked = false;
            }
            else
            {
                model = _commonRepository.GetProjectVariantCalculatorById(variantId);
                model.Quantity = quantity;
                model.UpdatedBy = uId;
                model.UpdatedDate = DateTime.Now;
                model.IsLocked = isLocked;
            }
            var json=_commonRepository.SaveProjectVariantCalculator(model);
            return Json(json);
        }

        public JsonResult RemoveVariantCalculator(long variantId = 0)
        {
            _commonRepository.RemoveVariantCalculator(variantId);
            return Json(true);
        }

        public JsonResult GetPreviousOrderVariants(long projectId = 0)
        {
            return Json(_commonRepository.GetPreviousOrderVariants(projectId));
        }


        #region Repeat order approval
        public ActionResult RepeatOrderApproval()
        {
            List<ProjectPurchaseOrderFormModel> formModels = _commercialRepository.GetUnclosedPoList() ?? new List<ProjectPurchaseOrderFormModel>();
            var model = formModels.Where(x => x.OrderNumber > 1 && x.RepeatOrderApproved == null && x.IsCompleted==false).ToList();
            ViewBag.ApporvedOrders = formModels.Where(x => x.OrderNumber > 1 && x.RepeatOrderApproved == "APPROVED" && x.IsCompleted == false).ToList();
            return View(model);
        }

        public JsonResult ApproveRepeatOrder(long orderId = 0)
        {
            try
            {
                _repository.ApproveRepeatOrder(orderId);
                //===Mail===
                List<ProjectPurchaseOrderFormModel> formModels = _commercialRepository.GetUnclosedPoList() ?? new List<ProjectPurchaseOrderFormModel>();
                var model = formModels.FirstOrDefault(x=>x.ProjectPurchaseOrderFormId==orderId);
                if (model != null)
                {
                    var body =
                        string.Format(
                            @"This is to inform you that, A repeat order has been approved in Walton Project Management System By Management.<br/><br/><b>Project Name: " +
                            model.ProjectName + "</b>");
                    var mail = new MailSendFromPms();
                    mail.SendMail(new List<string>(new[] { "CM" }),
                        new List<string>(new[] { "" }), "Repeat order approved for( " + model.ProjectName + " )", body);
                }
                return Json("APPROVED");
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }
        }

        #endregion

        #region PO Feedback permission

        public ActionResult NegativePoFeedbackDecision()
        {
            var v = _repository.GetNegativeSourcingPoFeedbacks();
            return View(v);
        }

        public JsonResult SaveManagementDecision(string manCom, string manDec, long id = 0)
        {
            var v = _repository.SaveManagementDecision(manCom, manDec, id);
            return Json(v);
        }
        #endregion

        #region bidding

        public ActionResult BiddingApprovalPendingList()
        {

            var vmModel = new VmBidding();
            var fileManager = new FileManager();

            vmModel.CreateBidModels = _repository.GetManagementApprovalPendingBid();
            if (vmModel.CreateBidModels.Any())
            {
                foreach (var model in vmModel.CreateBidModels)
                {
                    if (model.HeadAttachment != null)
                    {
                        var urls = model.HeadAttachment.Split('|').ToList();
                        for (int i = 0; i < urls.Count; i++)
                        {
                            FilesDetail detail1 = new FilesDetail();
                            detail1.FilePath = fileManager.GetFile(urls[i]);
                            detail1.Extention = fileManager.GetExtension(urls[i]);
                            model.FilesDetails1.Add(detail1);
                        }
                    }
                }
            }

            return View(vmModel);
        }
        public ActionResult BiddingDetails(string bidId)
        {
            var vmModel = new VmBidding();
            var fileManager = new FileManager();
            vmModel.CreateBidModels = _repository.GetParticularBid(bidId);
            if (vmModel.CreateBidModels.Any())
            {
                foreach (var model in vmModel.CreateBidModels)
                {
                    if (model.HeadAttachment != null)
                    {
                        var urls = model.HeadAttachment.Split('|').ToList();
                        for (int i = 0; i < urls.Count; i++)
                        {
                            FilesDetail detail1 = new FilesDetail();
                            detail1.FilePath = fileManager.GetFile(urls[i]);
                            detail1.Extention = fileManager.GetExtension(urls[i]);
                            model.FilesDetails1.Add(detail1);
                        }
                    }
                }
            }
           
           // vmModel.Bid_SparePartsDetailsModels1 = _repository.GetBidderListWithBid(bidId);
            vmModel.Bid_SparePartsDetailsModels = _repository.GetBidderListWithBidPrice(bidId);
           // vmModel.Bid_HandsetDetailsModels = _repository.GetDetailsForHandset1(bidId);
            vmModel.Bid_HandsetDetailsModels1 = _repository.GetDetailsForHandsetPersonWise(bidId);
            return View(vmModel);
        }

        public ActionResult BiddingDetailsForPrice(string SpareIds, string statusForBid, string addedId)
        {
            var vmModel = new VmBidding();

            long ids;
            long.TryParse(SpareIds, out ids);

            if (statusForBid == "PerItemList")
            {
                var qq = _cellPhoneProjectEntities.Database.SqlQuery<Bid_CreateBidModel>(@"select Id,BidId from [CellPhoneProject].[dbo].[Bid_SparePartsDetails]
                where Id={0}", ids).FirstOrDefault();
                var bidIds = "";
                if (qq != null)
                {
                    bidIds = Convert.ToString(qq.BidId);
                }
                vmModel.CreateBidModels = _repository.GetParticularBid(bidIds);

                vmModel.Bid_SparePartsDetailsModels1 = _repository.GetHeaderPriceDetailsForPerItems(SpareIds);

            }
            if (statusForBid == "BidderList")
            {
                var qq = _cellPhoneProjectEntities.Database.SqlQuery<Bid_CreateBidModel>(@"select Id,BidId from [CellPhoneProject].[dbo].[Bid_SparePartsDetails]
                where BidId={0}", ids).FirstOrDefault();
                var bidIds = "";
                if (qq != null)
                {
                    bidIds = Convert.ToString(qq.BidId);
                }
                vmModel.CreateBidModels = _repository.GetParticularBid(bidIds);

                vmModel.Bid_SparePartsDetailsModels = _repository.GetBiddersPerItems(SpareIds, addedId);
            }
            if (statusForBid == "PerItemListForHandset")
            {
                var qq = _cellPhoneProjectEntities.Database.SqlQuery<Bid_CreateBidModel>(@"select Id,BidId from [CellPhoneProject].[dbo].[Bid_HandsetDetails]
                where Id={0}", ids).FirstOrDefault();
                var bidIds = "";
                if (qq != null)
                {
                    bidIds = Convert.ToString(qq.BidId);
                }

                vmModel.CreateBidModels = _repository.GetParticularBid(bidIds);

                vmModel.Bid_HandsetDetailsModels = _repository.GetPerItemListForHandset(SpareIds);
            }
            if (statusForBid == "BidderListForHandset")
            {
                var qq = _cellPhoneProjectEntities.Database.SqlQuery<Bid_CreateBidModel>(@"select Id,BidId from [CellPhoneProject].[dbo].[Bid_HandsetDetails]
                where BidId={0}", ids).FirstOrDefault();
                var bidIds = "";
                if (qq != null)
                {
                    bidIds = Convert.ToString(qq.BidId);
                }

                vmModel.CreateBidModels = _repository.GetParticularBid(bidIds);

                vmModel.Bid_HandsetDetailsModels1 = _repository.GetBidderListForHandset(SpareIds, addedId);
            }
            return View(vmModel);
        }

        [HttpPost]
        public JsonResult MngmtApproveSpareBidderDetails(string objArr)
        {
            List<Bid_SparePartsDetailsModel> results = JsonConvert.DeserializeObject<List<Bid_SparePartsDetailsModel>>(objArr);
            Console.Write("result :" + results);

            var saveData = "";

            if (results.Count != 0)
            {
                saveData = _repository.MngmtApproveSpareBidderDetails(results);
            }

            if (saveData == "ok")
            {
                TempData["message"] = "Bid approved Successfully.";
            }
            return Json(new { data = saveData }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region bidding Excel

        public static DataTable GetFirstRow(string bidId, string category, string added)
        {
            String userIdentity = System.Web.HttpContext.Current.User.Identity.Name;
            long userId = Convert.ToInt64(userIdentity == "" ? "0" : userIdentity);
            long addeds = 0;
            long.TryParse(added, out addeds);

            DataTable totalhistry = new DataTable();
            var cn = new SqlConnection(_connectionStringCellphone);

            cn.Open();

            if (category.Trim().Contains("Spare:"))
            {
                totalhistry.Columns.Add("SL.No");
                totalhistry.Columns.Add("Model");
                totalhistry.Columns.Add("ItemName");
                totalhistry.Columns.Add("ItemCode");
                totalhistry.Columns.Add("SalableQty");
                totalhistry.Columns.Add("SQA_Comment");
                totalhistry.Columns.Add("Per_Unit_Price");
                totalhistry.Columns.Add("Bid_Admin_Remarks");
                totalhistry.Columns.Add("Bidder_Bid_Qty");
                totalhistry.Columns.Add("BidderPerUnitPrice");
                totalhistry.Columns.Add("BidderRemarks");
                totalhistry.Columns.Add("ApproveStatus");
                totalhistry.Columns.Add("Lock");

                String sql = "";

                long bidIds = 0;
                long.TryParse(bidId, out bidIds);
                SqlCommand cmd = new SqlCommand();
                if (bidIds != 0)
                {

                    sql = String.Format(@"select * from [CellPhoneProject].[dbo].[Bid_SparePartsDetailsForBidders] where BidId={0} and 
                          IsActive=1 and Added={1}", bidIds, addeds);
                }

                cmd = new SqlCommand(sql, cn);
                int rowCount1 = Convert.ToInt32(cmd.ExecuteScalar());
                if (rowCount1 == 0)
                {
                    sql = String.Format(@"select *,Bidder_Bid_Qty=0,BidderPerUnitPrice=0,BidderRemarks='',ApproveStatus='' from [CellPhoneProject].[dbo].[Bid_SparePartsDetails] where BidId={0}", bidIds);
                }
                cmd = new SqlCommand(sql, cn);
                var ii = 0;
                cmd.CommandTimeout = 6000;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    int salableSum = 0;
                    decimal priceSum = 0;

                    int salableSum2 = 0;
                    decimal priceSum2 = 0;

                    while (rdr.Read())
                    {
                        DataRow newRow = totalhistry.NewRow();

                        newRow["SL.No"] = ii + 1;
                        newRow["Model"] = rdr["Model"].ToString();
                        newRow["ItemName"] = rdr["ItemName"].ToString();
                        newRow["ItemCode"] = rdr["ItemCode"].ToString();
                        newRow["SalableQty"] = rdr["SalableQty"].ToString();
                        newRow["SQA_Comment"] = rdr["SQA_Comment"].ToString();
                        newRow["Per_Unit_Price"] = rdr["Per_Unit_Price"].ToString();
                        newRow["Bid_Admin_Remarks"] = rdr["Admin_Remarks"].ToString();
                        newRow["Bidder_Bid_Qty"] = rdr["Bidder_Bid_Qty"].ToString();
                        newRow["BidderPerUnitPrice"] = rdr["BidderPerUnitPrice"].ToString();
                        newRow["BidderRemarks"] = rdr["BidderRemarks"].ToString();
                        newRow["ApproveStatus"] = rdr["ApproveStatus"].ToString();
                        newRow["Lock"] = rdr["Lock"].ToString();

                        var sll = newRow["SalableQty"].ToString();
                        if (sll == "")
                        {
                            sll = "0";
                        }
                        salableSum += Convert.ToInt32(sll);

                        var prc = newRow["Per_Unit_Price"].ToString();
                        if (prc == "")
                        {
                            prc = "0";
                        }
                        priceSum += Convert.ToDecimal(prc);

                        var sll2 = newRow["Bidder_Bid_Qty"].ToString();
                        if (sll2 == "")
                        {
                            sll2 = "0";
                        }
                        salableSum2 += Convert.ToInt32(sll2);

                        var prc2 = newRow["BidderPerUnitPrice"].ToString();
                        if (prc2 == "")
                        {
                            prc2 = "0";
                        }
                        priceSum2 += Convert.ToDecimal(prc2);

                        totalhistry.Rows.Add(newRow);
                        ii++;
                    }
                    DataRow newRow1 = totalhistry.NewRow();

                    newRow1["SL.No"] = "";
                    newRow1["Model"] = "";
                    newRow1["ItemName"] = "";
                    newRow1["ItemCode"] = "";
                    newRow1["SalableQty"] = "Total: " + salableSum;
                    newRow1["SQA_Comment"] = "";
                    newRow1["Per_Unit_Price"] = "Total: " + priceSum;
                    newRow1["Bid_Admin_Remarks"] = "";
                    newRow1["Bidder_Bid_Qty"] = "Total: " + salableSum2;
                    newRow1["BidderPerUnitPrice"] = "Total: " + priceSum2;
                    newRow1["BidderRemarks"] = "";
                    newRow1["ApproveStatus"] = "";

                    newRow1["Lock"] = "";

                    totalhistry.Rows.Add(newRow1);
                }

            }//end if
            else if (category.Trim().Contains("Handset:"))
            {

                totalhistry.Columns.Add("SL.No");
                totalhistry.Columns.Add("Model");
                totalhistry.Columns.Add("ItemCode");
                totalhistry.Columns.Add("Color");
                totalhistry.Columns.Add("IMEI1");
                totalhistry.Columns.Add("IMEI2");
                totalhistry.Columns.Add("Qty");
                totalhistry.Columns.Add("QC_Functional");
                totalhistry.Columns.Add("QC_Aesthetical");
                totalhistry.Columns.Add("Per_Unit_Price");
                totalhistry.Columns.Add("Bid_Admin_Remarks");
                totalhistry.Columns.Add("Bidder_Bid_Qty");
                totalhistry.Columns.Add("BidderPerUnitPrice");
                totalhistry.Columns.Add("BidderRemarks");
                totalhistry.Columns.Add("ApproveStatus");
                totalhistry.Columns.Add("Lock");

                String sql = "";

                long bidIds = 0;
                long.TryParse(bidId, out bidIds);
                SqlCommand cmd = new SqlCommand();
                if (bidIds != 0)
                {
                    sql = String.Format(@"select * from [CellPhoneProject].[dbo].[Bid_HandsetDetailsForBidders] where BidId={0} and 
                          IsActive=1 and Added={1}", bidIds, addeds);
                }

                cmd = new SqlCommand(sql, cn);
                int rowCount1 = Convert.ToInt32(cmd.ExecuteScalar());
                if (rowCount1 == 0)
                {
                    sql = String.Format(@"select *,Bidder_Bid_Qty=0,BidderPerUnitPrice=0,BidderRemarks='',ApproveStatus='' from [CellPhoneProject].[dbo].[Bid_HandsetDetails] where BidId={0}", bidIds);
                }
                cmd = new SqlCommand(sql, cn);
                var ii = 0;
                cmd.CommandTimeout = 6000;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    int salableSum = 0;
                    decimal priceSum = 0;

                    int salableSum2 = 0;
                    decimal priceSum2 = 0;

                    while (rdr.Read())
                    {
                        DataRow newRow = totalhistry.NewRow();

                        newRow["SL.No"] = ii + 1;
                        newRow["Model"] = rdr["Model"].ToString();
                        newRow["ItemCode"] = rdr["ItemCode"].ToString();
                        newRow["Color"] = rdr["Color"].ToString();
                        newRow["IMEI1"] = rdr["IMEI1"].ToString();
                        newRow["IMEI2"] = rdr["IMEI2"].ToString();
                        newRow["Qty"] = rdr["Qty"].ToString();
                        newRow["QC_Functional"] = rdr["QC_Functional"].ToString();
                        newRow["QC_Aesthetical"] = rdr["QC_Aesthetical"].ToString();
                        newRow["Per_Unit_Price"] = rdr["Per_Unit_Price"].ToString();
                        newRow["Bid_Admin_Remarks"] = rdr["Admin_Remarks"].ToString();
                        newRow["Bidder_Bid_Qty"] = rdr["Bidder_Bid_Qty"].ToString();
                        newRow["BidderPerUnitPrice"] = rdr["BidderPerUnitPrice"].ToString();
                        newRow["BidderRemarks"] = rdr["BidderRemarks"].ToString();
                        newRow["ApproveStatus"] = rdr["ApproveStatus"].ToString();
                        newRow["Lock"] = rdr["Lock"].ToString();

                        var sll = newRow["Qty"].ToString();
                        if (sll == "")
                        {
                            sll = "0";
                        }
                        salableSum += Convert.ToInt32(sll);

                        var prc = newRow["Per_Unit_Price"].ToString();
                        if (prc == "")
                        {
                            prc = "0";
                        }
                        priceSum += Convert.ToDecimal(prc);
                        //
                        var sll2 = newRow["Bidder_Bid_Qty"].ToString();
                        if (sll2 == "")
                        {
                            sll2 = "0";
                        }
                        salableSum2 += Convert.ToInt32(sll2);

                        var prc2 = newRow["BidderPerUnitPrice"].ToString();
                        if (prc2 == "")
                        {
                            prc2 = "0";
                        }
                        priceSum2 += Convert.ToDecimal(prc2);

                        totalhistry.Rows.Add(newRow);
                        ii++;
                    }
                    DataRow newRow1 = totalhistry.NewRow();

                    newRow1["SL.No"] = "";
                    newRow1["Model"] = "";
                    newRow1["ItemCode"] = "";
                    newRow1["Color"] = "";
                    newRow1["IMEI1"] = "";
                    newRow1["IMEI2"] = "";
                    newRow1["IMEI2"] = "";
                    newRow1["Qty"] = "Total: " + salableSum;
                    newRow1["QC_Functional"] = "";
                    newRow1["QC_Aesthetical"] = "";
                    newRow1["Per_Unit_Price"] = "Total: " + priceSum;
                    newRow1["Bid_Admin_Remarks"] = "";
                    newRow1["Bidder_Bid_Qty"] = "Total: " + salableSum2;
                    newRow1["BidderPerUnitPrice"] = "Total: " + priceSum2;
                    newRow1["BidderRemarks"] = "";
                    newRow1["ApproveStatus"] = "";
                    newRow1["Lock"] = "";

                    totalhistry.Rows.Add(newRow1);
                }

            }//end else
            return totalhistry;
        }
        public void GetExcel(DataTable ds, string bidId, string category, string added)
        {
            var vms = new VmBidding();
            //Creae an Excel application instance
            Excel.Application excelApp = new Excel.Application();

            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add("");

            //Add a new worksheet to workbook with the Datatable name
            Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();

            excelWorkSheet.Name = "Sheet";
            //Excel design//

            //Adjust all row
            excelWorkSheet.Rows.AutoFit();

            //Column width and Hight//
            excelWorkSheet.Range["A1", "P1"].Rows.RowHeight = 40;


            if (category.Trim().Contains("Spare:"))
            {
                excelWorkSheet.Columns[1].ColumnWidth = 8;
                excelWorkSheet.Columns[2].ColumnWidth = 30;
                excelWorkSheet.Columns[3].ColumnWidth = 40;
                excelWorkSheet.Columns[4].ColumnWidth = 30;
                excelWorkSheet.Columns[5].ColumnWidth = 15;
                excelWorkSheet.Columns[6].ColumnWidth = 30;
                excelWorkSheet.Columns[7].ColumnWidth = 15;
                excelWorkSheet.Columns[8].ColumnWidth = 30;
                excelWorkSheet.Columns[9].ColumnWidth = 10;
                excelWorkSheet.Columns[10].ColumnWidth = 15;
                excelWorkSheet.Columns[11].ColumnWidth = 15;
                excelWorkSheet.Columns[12].ColumnWidth = 30;
                excelWorkSheet.Columns[13].ColumnWidth = 15;
                excelWorkSheet.Columns[14].ColumnWidth = 10;
                //wrap text//
                excelWorkSheet.get_Range("A1", "P1").Style.WrapText = true;

                //Adjust all column
                excelWorkSheet.Columns.AutoFit();

                //For Issue List Color Group 1//
                excelWorkSheet.get_Range("A1", "P1").Font.Bold = true;
                excelWorkSheet.get_Range("A1", "P1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                excelWorkSheet.get_Range("A1", "P1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;
                excelWorkSheet.get_Range("A1", "P1").Application.StandardFont = "Calibri";
                excelWorkSheet.get_Range("A1", "P1").Application.StandardFontSize = 11;
                //end Issue List Color Group 1


                DataTable dt = new DataTable();
                using (dt = GetFirstRow(bidId, category, added))
                {
                    for (int i = 1; i < dt.Columns.Count + 1; i++)
                    {
                        excelWorkSheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                        //excelWorkSheet.Cells[2, i] = dt.Columns[i - 1].ColumnName;
                    }

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            excelWorkSheet.Cells[j + 2, k + 1] = dt.Rows[j].ItemArray[k].ToString();
                            // excelWorkSheet.Cells[j + 3, k + 1] = dt.Rows[j].ItemArray[k].ToString();

                        }
                    }
                }

            }
            else if (category.Trim().Contains("Handset:"))
            {
                excelWorkSheet.Columns[1].ColumnWidth = 8;
                excelWorkSheet.Columns[2].ColumnWidth = 20;
                excelWorkSheet.Columns[3].ColumnWidth = 20;
                excelWorkSheet.Columns[4].ColumnWidth = 15;
                excelWorkSheet.Columns[5].ColumnWidth = 15;
                excelWorkSheet.Columns[6].ColumnWidth = 15;
                excelWorkSheet.Columns[7].ColumnWidth = 15;
                excelWorkSheet.Columns[8].ColumnWidth = 30;
                excelWorkSheet.Columns[9].ColumnWidth = 30;
                excelWorkSheet.Columns[10].ColumnWidth = 15;
                excelWorkSheet.Columns[11].ColumnWidth = 30;
                excelWorkSheet.Columns[12].ColumnWidth = 10;
                excelWorkSheet.Columns[13].ColumnWidth = 20;
                excelWorkSheet.Columns[14].ColumnWidth = 30;
                excelWorkSheet.Columns[15].ColumnWidth = 15;
                excelWorkSheet.Columns[16].ColumnWidth = 10;
                //wrap text//
                excelWorkSheet.get_Range("A1", "P1").Style.WrapText = true;

                //Adjust all column
                excelWorkSheet.Columns.AutoFit();

                //For Issue List Color Group 1//
                excelWorkSheet.get_Range("A1", "P1").Font.Bold = true;
                excelWorkSheet.get_Range("A1", "P1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                excelWorkSheet.get_Range("A1", "P1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;
                excelWorkSheet.get_Range("A1", "P1").Application.StandardFont = "Calibri";
                excelWorkSheet.get_Range("A1", "P1").Application.StandardFontSize = 11;
                //end Issue List Color Group 1


                DataTable dt = new DataTable();
                using (dt = GetFirstRow(bidId, category, added))
                {
                    for (int i = 1; i < dt.Columns.Count + 1; i++)
                    {
                        excelWorkSheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                        //excelWorkSheet.Cells[2, i] = dt.Columns[i - 1].ColumnName;
                    }

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            excelWorkSheet.Cells[j + 2, k + 1] = dt.Rows[j].ItemArray[k].ToString();
                            // excelWorkSheet.Cells[j + 3, k + 1] = dt.Rows[j].ItemArray[k].ToString();

                        }
                    }
                }

            }


            string dd = bidId + "_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".xlsx";
            string files2 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            excelWorkBook.SaveAs(files2 + "\\" + dd);
            excelWorkBook.Close();
            excelApp.Quit();

            try
            {
                string XlsPath = files2 + "\\" + dd;
                FileInfo fileDet = new System.IO.FileInfo(XlsPath);
                Response.Clear();
                Response.Charset = "UTF-8";
                Response.ContentEncoding = Encoding.UTF8;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(fileDet.Name));
                Response.AddHeader("Content-Length", fileDet.Length.ToString());
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(fileDet.FullName);
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public ActionResult LocationTrackReport()
        {
            //ViewBag.LocationTrackerEmployee = _repository.GetAllLocationTrackerEmployee();
            return View();
        }

        public ActionResult GetAllLocationTrackerEmployee(string network)
        {
            var data = _repository.GetAllLocationTrackerEmployee(network);

            var returnObj = new
            {
                Data = data,
            };
            return new JsonResult()
            {
                Data = returnObj,
                MaxJsonLength = 86753090,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        public ActionResult GetAllLocationTrackReport(string network, string fromDate, string todate, string ddlPhn)
        {
            var data = _repository.GetAllLocationTrackReport(network, fromDate, todate, ddlPhn);

            var returnObj = new
            {
                Data = data,
            };
            return new JsonResult()
            {
                Data = returnObj,
                MaxJsonLength = 86753090,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }



    }
}