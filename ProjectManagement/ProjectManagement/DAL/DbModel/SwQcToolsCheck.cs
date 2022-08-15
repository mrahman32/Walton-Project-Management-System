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
    
    public partial class SwQcToolsCheck
    {
        public long SwQcToolsCheckId { get; set; }
        public long SwQcIssueId { get; set; }
        public long ProjectMasterId { get; set; }
        public Nullable<long> SwQcInchargeAssignId { get; set; }
        public long SwQcAssignId { get; set; }
        public Nullable<bool> IsIssueChecked { get; set; }
        public string Result { get; set; }
        public string IssueComment { get; set; }
        public string QcCategoryName { get; set; }
        public string UploadedFile { get; set; }
        public string IssueType { get; set; }
        public string Frequency { get; set; }
        public string IssueReproducePath { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<bool> IsSmart { get; set; }
        public Nullable<bool> IsFeature { get; set; }
        public Nullable<bool> IsWalpad { get; set; }
        public Nullable<bool> IsTab { get; set; }
        public Nullable<bool> IsPowerbank { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
