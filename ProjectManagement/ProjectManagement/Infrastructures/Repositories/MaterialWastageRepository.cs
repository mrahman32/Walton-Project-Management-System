using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Bibliography;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using ProjectManagement.DAL.DbModel;
using ProjectManagement.Infrastructures.Interfaces;
using ProjectManagement.Models;
using ProjectManagement.ViewModels;
using ProjectManagement.ViewModels.MaterialWastage;

namespace ProjectManagement.Infrastructures.Repositories
{
    public class MaterialWastageRepository : IMaterialWastageRepository
    {
        private readonly CellPhoneProjectEntities _dbEntities;

        public MaterialWastageRepository()
        {
            _dbEntities = new CellPhoneProjectEntities();
            _dbEntities.Configuration.LazyLoadingEnabled = false;
        }
        public bool GetMaterialWastageReportByMonthAndYear(int monthNumber, int yearNumber, long itemTypeId)
        {
            //var isExist = _dbEntities.MaterialWastageMasters
            //    .Join(_dbEntities.MaterialWastageDetails, ms => ms.Id, md => md.MaterialWastageMasterId, (ms, md) => new { MaterialWastageMaster = ms, MaterialWastageDetail = ms })
            //    .Where(i => i.MaterialWastageMaster.Id == i.MaterialWastageDetail.ProjectOrderQuantityDetailsId && i.MaterialWastageMaster.MonthNumber == monthNumber
            //        && i.MaterialWastageMaster.YearNumber == yearNumber && i.MaterialWastageDetail.BOMTypeId == itemTypeId).ToList();


            var isExist = (from master in _dbEntities.MaterialWastageMasters
                           join detail in _dbEntities.MaterialWastageDetails on master.Id equals detail.MaterialWastageMasterId

                           where
                               master.MonthNumber == monthNumber && master.YearNumber == yearNumber
                           select new { master, detail }).ToList();

            return isExist.Any();

        }

        public MaterialWastageReportTopSheetViewModel GetMaterailWastageTopSheet(long id)
        {
            var materialMaster = _dbEntities.MaterialWastageMasters.FirstOrDefault(i => i.Id == id);
            if (materialMaster == null)
            {
                return null;
            }
            var model = new MaterialWastageReportTopSheetViewModel
            {
                CompanyName = "Walton Digi- Tech Industries (Mobile)",
                UnitName = "Cell Phone Manufacturing Unit",
                Address = "H#00013, Block- B, Building- 03, (2nd & 3rd Floor)",
                Adderes2 = "Ward- 02, Boroichuti, Kaliakoir, Gazipur",
                MonthName = "Summary of " + materialMaster.MonthName + " " + materialMaster.YearNumber + " Wastage Value (Project Wise)"
            };
            List<WastageParticular> particulars = (from materialWastageDetail in _dbEntities.MaterialWastageDetails
                                                   where materialWastageDetail.MaterialWastageMasterId == id && (materialWastageDetail.IsDeleted == false || materialWastageDetail.IsDeleted == null)
                                                   group materialWastageDetail by materialWastageDetail.BOMType into g
                                                   select new WastageParticular
                                                   {
                                                       Particular = g.Key,
                                                       PriceValue = g.Sum(i => i.TotalPrice)
                                                   }).ToList();
            model.Particulars = particulars;

            foreach (var wastageParticular in model.Particulars)
            {
                wastageParticular.CommaSeparatedPriceValue = Convert.ToDecimal(wastageParticular.PriceValue).ToString("#,##0.00");
            }

            WastageParticular particular = new WastageParticular
            {
                Particular = "Total",
                PriceValue =  particulars.Sum(i => i.PriceValue),
                
                
            };
            particular.CommaSeparatedPriceValue = Convert.ToDecimal(particular.PriceValue).ToString("#,##0.00");
            model.Particulars.Add(particular);
            var recommendations = _dbEntities.MaterialWastageRecommendations.Where(i => i.MaterialWastageMasterId == id && i.RecommendationType == "APPROVED").ToList();


            model.CreatorList = (from master in _dbEntities.MaterialWastageMasters
                                 join user in _dbEntities.CmnUsers on master.AddedBy equals user.CmnUserId
                                 where master.Id == id
                                 select user.UserFullName).ToList();
            model.InChargeList = recommendations.Where(i => i.UserType == "INCHARGE").Select(i => i.RecommendedBy).Distinct().ToList();
            model.CooList = recommendations.Where(i => i.UserType == "COO").Select(i => i.RecommendedBy).Distinct().ToList();
            model.ApprovalList = recommendations.Where(i => i.UserType == "MANAGEMENT").Select(i => i.RecommendedBy).Distinct().ToList();
            //model.ApprovalList = recommendations.Where(i => i.UserType == "MANAGEMENT").Select(i => i.RecommendedBy)..ToList();
            model.DeputyCooList = recommendations.Where(i => i.UserType == "DCOO").Select(i => i.RecommendedBy).Distinct().ToList();
            return model;
        }

        public List<MaterialWastageItemType> GetMaterialWastageItemType()
        {
            List<MaterialWastageItemType> types = new List<MaterialWastageItemType>
            {
                new MaterialWastageItemType {Id = 0, ItemType = "--Select--"}
            };
            types.AddRange(_dbEntities.MaterialWastageItemTypes.ToList());
            return types;
        }

        public string DeleteBulkMaterialFromExistingReport(long reportMasterId, long materialTypeId)
        {
            try
            {
                var user = Convert.ToInt64(HttpContext.Current.User.Identity.Name);
                var details =
                _dbEntities.MaterialWastageDetails.Where(
                    i => i.MaterialWastageMasterId == reportMasterId && i.BOMTypeId == materialTypeId).ToList();
                foreach (var detail in details)
                {
                    detail.IsDeleted = true;
                    detail.UpdatedBy = user;
                    detail.UpdatedDate = DateTime.Now;
                    _dbEntities.Entry(detail).State = EntityState.Modified;
                }
                var items =
                    _dbEntities.MaterialWastageItems.Where(
                        i => i.MaterialWastageMasterId == reportMasterId && i.BOMTypeId == materialTypeId).ToList();

                foreach (var item in items)
                {
                    item.IsDeleted = true;
                    item.UpdatedBy = user;
                    item.UpdatedDate = DateTime.Now;
                    _dbEntities.Entry(item).State = EntityState.Modified;
                }
                if (!details.Any() && !items.Any()) return "no data found";
              

                _dbEntities.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                var exMsg = e.Message;
                if (e.InnerException != null && e.InnerException.InnerException != null)
                {
                    exMsg = exMsg + "--" + e.InnerException.InnerException.Message;
                }
                return exMsg;
            }
        }

        public ResponseModel AddNewFileToExistingReport(EditMaterialWastageViewModel model)
        {
            var userId = Convert.ToInt64(HttpContext.Current.User.Identity.Name);
            List<long> materialTypeIds = model.MaterialWastageFileUploads.Select(i => i.MaterialTypeId).ToList();
            List<long?> typeIdFromDb =
                _dbEntities.MaterialWastageDetails.Where(
                    i => i.MaterialWastageMasterId == model.MaterialWastageMaster.Id
                    && (i.IsDeleted == null || i.IsDeleted == false)).Select(i => i.BOMTypeId).ToList();

            if (materialTypeIds.Any(typeId => typeIdFromDb.Any(i => i == typeId)))
            {
                return new ResponseModel{ResponseMessage = "Some of material type is already exist.",ResponseCode = 2};
            }
            
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

                                    if (!string.IsNullOrWhiteSpace(materialWastageDetail.ItemCode))
                                    {
                                        materialWastageDetail.ItemName = workSheet.Cells[i, 2].Text;
                                        materialWastageDetail.BOMUnit = workSheet.Cells[i, 3].Text.Contains("-") ? 0 : Convert.ToDouble(Regex.Match(workSheet.Cells[i, 3].Text, @"\d+\.*\d*").Value );
                                        materialWastageDetail.WastagePercentage = Convert.ToDouble(Regex.Match(workSheet.Cells[i, 4].Text, @"\d+\.*\d*").Value);
                                        materialWastageDetail.RecQtyWOWastage =Convert.ToInt32(workSheet.Cells[i, 5].Value);
                                        materialWastageDetail.RecQtyWWastage =Convert.ToInt32(workSheet.Cells[i, 6].Value);
                                        materialWastageDetail.TotalLot = Convert.ToInt32(workSheet.Cells[i, 7].Value);
                                        materialWastageDetail.WastageWOBom =Convert.ToInt32(workSheet.Cells[i, 8].Value);
                                        materialWastageDetail.WastageWBom =Convert.ToInt32(workSheet.Cells[i, 9].Value);
                                        materialWastageDetail.TotalWastage =Convert.ToInt32(workSheet.Cells[i, 10].Value);
                                        materialWastageDetail.AssemMaterialFault =Convert.ToInt32(workSheet.Cells[i, 11].Value);
                                        materialWastageDetail.AssemProcessFault =Convert.ToInt32(workSheet.Cells[i, 12].Value);
                                        materialWastageDetail.RepMaterialFault =Convert.ToInt32(workSheet.Cells[i, 13].Value);
                                        materialWastageDetail.RepProcessFault =Convert.ToInt32(workSheet.Cells[i, 14].Value);
                                        materialWastageDetail.TotalFault =Convert.ToInt32(workSheet.Cells[i, 15].Value);
                                        materialWastageDetail.TotalMaterialFaultApproved =Convert.ToInt32(workSheet.Cells[i, 16].Value);
                                        materialWastageDetail.TotalProcessFaultApproved =Convert.ToInt32(workSheet.Cells[i, 17].Value);
                                        materialWastageDetail.TotalFaultApproved =Convert.ToInt32(workSheet.Cells[i, 18].Value);
                                        materialWastageDetail.TillNowAssemMaterialFault =Convert.ToInt32(workSheet.Cells[i, 19].Value);
                                        materialWastageDetail.TillNowAssemProcessFault =Convert.ToInt32(workSheet.Cells[i, 20].Value);
                                        materialWastageDetail.TillNowRepMaterialFault =Convert.ToInt32(workSheet.Cells[i, 21].Value);
                                        materialWastageDetail.TillNowRepProcessFault =Convert.ToInt32(workSheet.Cells[i, 22].Value);
                                        materialWastageDetail.TillNowTotalFault =Convert.ToInt32(workSheet.Cells[i, 23].Value);
                                        materialWastageDetail.ActualAssemblyWastage_TotalLot =Convert.ToDouble(Regex.Match(workSheet.Cells[i, 24].Text, @"\d+\.*\d*").Value);
                                        materialWastageDetail.ActualRepairWastage_TotalLot =Convert.ToDouble(Regex.Match(workSheet.Cells[i, 25].Text, @"\d+\.*\d*").Value);
                                        materialWastageDetail.ActualWastageOfTotalLot =Convert.ToDouble(Regex.Match(workSheet.Cells[i, 26].Text, @"\d+\.*\d*").Value);
                                        materialWastageDetail.NetAdjustment =Convert.ToDouble(Regex.Match(workSheet.Cells[i, 27].Text, @"\d+\.*\d*").Value);
                                        materialWastageDetail.ImportedQtyWithWastage =Convert.ToInt32(workSheet.Cells[i, 28].Value);
                                        materialWastageDetail.WastageQtyInBOM =Convert.ToInt32(workSheet.Cells[i, 29].Value);
                                        materialWastageDetail.NeedToDeclare =Convert.ToInt32(workSheet.Cells[i, 30].Value);
                                        materialWastageDetail.AlreadySined =Convert.ToInt32(workSheet.Cells[i, 31].Value);
                                        materialWastageDetail.NeedSign =Convert.ToInt32(workSheet.Cells[i, 32].Value);
                                        materialWastageDetail.UnitPrice =Convert.ToDouble(workSheet.Cells[i, 33].Value);
                                        materialWastageDetail.TotalPrice =Convert.ToDouble(workSheet.Cells[i, 34].Value);
                                        materialWastageDetail.CrossCheck =Convert.ToInt32(workSheet.Cells[i, 35].Value);
                                        //materialWastageDetail.FOCTakenDate = Convert.ToDateTime(workSheet.Cells[i, 36].Text);
                                        materialWastageDetail.FOCQty = Convert.ToInt32(workSheet.Cells[i, 36].Value);
                                        materialWastageDetail.Remarks =Convert.ToString(workSheet.Cells[i, 37].Value);
                                        materialWastageDetail.BOMType = upload.MaterialTypeName;
                                        //Convert.ToString(workSheet.Cells[i, 38].Value);
                                        materialWastageDetail.BOMTypeId = upload.MaterialTypeId;

                                        materialWastageDetail.AddedBy = userId;
                                        materialWastageDetail.AddedDate = DateTime.Now;
                                        materialWastageDetail.MaterialWastageMasterId = model.MaterialWastageMaster.Id;

                                        //general data

                                        details.Add(materialWastageDetail);
                                    }

                                    
                                }
                            }
                        }
                    }
                }
            }

            var materialWastageItems = new List<MaterialWastageItem>();

            if (details.Any())
            {
                foreach (var item in details)
                {
                    bool ifAny = _dbEntities.MaterialWastageItems.Any(i => i.ItemCode == item.ItemCode && (i.IsDeleted == null || i.IsDeleted == false));
                    if (ifAny)
                    {
                        var materialWastageItem = new MaterialWastageItem
                        {
                            AddedBy = item.AddedBy,
                            AddedDate = item.AddedDate,
                            AssemblyMaterialFault = item.AssemMaterialFault,
                            AssemblyProcessFault = item.AssemProcessFault,
                            BOMType = item.BOMType,
                            BomUnit = item.BOMUnit,
                            ItemCode = item.ItemCode,
                            ItemDetail = item.ItemName,
                            MonthName = model.MaterialWastageMaster.MonthName,
                            MonthNumber = model.MaterialWastageMaster.MonthNumber,
                            RepairMaterialFault = item.RepMaterialFault,
                            RepairProcessFault = item.RepProcessFault,
                            TotalWastageFault = item.TotalFault,
                            WastagePercentage = item.WastagePercentage,
                            YearNumber = model.MaterialWastageMaster.YearNumber,
                            MaterialWastageMasterId = model.MaterialWastageMaster.Id
                        };
                        materialWastageItems.Add(materialWastageItem);

                    }
                    else
                    {
                        if (item.TillNowTotalFault > 0)
                        {
                            int prevQty = item.TillNowTotalFault - item.TotalFault;
                            var materialWastageItem = new MaterialWastageItem
                            {
                                AddedBy = item.AddedBy,
                                AddedDate = item.AddedDate,
                                AssemblyMaterialFault = item.AssemMaterialFault,
                                AssemblyProcessFault = item.AssemProcessFault,
                                BOMType = item.BOMType,
                                BomUnit = item.BOMUnit,
                                ItemCode = item.ItemCode,
                                ItemDetail = item.ItemName,
                                MonthName = model.MaterialWastageMaster.MonthName,
                                MonthNumber = model.MaterialWastageMaster.MonthNumber,
                                RepairMaterialFault = item.RepMaterialFault,
                                RepairProcessFault = item.RepProcessFault,
                                TotalWastageFault = item.TotalFault,
                                WastagePercentage = item.WastagePercentage,
                                YearNumber = model.MaterialWastageMaster.YearNumber,
                                BOMTypeId = item.BOMTypeId,
                                MaterialWastageMasterId = model.MaterialWastageMaster.Id

                            };
                            materialWastageItems.Add(materialWastageItem);


                            int mNum = 0;
                            int yNum = 0;
                            if (model.MaterialWastageMaster.MonthNumber == 1)
                            {
                                mNum = 12;
                                yNum = model.MaterialWastageMaster.YearNumber - 1;
                            }
                            else
                            {
                                mNum = model.MaterialWastageMaster.MonthNumber - 1;
                                yNum = model.MaterialWastageMaster.YearNumber;
                            }
                            materialWastageItem = new MaterialWastageItem
                            {
                                AddedBy = item.AddedBy,
                                AddedDate = item.AddedDate,
                                AssemblyMaterialFault = item.TillNowAssemMaterialFault - item.AssemMaterialFault,
                                AssemblyProcessFault = item.TillNowAssemProcessFault - item.AssemProcessFault,
                                BOMType = item.BOMType,
                                BomUnit = item.BOMUnit,
                                ItemCode = item.ItemCode,
                                ItemDetail = item.ItemName,
                                MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mNum),
                                MonthNumber = mNum,
                                RepairMaterialFault = item.TillNowRepMaterialFault - item.RepMaterialFault,
                                RepairProcessFault = item.TillNowRepProcessFault - item.RepProcessFault,
                                TotalWastageFault = item.TillNowTotalFault - item.TotalFault,
                                WastagePercentage = item.WastagePercentage,
                                YearNumber = yNum,
                                BOMTypeId = item.BOMTypeId,
                                MaterialWastageMasterId = model.MaterialWastageMaster.Id
                            };
                            materialWastageItems.Add(materialWastageItem);
                        }
                    }
                }
            }

            try
            {
                var master =
                    _dbEntities.MaterialWastageMasters.FirstOrDefault(i => i.Id == model.MaterialWastageMaster.Id);


                if (master != null)
                {
                    master.UpdatedBy = userId;
                    master.UpdatedDate = DateTime.Now;
                    _dbEntities.MaterialWastageMasters.AddOrUpdate(master);



                    _dbEntities.MaterialWastageDetails.AddRange(details);
                    _dbEntities.MaterialWastageItems.AddRange(materialWastageItems);
                    _dbEntities.SaveChanges();
                    return new ResponseModel {ResponseCode = 1, ResponseMessage = "Saved Successfully."};
                }
                else
                {
                    return new ResponseModel { ResponseCode = 1, ResponseMessage = "Saved Successfully." };
                }

            }
            catch (Exception e)
            {
                return new ResponseModel { ResponseCode = 2, ResponseMessage = e.Message + "-" + e.InnerException.InnerException.Message };
            }


        }
    }
}