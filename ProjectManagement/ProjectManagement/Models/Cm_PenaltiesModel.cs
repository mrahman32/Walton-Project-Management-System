using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Cm_PenaltiesModel
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public Nullable<System.DateTime> EffectiveMonth { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> AssumptionAmount { get; set; }
        public Nullable<decimal> RealAmount { get; set; }
        public Nullable<decimal> AssumptionPercentage { get; set; }
        public Nullable<decimal> RealPercentage { get; set; }
        public Nullable<decimal> Diff { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> FinalAmount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string MonthNames { get; set; }
        public int Years { get; set; }
    }
}