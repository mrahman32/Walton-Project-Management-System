using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office.CustomUI;
using LinqToExcel;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using ProjectManagement.DAL.DbModel;
using ProjectManagement.Infrastructures.Interfaces;
using ProjectManagement.Infrastructures.Repositories;
using ProjectManagement.Models;
using ProjectManagement.ViewModels;
using ProjectManagement.ViewModels.MaterialWastage;
using Remotion.Data.Linq.Clauses;

namespace ProjectManagement.Controllers
{
    public class MaterialWastageController : Controller
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMaterialWastageRepository _materialWastageRepository;

        public MaterialWastageController(CommonRepository commonRepository, MaterialWastageRepository materialWastageRepository)
        {
            _commonRepository = commonRepository;
            _materialWastageRepository = materialWastageRepository;
        }
        // GET: MaterialWastage
        [Authorize(Roles = "WASREPGEN")]
        public ActionResult Index()
        {
            List<MaterialWastageMasterModel> models = _commonRepository.GetMetarialWastageList();
            return View(models);
        }
        [Authorize(Roles = "WASREPGEN")]
        public ActionResult CreateNew()
        {
            ViewBag.ItemTypes = _materialWastageRepository.GetMaterialWastageItemType();
            return View(new WastageFileUpload());
        }
        [HttpPost]
        //[Authorize(Roles = "WHEAD, WAS")]
        public ActionResult CreateNew(WastageFileUpload model)
        {
            try
            {
                ViewBag.ItemTypes = _materialWastageRepository.GetMaterialWastageItemType();
                bool isExist =
                    _materialWastageRepository.GetMaterialWastageReportByMonthAndYear(
                        model.MaterialWastageMaster.MonthNumber, model.MaterialWastageMaster.YearNumber, model.VariantId);

                if (!isExist)
                {
                    var extension = model.HttpPostedFileBase != null
                        ? Path.GetExtension(model.HttpPostedFileBase.FileName)
                        : null;


                    if (model.HttpPostedFileBase != null)
                    {
                        string pathToExcelFile =
                            Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/WastageFiles"),
                                model.HttpPostedFileBase.FileName);
                        model.HttpPostedFileBase.SaveAs(pathToExcelFile);
                        if (extension != null)
                        {
                            var fileExt = extension.Substring(1);
                            //string workSheet = string.Empty;
                            string connectionString = string.Empty;
                            if ((model.HttpPostedFileBase != null) && (model.HttpPostedFileBase.ContentLength > 0) &&
                                fileExt == "xlsx")
                            {
                                using (var pack = new ExcelPackage(model.HttpPostedFileBase.InputStream))
                                {
                                    var currentSheet = pack.Workbook.Worksheets;
                                    var workSheet = currentSheet.First();
                                    var noOfRow = workSheet.Dimension.End.Row;
                                    var noOfColumn = workSheet.Dimension.End.Column;
                                    for (var i = 2; i <= noOfRow; i++)
                                    {
                                        var materialWastageDetail = new MaterialWastageDetail();
                                        materialWastageDetail.ItemCode = workSheet.Cells[i, 1].Text;
                                        materialWastageDetail.ItemName = workSheet.Cells[i, 2].Text;
                                        materialWastageDetail.BOMUnit = workSheet.Cells[i, 3].Text.Contains("-") ? 0 : Convert.ToDouble(Regex.Match(workSheet.Cells[i, 3].Text, @"\d+\.*\d*").Value);
                                        materialWastageDetail.WastagePercentage = Convert.ToDouble(Regex.Match(workSheet.Cells[i, 4].Text, @"\d+\.*\d*").Value);
                                        materialWastageDetail.RecQtyWOWastage = Convert.ToInt32(workSheet.Cells[i, 5].Value);
                                        materialWastageDetail.RecQtyWWastage = Convert.ToInt32(workSheet.Cells[i, 6].Value);
                                        materialWastageDetail.TotalLot = Convert.ToInt32(workSheet.Cells[i, 7].Value);
                                        materialWastageDetail.WastageWOBom = Convert.ToInt32(workSheet.Cells[i, 8].Value);
                                        materialWastageDetail.WastageWBom = Convert.ToInt32(workSheet.Cells[i, 9].Value);
                                        materialWastageDetail.TotalWastage = Convert.ToInt32(workSheet.Cells[i, 10].Value);
                                        materialWastageDetail.AssemMaterialFault = Convert.ToInt32(workSheet.Cells[i, 11].Value);
                                        materialWastageDetail.AssemProcessFault = Convert.ToInt32(workSheet.Cells[i, 12].Value);
                                        materialWastageDetail.RepMaterialFault = Convert.ToInt32(workSheet.Cells[i, 13].Value);
                                        materialWastageDetail.RepProcessFault = Convert.ToInt32(workSheet.Cells[i, 14].Value);
                                        materialWastageDetail.TotalFault = Convert.ToInt32(workSheet.Cells[i, 15].Value);
                                        materialWastageDetail.TotalMaterialFaultApproved = Convert.ToInt32(workSheet.Cells[i, 16].Value);
                                        materialWastageDetail.TotalProcessFaultApproved = Convert.ToInt32(workSheet.Cells[i, 17].Value);
                                        materialWastageDetail.TotalFaultApproved = Convert.ToInt32(workSheet.Cells[i, 18].Value);
                                        materialWastageDetail.TillNowAssemMaterialFault = Convert.ToInt32(workSheet.Cells[i, 19].Value);
                                        materialWastageDetail.TillNowAssemProcessFault = Convert.ToInt32(workSheet.Cells[i, 20].Value);
                                        materialWastageDetail.TillNowRepMaterialFault = Convert.ToInt32(workSheet.Cells[i, 21].Value);
                                        materialWastageDetail.TillNowRepProcessFault = Convert.ToInt32(workSheet.Cells[i, 22].Value);
                                        materialWastageDetail.TillNowTotalFault = Convert.ToInt32(workSheet.Cells[i, 23].Value);
                                        materialWastageDetail.ActualAssemblyWastage_TotalLot = Convert.ToDouble(Regex.Match(workSheet.Cells[i, 24].Text, @"\d+\.*\d*").Value);
                                        materialWastageDetail.ActualRepairWastage_TotalLot = Convert.ToDouble(Regex.Match(workSheet.Cells[i, 25].Text, @"\d+\.*\d*").Value);
                                        materialWastageDetail.ActualWastageOfTotalLot = Convert.ToDouble(Regex.Match(workSheet.Cells[i, 26].Text, @"\d+\.*\d*").Value);
                                        materialWastageDetail.NetAdjustment = Convert.ToDouble(Regex.Match(workSheet.Cells[i, 27].Text, @"\d+\.*\d*").Value);
                                        materialWastageDetail.ImportedQtyWithWastage = Convert.ToInt32(workSheet.Cells[i, 28].Value);
                                        materialWastageDetail.WastageQtyInBOM = Convert.ToInt32(workSheet.Cells[i, 29].Value);
                                        materialWastageDetail.NeedToDeclare = Convert.ToInt32(workSheet.Cells[i, 30].Value);
                                        materialWastageDetail.AlreadySined = Convert.ToInt32(workSheet.Cells[i, 31].Value);
                                        materialWastageDetail.NeedSign = Convert.ToInt32(workSheet.Cells[i, 32].Value);
                                        materialWastageDetail.UnitPrice = Convert.ToDouble(workSheet.Cells[i, 33].Value);
                                        materialWastageDetail.TotalPrice = Convert.ToDouble(workSheet.Cells[i, 34].Value);
                                        materialWastageDetail.CrossCheck = Convert.ToInt32(workSheet.Cells[i, 35].Value);
                                        //materialWastageDetail.FOCTakenDate = Convert.ToDateTime(workSheet.Cells[i, 36].Text);
                                        materialWastageDetail.FOCQty = Convert.ToInt32(workSheet.Cells[i, 36].Value);
                                        materialWastageDetail.Remarks = Convert.ToString(workSheet.Cells[i, 37].Value);
                                        materialWastageDetail.BOMType = Convert.ToString(workSheet.Cells[i, 38].Value);




                                        //general data

                                        model.MaterialWastageDetails.Add(materialWastageDetail);
                                    }
                                }



                            }
                        }
                    }
                    ViewBag.Variants = _commonRepository.GetVariantsWithOrderNumber();
                    if (model.MaterialWastageDetails.Any(i => string.IsNullOrWhiteSpace(i.BOMType)))
                    {
                        TempData["message"] = "There are one or many item found that has no BOM Type. BOM Type is mandatory";
                        TempData["messageType"] = 3;
                        model.MaterialWastageDetails = new List<MaterialWastageDetail>();
                        return View(model);
                    }
                    return View(model);
                }
                TempData["message"] = "A report already exist for this month and year.";
                TempData["messageType"] = 2;
            }
            catch (Exception exception)
            {
                string msg = exception.Message;
                if (exception.InnerException != null && exception.InnerException.InnerException != null)
                {
                    msg = msg + "InnerException: " + exception.InnerException.InnerException.Message;
                }
                TempData["message"] = msg;
                TempData["messageType"] = 2;
            }
            return View(model);
        }

        public JsonResult GetBomItemInformation(string itemCode)
        {
            BomModel boms = _commonRepository.GetBomInfoByItemCode(itemCode).Where(i => i.ItemCost > 0 & i.ItemCost != null).OrderBy(i => i.AddedDate).FirstOrDefault();
            var result = new JsonResult
            {
                Data = boms,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = int.MaxValue
            };
            return result;
        }
        [HttpPost]
        public JsonResult SaveWastage(WastageFileUpload wastageFileUpload)
        {

            ResponseModel responseModel = _commonRepository.SaveMaterialWastage(wastageFileUpload);
            return new JsonResult { Data = responseModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Authorize(Roles = "WASSHEAD, WACCHEAD, WSMTHEAD, WCHAHEAD, WASCOO, WASDCOO, MM, WLENSHEAD")]
        public ActionResult PendingApprovals()
        {
            var user = User;
            List<MaterialWastageMasterModel> models = new List<MaterialWastageMasterModel>();
            if (user.IsInRole("WASSHEAD")
                || user.IsInRole("WACCHEAD")
                || user.IsInRole("WSMTHEAD")
                || user.IsInRole("WCHAHEAD")
                || user.IsInRole("WUSBHEAD")
                || user.IsInRole("WLENSHEAD")
                
                )
            {
                models = _commonRepository.GetPendingApprovals(1, user.Identity.Name);
                models = models.Where(i => i.IsEligble).ToList();
            }
            if (user.IsInRole("WASDCOO"))
            {
                models = _commonRepository.GetPendingApprovals(2, user.Identity.Name);
            }
            if (user.IsInRole("WASCOO"))
            {
                models = _commonRepository.GetPendingApprovals(3, user.Identity.Name);
            }
            if (user.IsInRole("MM"))
            {
                models = _commonRepository.GetPendingApprovals(4, user.Identity.Name);
            }


            if (models == null) models = new List<MaterialWastageMasterModel>();
            return View(models);
        }

        //TODO: THIS METHOD SHOULD UPDATE WITH NEW VIEWMODEL CLASS
        //[Authorize(Roles = "WHEAD, WASCOO, MM")]
        public ActionResult Details(long id)
        {

            if (User.IsInRole("WASSHEAD") || User.IsInRole("WACCHEAD") || User.IsInRole("WSMTHEAD") || User.IsInRole("WCHAHEAD") || User.IsInRole("WASCOO") || User.IsInRole("MM") 
                || User.IsInRole("WASDCOO")
                || User.IsInRole("WLENSHEAD")
                )
            {
                EditMaterialWastageViewModel model = _commonRepository.GetMaterialWastageById(id);
                return View(model);
            }
            return View(new EditMaterialWastageViewModel());
        }
        //[Authorize(Roles = "WHEAD, WASCOO, MM")]
        public JsonResult SaveRecommendation(bool isRecom, bool isApproved, string recomMsg, string approvedMsg, long id)
        {
            var user = User;
            ResponseModel response = null;
            if (User.IsInRole("WASSHEAD") || User.IsInRole("WACCHEAD") || User.IsInRole("WSMTHEAD") || User.IsInRole("WCHAHEAD") || User.IsInRole("WUSBHEAD") || User.IsInRole("WLENSHEAD"))
            {
                response = _commonRepository.RecommendMaterialWastage(id, isRecom, recomMsg, isApproved, approvedMsg, user, 1);
            }
            if (user.IsInRole("WASDCOO"))
            {
                response = _commonRepository.RecommendMaterialWastage(id, isRecom, recomMsg, isApproved, approvedMsg, user, 2);
            }
            if (user.IsInRole("WASCOO"))
            {
                response = _commonRepository.RecommendMaterialWastage(id, isRecom, recomMsg, isApproved, approvedMsg, user, 3);
            }
            if (user.IsInRole("MM"))
            {
                response = _commonRepository.RecommendMaterialWastage(id, isRecom, recomMsg, isApproved, approvedMsg, user, 4);
            }
            return new JsonResult { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetRecommendations(long id)
        {
            List<MaterialWastageRecommendation> recommendations = _commonRepository.GetRecommendationsByMasterId(id);
            var r = RenderViewToString(ControllerContext, "_MaterialWastageRecommendations", recommendations);
            //return Json(PartialView("_MaterialWastageRecommendations", new MaterialWastageRecommendation()));

            return new JsonResult { Data = r, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult GetTopSheet(long id)
        {
            MaterialWastageReportTopSheetViewModel model = _materialWastageRepository.GetMaterailWastageTopSheet(id);
            var r = RenderViewToString(ControllerContext, "_MaterialWastageTopSheet", model);

            return new JsonResult { Data = r, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //TODO: THIS METHOD SHOULD UPDATE WITH NEW VIEWMODEL CLASS
        public ActionResult DownloadMaterialWastageExcel(long id)
        {
            var details = _commonRepository.GetMaterialWastageById(id);
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "Material_Wastage_" + "_" + details.MaterialWastageMaster.MonthName + "_" + details.MaterialWastageMaster.YearNumber + ".xlsx";
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    foreach (var editMaterialDetail in details.EditMaterialDetails)
                    {
                        var sheetName = Regex.Replace(editMaterialDetail.MaterialTypeName.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
                        IXLWorksheet worksheet = workbook.Worksheets.Add(sheetName);
                        worksheet.Columns("A", "Z").AdjustToContents();

                        worksheet.Cell("A1").Style.Font.SetBold().Font.FontSize = 16;
                        worksheet.Cell("A1").Value = "Walton Digi- Tech Industries (Mobile)";
                        worksheet.Range("A1:M1").Merge();


                        worksheet.Cell("A2").Style.Font.SetBold().Font.FontSize = 16;
                        worksheet.Cell("A2").Value = "Cell Phone Manufacturing Unit";
                        worksheet.Range("A2:M2").Merge();

                        worksheet.Cell("A3").Style.Font.SetBold().Font.FontSize = 16;
                        worksheet.Cell("A3").Value = "H#00013, Block- B, Building- 03,(2nd & 3rd Floor)";
                        worksheet.Range("A3:M3").Merge();


                        worksheet.Cell("A4").Style.Font.SetBold().Font.FontSize = 16;
                        worksheet.Cell("A4").Value = "Ward- 02, Boroichuti, Kaliakoir, Gazipur";
                        worksheet.Range("A4:M4").Merge();


                        worksheet.Cell("A5").Style.Font.SetBold().Font.FontSize = 16;
                        worksheet.Cell("A5").Value = editMaterialDetail.MaterialTypeName + " " + details.MaterialWastageMaster.MonthName + " " + details.MaterialWastageMaster.YearNumber;
                        worksheet.Range("A5:M5").Merge();

                        worksheet.Cell(7, 1).Value = "Item Code";
                        worksheet.Cell(7, 1).Style.Font.SetBold();
                        worksheet.Cell(7, 1).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 1).Style.Alignment.WrapText = true;


                        worksheet.Cell(7, 2).Value = "Item Details";
                        worksheet.Cell(7, 2).Style.Font.SetBold();
                        worksheet.Cell(7, 2).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 2).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 3).Value = "BOM Unit";
                        worksheet.Cell(7, 3).Style.Font.SetBold();
                        worksheet.Cell(7, 3).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 3).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 4).Value = "Wastage Percentage";
                        worksheet.Cell(7, 4).Style.Font.SetBold();
                        worksheet.Cell(7, 4).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 4).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 5).Value = "Receive QTY Without Wastage";
                        worksheet.Cell(7, 5).Style.Font.SetBold();
                        worksheet.Cell(7, 5).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 5).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 6).Value = "Receive QTY With Wastage";
                        worksheet.Cell(7, 6).Style.Font.SetBold();
                        worksheet.Cell(7, 6).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 6).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 7).Value = "Total Lot";
                        worksheet.Cell(7, 7).Style.Font.SetBold();
                        worksheet.Cell(7, 7).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 7).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 8).Value = "Wastage Without BOM";
                        worksheet.Cell(7, 8).Style.Font.SetBold();
                        worksheet.Cell(7, 8).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 8).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 9).Value = "Wastage With BOM";
                        worksheet.Cell(7, 9).Style.Font.SetBold();
                        worksheet.Cell(7, 9).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 9).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 10).Value = "Total Wastage (Without+ With)";
                        worksheet.Cell(7, 10).Style.Font.SetBold();
                        worksheet.Cell(7, 10).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 10).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 11).Value = "Assembly Material Fault";
                        worksheet.Cell(7, 11).Style.Font.SetBold();
                        worksheet.Cell(7, 11).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 11).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 12).Value = "Assembly Process Fault";
                        worksheet.Cell(7, 12).Style.Font.SetBold();
                        worksheet.Cell(7, 12).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 12).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 13).Value = "Repair  Material Fault";
                        worksheet.Cell(7, 13).Style.Font.SetBold();
                        worksheet.Cell(7, 13).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 13).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 14).Value = "Repair Process Fault";
                        worksheet.Cell(7, 14).Style.Font.SetBold();
                        worksheet.Cell(7, 14).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 14).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 15).Value = "Total Fault";
                        worksheet.Cell(7, 15).Style.Font.SetBold();
                        worksheet.Cell(7, 15).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 15).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 16).Value = "Till Now Material Fault Approved";
                        worksheet.Cell(7, 16).Style.Font.SetBold();
                        worksheet.Cell(7, 16).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 16).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 17).Value = "Til Now Process Fault Approved";
                        worksheet.Cell(7, 17).Style.Font.SetBold();
                        worksheet.Cell(7, 17).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 17).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 18).Value = "Till Now Total Fault Approved";
                        worksheet.Cell(7, 18).Style.Font.SetBold();
                        worksheet.Cell(7, 18).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 18).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 19).Value = "Till Now Total Actual Wastage Assembly Material Fault";
                        worksheet.Cell(7, 19).Style.Font.SetBold();
                        worksheet.Cell(7, 19).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 19).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 20).Value = "Till Now Total Actual Wastage Assembly Process Fault";
                        worksheet.Cell(7, 20).Style.Font.SetBold();
                        worksheet.Cell(7, 20).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 20).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 21).Value = "Till Now Total Actual Wastage Repair  Material Fault";
                        worksheet.Cell(7, 21).Style.Font.SetBold();
                        worksheet.Cell(7, 21).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 21).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 22).Value = "Till Now Total Actual Wastage Repair Process Fault";
                        worksheet.Cell(7, 22).Style.Font.SetBold();
                        worksheet.Cell(7, 22).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 22).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 23).Value = "Till Now Total Wastage Received";
                        worksheet.Cell(7, 23).Style.Font.SetBold();
                        worksheet.Cell(7, 23).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 23).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 24).Value = "Actual Wastage of Total Assembly Wastage %";
                        worksheet.Cell(7, 24).Style.Font.SetBold();
                        worksheet.Cell(7, 24).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 24).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 25).Value = "Actual Wastage of Total Repair Wastage %";
                        worksheet.Cell(7, 25).Style.Font.SetBold();
                        worksheet.Cell(7, 25).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 25).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 26).Value = "Actual Wastage % Of Total Lot";
                        worksheet.Cell(7, 26).Style.Font.SetBold();
                        worksheet.Cell(7, 26).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 26).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 27).Value = "Net Adjustment (Actual wastage-FOC)/Total lot";
                        worksheet.Cell(7, 27).Style.Font.SetBold();
                        worksheet.Cell(7, 27).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 27).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 28).Value = "Imported QTY with wastage";
                        worksheet.Cell(7, 28).Style.Font.SetBold();
                        worksheet.Cell(7, 28).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 28).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 29).Value = "Wastage in BOM";
                        worksheet.Cell(7, 29).Style.Font.SetBold();
                        worksheet.Cell(7, 29).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 29).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 30).Value = "Need to Declare";
                        worksheet.Cell(7, 30).Style.Font.SetBold();
                        worksheet.Cell(7, 30).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 30).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 31).Value = "Already Signed";
                        worksheet.Cell(7, 31).Style.Font.SetBold();
                        worksheet.Cell(7, 31).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 31).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 32).Value = "Need Sign";
                        worksheet.Cell(7, 32).Style.Font.SetBold();
                        worksheet.Cell(7, 32).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 32).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 33).Value = "Price";
                        worksheet.Cell(7, 33).Style.Font.SetBold();
                        worksheet.Cell(7, 33).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 33).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 34).Value = "Value";
                        worksheet.Cell(7, 34).Style.Font.SetBold();
                        worksheet.Cell(7, 34).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 34).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 35).Value = "Cross Check";
                        worksheet.Cell(7, 35).Style.Font.SetBold();
                        worksheet.Cell(7, 35).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 35).Style.Alignment.WrapText = true;

                        worksheet.Cell(7, 36).Value = "FOC Date";
                        worksheet.Cell(7, 36).Style.Font.SetBold();
                        worksheet.Cell(7, 36).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 36).Style.Alignment.WrapText = true;


                        worksheet.Cell(7, 37).Value = "FOC Qty";
                        worksheet.Cell(7, 37).Style.Font.SetBold();
                        worksheet.Cell(7, 37).Style.Font.FontColor = XLColor.Black;
                        worksheet.Cell(7, 37).Style.Alignment.WrapText = true;


                        for (int index = 1; index <= editMaterialDetail.MaterialWastageDetails.Count; index++)
                        {
                            worksheet.Cell(index + 7, 1).Value = editMaterialDetail.MaterialWastageDetails[index - 1].ItemCode;
                            //worksheet.Column(1).AdjustToContents();

                            worksheet.Cell(index + 7, 2).Value = editMaterialDetail.MaterialWastageDetails[index - 1].ItemName;
                            //worksheet.Column(2).AdjustToContents();

                            worksheet.Cell(index + 7, 3).Value = editMaterialDetail.MaterialWastageDetails[index - 1].BOMUnit;
                            //worksheet.Column(3).AdjustToContents();

                            worksheet.Cell(index + 7, 4).Value = editMaterialDetail.MaterialWastageDetails[index - 1].WastagePercentage;
                            //worksheet.Column(4).AdjustToContents();

                            worksheet.Cell(index + 7, 5).Value = editMaterialDetail.MaterialWastageDetails[index - 1].RecQtyWOWastage;
                            //worksheet.Column(5).AdjustToContents();


                            worksheet.Cell(index + 7, 6).Value = editMaterialDetail.MaterialWastageDetails[index - 1].RecQtyWWastage;
                            //worksheet.Column(6).AdjustToContents();

                            worksheet.Cell(index + 7, 7).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TotalLot;
                            //worksheet.Column(7).AdjustToContents();

                            worksheet.Cell(index + 7, 8).Value = editMaterialDetail.MaterialWastageDetails[index - 1].WastageWOBom;
                            //worksheet.Column(8).AdjustToContents();

                            worksheet.Cell(index + 7, 9).Value = editMaterialDetail.MaterialWastageDetails[index - 1].WastageWBom;
                            //worksheet.Column(9).AdjustToContents();

                            worksheet.Cell(index + 7, 10).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TotalWastage;
                            //worksheet.Column(10).AdjustToContents();

                            worksheet.Cell(index + 7, 11).Value = editMaterialDetail.MaterialWastageDetails[index - 1].AssemMaterialFault;
                            //worksheet.Column(11).AdjustToContents();

                            worksheet.Cell(index + 7, 12).Value = editMaterialDetail.MaterialWastageDetails[index - 1].AssemProcessFault;
                            //worksheet.Column(12).AdjustToContents();

                            worksheet.Cell(index + 7, 13).Value = editMaterialDetail.MaterialWastageDetails[index - 1].RepMaterialFault;
                            //worksheet.Column(13).AdjustToContents();

                            worksheet.Cell(index + 7, 14).Value = editMaterialDetail.MaterialWastageDetails[index - 1].RepProcessFault;
                            //worksheet.Column(14).AdjustToContents();

                            worksheet.Cell(index + 7, 15).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TotalFault;
                            //worksheet.Column(15).AdjustToContents();

                            worksheet.Cell(index + 7, 16).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TotalMaterialFaultApproved;
                            //worksheet.Column(16).AdjustToContents();

                            worksheet.Cell(index + 7, 17).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TotalProcessFaultApproved;
                            //worksheet.Column(17).AdjustToContents();

                            worksheet.Cell(index + 7, 18).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TotalFaultApproved;
                            //worksheet.Column(18).AdjustToContents();

                            worksheet.Cell(index + 7, 19).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TillNowAssemMaterialFault;
                            //worksheet.Column(19).AdjustToContents();

                            worksheet.Cell(index + 7, 20).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TillNowAssemProcessFault;
                            //worksheet.Column(20).AdjustToContents();

                            worksheet.Cell(index + 7, 21).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TillNowRepMaterialFault;
                            //worksheet.Column(21).AdjustToContents();

                            worksheet.Cell(index + 7, 22).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TillNowRepProcessFault;
                            //worksheet.Column(22).AdjustToContents();

                            worksheet.Cell(index + 7, 23).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TillNowTotalFault;
                            //worksheet.Column(23).AdjustToContents();

                            worksheet.Cell(index + 7, 24).Value = editMaterialDetail.MaterialWastageDetails[index - 1].ActualAssemblyWastage_TotalLot;
                            //worksheet.Column(24).AdjustToContents();

                            worksheet.Cell(index + 7, 25).Value = editMaterialDetail.MaterialWastageDetails[index - 1].ActualRepairWastage_TotalLot;
                            //worksheet.Column(25).AdjustToContents();

                            worksheet.Cell(index + 7, 26).Value = editMaterialDetail.MaterialWastageDetails[index - 1].ActualWastageOfTotalLot;
                            //worksheet.Column(26).AdjustToContents();

                            worksheet.Cell(index + 7, 27).Value = editMaterialDetail.MaterialWastageDetails[index - 1].NetAdjustment;
                            //worksheet.Column(27).AdjustToContents();

                            worksheet.Cell(index + 7, 28).Value = editMaterialDetail.MaterialWastageDetails[index - 1].ImportedQtyWithWastage;
                            //worksheet.Column(28).AdjustToContents();

                            worksheet.Cell(index + 7, 29).Value = editMaterialDetail.MaterialWastageDetails[index - 1].WastageQtyInBOM;
                            //worksheet.Column(29).AdjustToContents();

                            worksheet.Cell(index + 7, 30).Value = editMaterialDetail.MaterialWastageDetails[index - 1].NeedToDeclare;
                            //worksheet.Column(30).AdjustToContents();

                            worksheet.Cell(index + 7, 31).Value = editMaterialDetail.MaterialWastageDetails[index - 1].AlreadySined;
                            //worksheet.Column(31).AdjustToContents();

                            worksheet.Cell(index + 7, 32).Value = editMaterialDetail.MaterialWastageDetails[index - 1].NeedSign;
                            //worksheet.Column(32).AdjustToContents();

                            worksheet.Cell(index + 7, 33).Value = editMaterialDetail.MaterialWastageDetails[index - 1].UnitPrice;
                            //worksheet.Column(33).AdjustToContents();

                            worksheet.Cell(index + 7, 34).Value = editMaterialDetail.MaterialWastageDetails[index - 1].TotalPrice;
                            //worksheet.Column(34).AdjustToContents();

                            worksheet.Cell(index + 7, 35).Value = editMaterialDetail.MaterialWastageDetails[index - 1].CrossCheck;
                            //worksheet.Column(35).AdjustToContents();

                            worksheet.Cell(index + 7, 36).Value = editMaterialDetail.MaterialWastageDetails[index - 1].FOCTakenDate;
                            //worksheet.Column(36).AdjustToContents();

                            worksheet.Cell(index + 7, 37).Value = editMaterialDetail.MaterialWastageDetails[index - 1].FOCQty;


                        }

                        //break;
                        
                    }
                    

                   
                    using ( var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);

                        var content = stream.ToArray();
                        //stream.Position = 0;
                        return File(content, contentType, fileName);
                    }
                    
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public static string RenderViewToString(ControllerContext context, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = context.RouteData.GetRequiredString("action");

            var viewData = new ViewDataDictionary(model);

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
                var viewContext = new ViewContext(context, viewResult.View, viewData, new TempDataDictionary(), sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        public JsonResult CompleteReport(long id)
        {
            ResponseModel model = _commonRepository.CompleteReport(id);
            return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(List<MaterialWastageItemModel> models)
        {
            return View();
        }

        public ActionResult EditWastageMaterialReport(long id)
        {
            EditMaterialWastageViewModel model = _commonRepository.GetMaterialWastageById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditWastageMaterialReport(EditMaterialWastageViewModel model)
        {
            if (model.MaterialWastageMaster.Id > 0 && model.MaterialWastageFileUploads.Any())
            {
                if (model.MaterialWastageFileUploads.Any(i => i.HttpPostedFileBase == null))
                {
                    TempData["message"] = "Invalid Submission. Please check.";
                    TempData["messageType"] = 2;
                    return RedirectToAction("EditWastageMaterialReport", new {id = model.MaterialWastageMaster.Id});
                }
                
                var updateResult = _materialWastageRepository.AddNewFileToExistingReport(model);

                TempData["message"] = updateResult.ResponseMessage;
                TempData["messageType"] = updateResult.ResponseCode;
                return RedirectToAction("EditWastageMaterialReport", new { id = model.MaterialWastageMaster.Id });
            }
            TempData["message"] = "Invalid Submission. Please check. Form invalid";
            TempData["messageType"] = 2;
            return RedirectToAction("EditWastageMaterialReport", new { id = model.MaterialWastageMaster.Id });
        }


        public ActionResult NewWastageReport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewWastageReport(MaterialWasterReportCreateModel model)
        {
            try
            {
                long userId = Convert.ToInt64(System.Web.HttpContext.Current.User.Identity.Name == "" ? "0" : System.Web.HttpContext.Current.User.Identity.Name);
                if (userId == 0)
                {
                    //return new ResponseModel { ResponseCode = 2, ResponseMessage = "Your session has ended. Please logout and login again" };
                }
                if (ModelState.IsValid)
                {

                    bool isExist =
                        _materialWastageRepository.GetMaterialWastageReportByMonthAndYear(
                            model.MonthNumber, model.YearNumber, 0);
                    if (!isExist)
                    {
                        var master = new MaterialWastageMaster
                        {
                            AddedBy = userId,
                            AddedDate = DateTime.Now,
                            IsCompleted = false,
                            IsInchargeApproved = false,
                            IsCooApproved = false,
                            IsManagementApproved = false,
                            IsSpecialApproved = false,
                            ReportName = model.ReportName,
                            MonthName =
                                new DateTime(model.YearNumber, model.MonthNumber, 1).ToString("MMMM",
                                    CultureInfo.InvariantCulture),
                            MonthNumber = model.MonthNumber,
                            YearNumber = model.YearNumber,

                        };
                        var details = new List<MaterialWastageDetail>();
                        foreach (var upload in model.MaterialWastageFileUploads)
                        {
                            var extension = upload.HttpPostedFileBase != null
                                ? Path.GetExtension(upload.HttpPostedFileBase.FileName)
                                : null;


                            if (upload.HttpPostedFileBase != null)
                            {
                                string pathToExcelFile =
                                    Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/WastageFiles"),
                                        upload.HttpPostedFileBase.FileName);
                                upload.HttpPostedFileBase.SaveAs(pathToExcelFile);
                                if (extension != null)
                                {
                                    var fileExt = extension.Substring(1);
                                    //string workSheet = string.Empty;
                                    string connectionString = string.Empty;
                                    if ((upload.HttpPostedFileBase != null) && (upload.HttpPostedFileBase.ContentLength > 0) &&
                                        fileExt == "xlsx")
                                    {
                                        using (var pack = new ExcelPackage(upload.HttpPostedFileBase.InputStream))
                                        {
                                            var currentSheet = pack.Workbook.Worksheets;
                                            var workSheet = currentSheet.First();
                                            var noOfRow = workSheet.Dimension.End.Row;
                                            var noOfColumn = workSheet.Dimension.End.Column;
                                            for (var i = 2; i <= noOfRow; i++)
                                            {
                                                var materialWastageDetail = new MaterialWastageDetail();
                                                materialWastageDetail.ItemCode = workSheet.Cells[i, 1].Text;
                                                if ((!string.IsNullOrWhiteSpace(materialWastageDetail.ItemCode)))
                                                {
                                                    materialWastageDetail.ItemName = workSheet.Cells[i, 2].Text;
                                                    materialWastageDetail.BOMUnit = workSheet.Cells[i, 3].Text.Contains("-") ? 0 : Convert.ToDouble(Regex.Match(workSheet.Cells[i, 3].Text, @"\d+\.*\d*").Value);
                                                    materialWastageDetail.WastagePercentage =
                                                        Convert.ToDouble(
                                                            Regex.Match(workSheet.Cells[i, 4].Text, @"\d+\.*\d*").Value);
                                                    materialWastageDetail.RecQtyWOWastage =
                                                        Convert.ToInt32(workSheet.Cells[i, 5].Value);
                                                    materialWastageDetail.RecQtyWWastage =
                                                        Convert.ToInt32(workSheet.Cells[i, 6].Value);
                                                    materialWastageDetail.TotalLot = Convert.ToInt32(workSheet.Cells[i, 7].Value);
                                                    materialWastageDetail.WastageWOBom =
                                                        Convert.ToInt32(workSheet.Cells[i, 8].Value);
                                                    materialWastageDetail.WastageWBom =
                                                        Convert.ToInt32(workSheet.Cells[i, 9].Value);
                                                    materialWastageDetail.TotalWastage =
                                                        Convert.ToInt32(workSheet.Cells[i, 10].Value);
                                                    materialWastageDetail.AssemMaterialFault =
                                                        Convert.ToInt32(workSheet.Cells[i, 11].Value);
                                                    materialWastageDetail.AssemProcessFault =
                                                        Convert.ToInt32(workSheet.Cells[i, 12].Value);
                                                    materialWastageDetail.RepMaterialFault =
                                                        Convert.ToInt32(workSheet.Cells[i, 13].Value);
                                                    materialWastageDetail.RepProcessFault =
                                                        Convert.ToInt32(workSheet.Cells[i, 14].Value);
                                                    materialWastageDetail.TotalFault =
                                                        Convert.ToInt32(workSheet.Cells[i, 15].Value);
                                                    materialWastageDetail.TotalMaterialFaultApproved =
                                                        Convert.ToInt32(workSheet.Cells[i, 16].Value);
                                                    materialWastageDetail.TotalProcessFaultApproved =
                                                        Convert.ToInt32(workSheet.Cells[i, 17].Value);
                                                    materialWastageDetail.TotalFaultApproved =
                                                        Convert.ToInt32(workSheet.Cells[i, 18].Value);
                                                    materialWastageDetail.TillNowAssemMaterialFault =
                                                        Convert.ToInt32(workSheet.Cells[i, 19].Value);
                                                    materialWastageDetail.TillNowAssemProcessFault =
                                                        Convert.ToInt32(workSheet.Cells[i, 20].Value);
                                                    materialWastageDetail.TillNowRepMaterialFault =
                                                        Convert.ToInt32(workSheet.Cells[i, 21].Value);
                                                    materialWastageDetail.TillNowRepProcessFault =
                                                        Convert.ToInt32(workSheet.Cells[i, 22].Value);
                                                    materialWastageDetail.TillNowTotalFault =
                                                        Convert.ToInt32(workSheet.Cells[i, 23].Value);
                                                    materialWastageDetail.ActualAssemblyWastage_TotalLot =
                                                        Convert.ToDouble(
                                                            Regex.Match(workSheet.Cells[i, 24].Text, @"\d+\.*\d*").Value);
                                                    materialWastageDetail.ActualRepairWastage_TotalLot =
                                                        Convert.ToDouble(
                                                            Regex.Match(workSheet.Cells[i, 25].Text, @"\d+\.*\d*").Value);
                                                    materialWastageDetail.ActualWastageOfTotalLot =
                                                        Convert.ToDouble(
                                                            Regex.Match(workSheet.Cells[i, 26].Text, @"\d+\.*\d*").Value);
                                                    materialWastageDetail.NetAdjustment =
                                                        Convert.ToDouble(
                                                            Regex.Match(workSheet.Cells[i, 27].Text, @"\d+\.*\d*").Value);
                                                    materialWastageDetail.ImportedQtyWithWastage =
                                                        Convert.ToInt32(workSheet.Cells[i, 28].Value);
                                                    materialWastageDetail.WastageQtyInBOM =
                                                        Convert.ToInt32(workSheet.Cells[i, 29].Value);
                                                    materialWastageDetail.NeedToDeclare =
                                                        Convert.ToInt32(workSheet.Cells[i, 30].Value);
                                                    materialWastageDetail.AlreadySined =
                                                        Convert.ToInt32(workSheet.Cells[i, 31].Value);
                                                    materialWastageDetail.NeedSign =
                                                        Convert.ToInt32(workSheet.Cells[i, 32].Value);
                                                    materialWastageDetail.UnitPrice =
                                                        Convert.ToDouble(workSheet.Cells[i, 33].Value);
                                                    materialWastageDetail.TotalPrice =
                                                        Convert.ToDouble(workSheet.Cells[i, 34].Value);
                                                    materialWastageDetail.CrossCheck =
                                                        Convert.ToInt32(workSheet.Cells[i, 35].Value);
                                                    //materialWastageDetail.FOCTakenDate = Convert.ToDateTime(workSheet.Cells[i, 36].Text);
                                                    materialWastageDetail.FOCQty = Convert.ToInt32(workSheet.Cells[i, 36].Value);
                                                    materialWastageDetail.Remarks =
                                                        Convert.ToString(workSheet.Cells[i, 37].Value);
                                                    materialWastageDetail.BOMType = upload.MaterialTypeName;
                                                    //Convert.ToString(workSheet.Cells[i, 38].Value);
                                                    materialWastageDetail.BOMTypeId = upload.MaterialTypeId;



                                                    //general data

                                                    details.Add(materialWastageDetail);
                                                }

                                            }
                                        }



                                    }
                                }
                            }

                        }

                        master.MaterialWastageDetails = details;
                        var wastageFileUpload = new WastageFileUpload { MaterialWastageMaster = master };
                        ResponseModel responseModel = _commonRepository.SaveMaterialWastage(wastageFileUpload);
                        TempData["message"] = responseModel.ResponseMessage;
                        TempData["messageType"] = responseModel.ResponseCode;
                        return RedirectToAction("NewWastageReport");
                    }
                    TempData["message"] = "A report already exist for this month and year..";
                    TempData["messageType"] = 2;
                }
                else
                {
                    TempData["message"] = "Invalid Submission. Please check.";
                    TempData["messageType"] = 2;
                }
            }
            catch (Exception e)
            {
                string message = e.Message;
                if (e.InnerException != null && e.InnerException.InnerException != null)
                {
                    message = message + "InnerException: " + e.InnerException.InnerException.Message;
                }
                TempData["message"] = message;
                TempData["messageType"] = 2;
            }
            

            return RedirectToAction("NewWastageReport");
        }

        public ActionResult AddWastageFile()
        {
            MaterialWastageFileUpload model = new MaterialWastageFileUpload
            {
                MaterialWastageItemTypes = _materialWastageRepository.GetMaterialWastageItemType()
            };
            return PartialView("_MaterialWastagePartial", model);
        }

        [HttpGet]
        public ActionResult DeleteMaterialListByTypeId(string ajaxData)
        {
            if (!string.IsNullOrWhiteSpace(ajaxData) && ajaxData.Contains("+"))
            {
                var idLongs = ajaxData.Split('+');
                if (idLongs.Length == 2)
                {
                    string deletionResult =
                        _materialWastageRepository.DeleteBulkMaterialFromExistingReport(
                            reportMasterId: Convert.ToInt64(idLongs[0]), materialTypeId: Convert.ToInt64(idLongs[1]));

                    return new JsonResult
                    {
                        Data = deletionResult,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }
            else
            {
                return new JsonResult { Data = ajaxData + "-- from backend", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        
    }


    public class WastageFileUpload
    {
        public WastageFileUpload()
        {
            MaterialWastageDetails = new List<MaterialWastageDetail>();
        }
        public long VariantId { get; set; }
        public string ProjectName { get; set; }
        public HttpPostedFileBase HttpPostedFileBase { get; set; }
        public MaterialWastageMaster MaterialWastageMaster { get; set; }
        public List<MaterialWastageDetail> MaterialWastageDetails { get; set; }

        public string RecommendationRemarks { get; set; }
        public string ApprovalRemarks { get; set; }

        public double Average1 { get; set; }
        public double Average2 { get; set; }
        public double Average3 { get; set; }
        public double Average4 { get; set; }
    }
}