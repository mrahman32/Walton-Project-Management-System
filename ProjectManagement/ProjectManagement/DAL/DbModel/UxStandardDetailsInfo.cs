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
    
    public partial class UxStandardDetailsInfo
    {
        public long Id { get; set; }
        public Nullable<long> SwQcHeadAssignId { get; set; }
        public Nullable<long> OptionId { get; set; }
        public Nullable<long> StandardId { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public string FinalComments { get; set; }
        public string Attachments { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}