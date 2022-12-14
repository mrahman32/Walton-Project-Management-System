using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Cm_ReportAnalysisModel
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> DocumentSubmitDate { get; set; }
        public Nullable<int> Timeline { get; set; }
        public Nullable<int> DateDifference { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> FinalAmount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}