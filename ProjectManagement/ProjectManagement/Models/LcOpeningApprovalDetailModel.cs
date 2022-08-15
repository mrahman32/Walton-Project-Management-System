using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class LcOpeningApprovalDetailModel
    {
        public long Id { get; set; }
        public Nullable<long> ApprovedBy { get; set; }
        public string ApprovedByName { get; set; }
        public string Remarks { get; set; }
        public string Role { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
    }
}