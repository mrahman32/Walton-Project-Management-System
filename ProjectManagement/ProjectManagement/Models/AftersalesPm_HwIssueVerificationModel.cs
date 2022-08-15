using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class AftersalesPm_HwIssueVerificationModel
    {
        public long Id { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public string ModelName { get; set; }
        public string SoftwareVersionName { get; set; }
        public string SoftwareVersionNo { get; set; }
        public string Module { get; set; }
        public string IssueDetails { get; set; }
        public string IssueFrequency { get; set; }
        public string IssueType { get; set; }
        public string TestingPath { get; set; }
        public string ResultFound { get; set; }
        public string ExpectedResult { get; set; }
        public string Data { get; set; }
        public Nullable<int> NumberOfHSsChecked { get; set; }
        public Nullable<int> NumberOfHSsReturn { get; set; }
        public string Status { get; set; }
        public string IssueOccRatio { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string SupportingDocument { get; set; }
        public string DocumentUploadedByQc { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string SupplierName { get; set; }
    }
}