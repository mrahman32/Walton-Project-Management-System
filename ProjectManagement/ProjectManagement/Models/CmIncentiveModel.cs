using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class CmIncentiveModel
    {
        public string OthersType { get; set; }
        public string IncentiveTypes { get; set; }
        public long? ProjectMasterId { get; set; }
        public string ProjectName { get; set; }
        public int? Orders { get; set; }
        public string PoCategory { get; set; }
        public long? PoQuantity { get; set; }
        public int? LotNumber { get; set; }
        public long? LotQuantity { get; set; }
        public DateTime? ProjectManagerClearanceDate { get; set; }
        public DateTime? EffectiveMonth { get; set; }
        public string ChinaIqcPassHundredPercent { get; set; }
        public int? NoOfTimeInspection { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AddedAmount { get; set; }
        public decimal? TotalDeduction { get; set; }
        public string DeductionRemarks { get; set; }
        public decimal? FinalAmount { get; set; }
        public string Remarks { get; set; }
        public int? MonNum { get; set; }
        public long? Year { get; set; }
        public long? Added { get; set; }
        public DateTime? AddedDate { get; set; }
        public long? Updated { get; set; }
        public DateTime? UpdatedDate { get; set; }

        //new
        public string totalIns { get; set; }
        public decimal? totalIncentiveAmount { get; set; }

        public string orders { get; set; }
        public decimal? parameter { get; set; }
        public decimal? parameter_Value { get; set; }
        public decimal? orders_Value { get; set; }

        public string primarySales { get; set; }
        public decimal? primaryParameter { get; set; }
        public decimal? primaryParameter_value { get; set; }
        public decimal? primaryParameter_Total_value { get; set; }


        public string featureRatio { get; set; }
        public decimal? serviceToSalesForFeaturePhone { get; set; }
        public decimal? primaryParameterValueForFeaturePhone { get; set; }
        public decimal? finalServiceToSalesRatioForFeature { get; set; }

        public string smartRatio { get; set; }
        public decimal? serviceToSalesForSmartPhone { get; set; }
        public decimal? primaryParameterValueForSmartPhone { get; set; }
        public decimal? finalServiceToSalesRatioForSmart { get; set; }

        public decimal? IncentiveQtyOrPercent { get; set; }
        public decimal? IncentiveValue { get; set; }
        public decimal? IncentiveTotalSum { get; set; }

     
    }
}