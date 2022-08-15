using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Cm_MaterialReorderAndSupportModel
    {
        public long Id { get; set; }
        public Nullable<System.DateTime> OrderConfirmationDate { get; set; }
        public Nullable<System.DateTime> FactoryReceiveDate { get; set; }
        public Nullable<int> FixedDateDiff { get; set; }
        public Nullable<int> DateDifference { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> FinalAmount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Remarks { get; set; }
        public string MonthNames { get; set; }
        public int Years { get; set; }
    }
}