using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class AftersalesPm_HwIssueVerificationLogModel
    {
        public long Id { get; set; }
        public Nullable<long> MainId { get; set; }
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
        public Nullable<bool> IsActive { get; set; }
        public string SupportingDocument { get; set; }
        public string DocumentUploadedByQc { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<long> LogAdded { get; set; }
        public Nullable<System.DateTime> LogAddedDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> DateDiffs { get; set; }
        public string IssueOccRatio { get; set; }
        public string Remarks { get; set; }
        public string DeclineReason { get; set; }
    }
}