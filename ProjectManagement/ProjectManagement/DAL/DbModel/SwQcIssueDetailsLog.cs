//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagement.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SwQcIssueDetailsLog
    {
        public long SwQcIssueLogId { get; set; }
        public long SwQcIssueId { get; set; }
        public long SwQcAssignId { get; set; }
        public long SwQcHeadAssignId { get; set; }
        public long ProjectMasterId { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public string ProjectName { get; set; }
        public Nullable<System.DateTime> WaltonQcComDate { get; set; }
        public string WaltonQcComment { get; set; }
        public string WaltonQcStatus { get; set; }
        public Nullable<System.DateTime> SupplierComDate { get; set; }
        public string SupplierComment { get; set; }
        public string SupplierStatus { get; set; }
        public Nullable<System.DateTime> WaltonPmComDate { get; set; }
        public string WaltonPmComment { get; set; }
        public string WaltonPmStatus { get; set; }
        public string SupplierFeedbackForAppend { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> IssueSerial { get; set; }
    }
}