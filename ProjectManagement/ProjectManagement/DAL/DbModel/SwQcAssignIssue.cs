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
    
    public partial class SwQcAssignIssue
    {
        public long SwQcAssignIssuesId { get; set; }
        public long SwQcIssueId { get; set; }
        public long ProjectMasterId { get; set; }
        public Nullable<long> SwQcAssignId { get; set; }
        public Nullable<bool> IsIssueChecked { get; set; }
        public string IssueComment { get; set; }
        public string QcCategoryName { get; set; }
        public string OccurenceRate { get; set; }
        public string ReproducePath { get; set; }
        public string ScreenShots1 { get; set; }
        public string ScreenShots2 { get; set; }
        public string ScreenShots3 { get; set; }
        public string VideoUpload1 { get; set; }
        public string VideoUpload2 { get; set; }
        public string VideoUpload3 { get; set; }
        public string ExpectedOutcome { get; set; }
        public string Priority { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
