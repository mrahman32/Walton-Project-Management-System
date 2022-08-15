using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class ForeignModelInfoFromBtrcModel
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public string MarketingName { get; set; }
        public string Color { get; set; }
        public string DeviceType { get; set; }
        public string AppRef { get; set; }
        public string CountryOfOrigin { get; set; }
        public string ManfAsPerIMEITac { get; set; }
        public string NoOfSim { get; set; }
        public string BatteryCapacity { get; set; }
        public string BatteryCapacityTested { get; set; }
        public string ChargerType { get; set; }
        public string ChargerOutput { get; set; }
        public string Processor { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public string Nfc { get; set; }
        public string Bluetooth { get; set; }
        public string Wlan { get; set; }
        public string DataSpeed { get; set; }
        public string SarValue { get; set; }
        public string RearCamera { get; set; }
        public string FrontCamera { get; set; }
        public string CameraResolution { get; set; }
        public string RadioInterface { get; set; }
        public string SpectrumBands2G { get; set; }
        public string SpectrumBands3G { get; set; }
        public string SpectrumBands4G { get; set; }
        public string ChipsetModel { get; set; }
        public string OperatingSystem { get; set; }
        public string ImportQtyAir { get; set; }
        public string ImportQtySea { get; set; }
        public string TotalQuantity { get; set; }
        public string ProductType { get; set; }
        public string UnitPrice { get; set; }
        public string UnitPriceBdt { get; set; }
        public string MarketingPeriod { get; set; }
        public string ImeiTac1 { get; set; }
        public string ImeiTac2 { get; set; }
        public string ImeiTac3 { get; set; }
        public string ImeiTac4 { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public string Imei3 { get; set; }
        public string Imei4 { get; set; }
        public string DisplaySize { get; set; }
        public string NocDate { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Motherboard { get; set; }

        //custom
        public HttpPostedFileBase BtrcFile { get; set; }
    }
}