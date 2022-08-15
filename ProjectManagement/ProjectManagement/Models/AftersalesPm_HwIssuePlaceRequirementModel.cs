using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class AftersalesPm_HwIssuePlaceRequirementModel
    {
        public long Id { get; set; }
        public Nullable<long> MainId { get; set; }
        public string RequirementDetails { get; set; }
        public string ForwardReason { get; set; }
        public string ReqStatus { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}