using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class LcApprovalManagerModel
    {
        public long Id { get; set; }
        public string RoleDescription { get; set; }
        public string Dependency { get; set; }
        public Nullable<decimal> StartingValue { get; set; }
        public Nullable<decimal> EndingVal { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}