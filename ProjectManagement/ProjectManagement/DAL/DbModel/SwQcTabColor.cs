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
    
    public partial class SwQcTabColor
    {
        public long SwQcTabColorId { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public Nullable<long> SwQcInchargeAssignId { get; set; }
        public Nullable<long> SwQcUserId { get; set; }
        public Nullable<long> SwQcAssignId { get; set; }
        public string QcCategoryName { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
    }
}
