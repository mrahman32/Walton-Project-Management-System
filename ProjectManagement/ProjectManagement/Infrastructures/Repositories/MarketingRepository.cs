using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using AutoMapper;
using ProjectManagement.DAL.DbModel;
using ProjectManagement.Infrastructures.Interfaces;
using ProjectManagement.Models;

namespace ProjectManagement.Infrastructures.Repositories
{
    public class MarketingRepository : IMarketingRepository
    {
        private readonly CellPhoneProjectEntities _dbeEntities;

        public MarketingRepository()
        {
            _dbeEntities = new CellPhoneProjectEntities();
            _dbeEntities.Configuration.LazyLoadingEnabled = false;
        }

        #region GET
        public List<MkProjectSpecModel> GetMkProjectSpecModels()
        {
            var model = (from m in _dbeEntities.MkProjectSpecs
                         select new MkProjectSpecModel
                         {
                             Id = m.Id,
                             ProductType=m.ProductType,
                             Brand = m.Brand,
                             ModelName = m.ModelName,
                             PLC=m.PLC,
                             ResolutionHor=m.ResolutionHor,
                             ResolutionVer=m.ResolutionVer,
                             ResolutionName=m.ResolutionName,
                             SimSlotNumber = m.SimSlotNumber,
                             SimSlotType = m.SimSlotType,
                             DisplaySize = m.DisplaySize,
                             Resolution = m.Resolution,
                             DisplayType = m.DisplayType,
                             OperatingSystem = m.OperatingSystem,
                             OsVersion = m.OsVersion,
                             Chipset = m.Chipset,
                             CPU = m.CPU,
                             CPUFrequency = m.CPUFrequency,
                             Network = m.Network,
                             GPU = m.GPU,
                             FrontCamera = m.FrontCamera,
                             BackCamera = m.BackCamera,
                             RAM = m.RAM,
                             RAM_Band=m.RAM_Band,
                             ROM = m.ROM,
                             ROM_Band=m.ROM_Band,
                             BatteryCapacity = m.BatteryCapacity,
                             BatteryType = m.BatteryType,
                             Price = m.Price,
                             AddedBy = m.AddedBy,
                             AddedByName = _dbeEntities.CmnUsers.Where(x => x.CmnUserId == m.AddedBy).Select(x => x.UserFullName).FirstOrDefault(),
                             AddedDate = m.AddedDate,
                             UpdatedBy = m.UpdatedBy,
                             UpdatedByName = _dbeEntities.CmnUsers.Where(x => x.CmnUserId == m.UpdatedBy).Select(x => x.UserFullName).FirstOrDefault(),
                             UpdatedDate = m.UpdatedDate,
                             DealerPrice = m.DealerPrice,
                             InvoicePrice = m.InvoicePrice,
                             DealerComission = m.DealerComission,
                             RetailerComission = m.RetailerComission,
                             CommercialImportPrice = m.CommercialImportPrice,
                             ColorAvailable = m.ColorAvailable,
                             Gift = m.Gift,
                             HeadPhone = m.HeadPhone,
                             DataCable = m.DataCable,
                             Charger = m.Charger,
                             ScreenProtector = m.ScreenProtector,
                             PhoneCase = m.PhoneCase,
                             ExpandableStorage = m.ExpandableStorage,
                             UpcomingPrice=m.UpcomingPrice,
                             ReleaseDate = m.ReleaseDate,
                             ExtraFeatures = m.ExtraFeatures,
                             FPSensor=m.FPSensor,
                             FaceID=m.FaceID,
                             DimensionsLength=m.DimensionsLength,
                             DimensionsWidth=m.DimensionsWidth,
                             DimensionsThikness=m.DimensionsThikness,
                             NOCDate=m.NOCDate,
                             NOCTotalQty=m.NOCTotalQty,
                             NOCLastQty=m.NOCLastQty,
                             RefreshRate=m.RefreshRate,
                             ChipsetBrand=m.ChipsetBrand,
                             ChipsetModel=m.ChipsetModel,
                             Torch = m.Torch??false,
                             FmRadio = m.FmRadio??false
                         }).ToList();
            //foreach (var m in model)
            //{
            //    m.ModelName = m.Brand + " " + m.ModelName;
            //}
            return model;
        }

        public MkProjectSpecModel GetMkProjectSpecModelById(long id)
        {
            var model = (from m in _dbeEntities.MkProjectSpecs
                         where m.Id == id
                         select new MkProjectSpecModel
                         {
                             Id = m.Id,
                             Brand = m.Brand,
                             ModelName = m.ModelName,
                             SimSlotNumber = m.SimSlotNumber,
                             SimSlotType = m.SimSlotType,
                             DisplaySize = m.DisplaySize,
                             Resolution = m.Resolution,
                             DisplayType = m.DisplayType,
                             OperatingSystem = m.OperatingSystem,
                             OsVersion = m.OsVersion,
                             Chipset = m.Chipset,
                             ChipsetBrand=m.ChipsetBrand,
                             ChipsetModel=m.ChipsetModel,
                             CPU = m.CPU,
                             CPUFrequency = m.CPUFrequency,
                             Network = m.Network,
                             GPU = m.GPU,
                             FrontCamera = m.FrontCamera,
                             NoFrontCamera=m.NoFrontCamera,
                             BackCamera = m.BackCamera,
                             NoBackCamera=m.NoBackCamera,
                             RAM = m.RAM,
                             RAM_Band=m.RAM_Band,
                             ROM = m.ROM,
                             ROM_Band=m.ROM_Band,
                             BatteryCapacity = m.BatteryCapacity,
                             BatteryType = m.BatteryType,
                             Price = m.Price,
                             AddedBy = m.AddedBy,
                             AddedByName = _dbeEntities.CmnUsers.Where(x=>x.CmnUserId==m.AddedBy).Select(x=>x.UserFullName).FirstOrDefault(),
                             AddedDate = m.AddedDate,
                             UpdatedBy = m.UpdatedBy,
                             UpdatedByName = _dbeEntities.CmnUsers.Where(x => x.CmnUserId == m.UpdatedBy).Select(x => x.UserFullName).FirstOrDefault(),
                             UpdatedDate = m.UpdatedDate,
                             DealerPrice = m.DealerPrice,
                             InvoicePrice = m.InvoicePrice,
                             DealerComission = m.DealerComission,
                             RetailerComission = m.RetailerComission,
                             CommercialImportPrice = m.CommercialImportPrice,
                             ColorAvailable = m.ColorAvailable,
                             Gift = m.Gift,
                             HeadPhone = m.HeadPhone,
                             DataCable = m.DataCable,
                             Charger = m.Charger,
                             ScreenProtector = m.ScreenProtector,
                             PhoneCase = m.PhoneCase,
                             ExpandableStorage = m.ExpandableStorage,
                             ExpandableStorage_Band=m.ExpandableStorage_Band,
                             UpcomingPrice = m.UpcomingPrice,
                             ReleaseDate = m.ReleaseDate,
                             ProductType = m.ProductType,
                             PLC=m.PLC,
                             ResolutionHor=m.ResolutionHor,
                             ResolutionVer=m.ResolutionVer,
                             ResolutionName=m.ResolutionName,
                             ResolutionPPI=m.ResolutionPPI,
                             ResolutionDesc=m.ResolutionDesc,
                             RefreshRate=m.RefreshRate,
                             NOCDate=m.NOCDate,
                             NOCTotalQty=m.NOCTotalQty,
                             NOCLastQty=m.NOCLastQty,
                             FPSensor=m.FPSensor,
                             FaceID=m.FaceID,
                             FP_InDisplay=m.FP_InDisplay,
                             DimensionsLength=m.DimensionsLength,
                             DimensionsWidth=m.DimensionsWidth,
                             DimensionsThikness=m.DimensionsThikness,
                             ChargingUnit=m.ChargingUnit,
                             ExtraFeatures = m.ExtraFeatures,
                             Torch = m.Torch??false,
                             FmRadio = m.FmRadio??false
                         }).FirstOrDefault();
            return model;
        }

        public List<MkOtherBrandModelModel> GetMkOtherBrands()
        {
            var m = (from v in _dbeEntities.MkOtherBrandModels
                group v by v.Brand
                into b
                select new MkOtherBrandModelModel
                {
                    Brand = b.Key
                }).ToList();
            return m;
        }

        public List<MkProjectSpecModel> GetMkProjectSpeBrands()
        {
            try
            {

                var m = (from v in _dbeEntities.MkProjectSpecs
                         group v by v.Brand
                             into b
                             select new MkProjectSpecModel
                             {
                                 Brand = b.Key
                             }).ToList();
                return m;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public MkMarketOrderQuantityDetailModel GetMarketOrderQuantityDetailById(long id)
        {
            var model =
                _dbeEntities.MkMarketOrderQuantityDetails.Where(x => x.Id == id)
                    .Select(x => new MkMarketOrderQuantityDetailModel
                    {
                        Id=x.Id,
                        MkProjectSpecId = x.MkProjectSpecId,
                        OrderNumber = x.OrderNumber,
                        PoName = x.PoName,
                        NOC_Quantity = x.NOC_Quantity,
                        OrderQuantity = x.OrderQuantity,
                        FOB_Price = x.FOB_Price,
                        FOB_PriceCurrencyType = x.FOB_PriceCurrencyType,
                        BTRC_NOC_Price = x.BTRC_NOC_Price,
                        BTRC_NOC_PriceCurrencyType = x.BTRC_NOC_PriceCurrencyType,
                        CustAssPriceCurrencyType = x.CustAssPriceCurrencyType,
                        CustomsAssessmentPrice = x.CustomsAssessmentPrice,
                        AddedBy = x.AddedBy,
                        AddedDate = x.AddedDate,
                        UpdatedBy = x.UpdatedBy,
                        UpdatedDate = x.UpdatedDate,
                        ModelName = _dbeEntities.MkProjectSpecs.Where(y => y.Id == x.MkProjectSpecId).Select(y => y.ModelName).FirstOrDefault()
                    }).FirstOrDefault();
            return model;
        }

        public List<MkMarketOrderQuantityDetailModel> GetMarketOrderQuantityDetailModels()
        {
            var model =
                _dbeEntities.MkMarketOrderQuantityDetails
                    .Select(x => new MkMarketOrderQuantityDetailModel
                    {
                        Id = x.Id,
                        MkProjectSpecId = x.MkProjectSpecId,
                        OrderNumber = x.OrderNumber,
                        PoName = x.PoName,
                        NOC_Quantity = x.NOC_Quantity,
                        OrderQuantity = x.OrderQuantity,
                        FOB_Price = x.FOB_Price,
                        FOB_PriceCurrencyType = x.FOB_PriceCurrencyType,
                        BTRC_NOC_Price = x.BTRC_NOC_Price,
                        BTRC_NOC_PriceCurrencyType = x.BTRC_NOC_PriceCurrencyType,
                        CustAssPriceCurrencyType = x.CustAssPriceCurrencyType,
                        CustomsAssessmentPrice = x.CustomsAssessmentPrice,
                        AddedBy = x.AddedBy,
                        AddedDate = x.AddedDate,
                        UpdatedBy = x.UpdatedBy,
                        UpdatedDate = x.UpdatedDate,
                        ModelName = _dbeEntities.MkProjectSpecs.Where(y=>y.Id==x.MkProjectSpecId).Select(y=>y.ModelName).FirstOrDefault()
                    }).ToList();
            return model;
        }
        public MkMarketOrderQuantityDetail SameOrderCheck(long? specId, int? orderno)
        {
            var model =
                _dbeEntities.MkMarketOrderQuantityDetails.FirstOrDefault(
                    x => x.MkProjectSpecId == specId && x.OrderNumber == orderno);
            return model;
        }
        #endregion

        #region Set
        public MkProjectSpecModel SaveMkProjectSpec(MkProjectSpecModel model)
        {
            Mapper.CreateMap<MkProjectSpecModel, MkProjectSpec>();
            var specs = Mapper.Map<MkProjectSpec>(model);
            _dbeEntities.MkProjectSpecs.Add(specs);
            _dbeEntities.SaveChanges();
            model.Id = specs.Id;
            return model;
        }

        public MkMarketOrderQuantityDetailModel SaveMarketOrderQuantityDetail(MkMarketOrderQuantityDetailModel model)
        {
            Mapper.CreateMap<MkMarketOrderQuantityDetailModel, MkMarketOrderQuantityDetail>();
            var specs = Mapper.Map<MkMarketOrderQuantityDetail>(model);
            _dbeEntities.MkMarketOrderQuantityDetails.Add(specs);
            _dbeEntities.SaveChanges();
            model.Id = specs.Id;
            return model;
        }
        #endregion

        #region Update
        public MkProjectSpecModel UpdateMkProjectSpec(MkProjectSpecModel model)
        {
            Mapper.CreateMap<MkProjectSpecModel, MkProjectSpec>();
            var specs = Mapper.Map<MkProjectSpec>(model);
            _dbeEntities.MkProjectSpecs.AddOrUpdate(specs);
            _dbeEntities.SaveChanges();
            return model;
        }

        public MkMarketOrderQuantityDetailModel UpdateMarketOrderQuantityDetail(MkMarketOrderQuantityDetailModel model)
        {
            Mapper.CreateMap<MkMarketOrderQuantityDetailModel, MkMarketOrderQuantityDetail>();
            var specs = Mapper.Map<MkMarketOrderQuantityDetail>(model);
            _dbeEntities.MkMarketOrderQuantityDetails.AddOrUpdate(specs);
            _dbeEntities.SaveChanges();
            model.Id = specs.Id;
            return model;
        }
        #endregion
    }
}