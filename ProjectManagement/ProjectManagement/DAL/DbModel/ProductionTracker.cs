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
    
    public partial class ProductionTracker
    {
        public long ProductionId { get; set; }
        public string ModelName { get; set; }
        public string IMEI1 { get; set; }
        public string IMEI2 { get; set; }
        public string Color { get; set; }
        public string OrderNo { get; set; }
        public Nullable<bool> IsTrial { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public string SoftwareVersion { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpadatedDate { get; set; }
    }
}
