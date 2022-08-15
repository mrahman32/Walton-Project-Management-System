using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class AftersalesPm_HwIssueReportShareModel
    {
        public long Id { get; set; }
        public Nullable<long> MainId { get; set; }
        public string ReportDetails { get; set; }
        public string InstructionService { get; set; }
        public string InstructionProduction { get; set; }
        public string FuturePlanForNxtPro { get; set; }
        public string ForwardReason { get; set; }
        public string Status { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}