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
    
    public partial class HwIssueType
    {
        public HwIssueType()
        {
            this.HwIssueTypeDetails = new HashSet<HwIssueTypeDetail>();
        }
    
        public long HwIssueTypeId { get; set; }
        public long HwIssueMasterId { get; set; }
        public string IssueTypeName { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual HwIssueMaster HwIssueMaster { get; set; }
        public virtual ICollection<HwIssueTypeDetail> HwIssueTypeDetails { get; set; }
    }
}
