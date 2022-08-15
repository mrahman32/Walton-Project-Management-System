using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Cm_TotalPoLcAndTtModel
    {
        public string AllType { get; set; }
        public int TotalsCount { get; set; }
        public int TotalTt { get; set; }
        public int TotalLc { get; set; }
        public int TotalPo { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Reward { get; set; }
        public decimal? FinalAmount { get; set; }

        //
        public long? ProjectLcId { get; set; }
        public long? ProjectPurchaseOrderFormId { get; set; }
        public long? ProjectMasterId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public string OraclePoNo { get; set; }
        public string OracleLcNo { get; set; }
        public string ProductType { get; set; }
        public string OpeningDate { get; set; }
        public string LcPassDate { get; set; }
        public string LcValue { get; set; }
        public string TtDate { get; set; }
        public string TtNumber { get; set; }
        public string TtValue { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string PoDate { get; set; }
        public string PoCategory { get; set; }
        //
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string MonthNames { get; set; }
        public int Years { get; set; }
    }
}