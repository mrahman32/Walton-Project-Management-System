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
    
    public partial class SwQcIssue
    {
        public long SwQcIssueId { get; set; }
        public string QcCategoryName { get; set; }
        public string QcDescription { get; set; }
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
