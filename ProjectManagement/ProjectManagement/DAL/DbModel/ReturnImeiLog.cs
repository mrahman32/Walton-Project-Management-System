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
    
    public partial class ReturnImeiLog
    {
        public long ReturnImeiId { get; set; }
        public string IMEI { get; set; }
        public string IMEI2 { get; set; }
        public string Model { get; set; }
        public string DistributorName { get; set; }
        public string DistributionDate { get; set; }
        public string DealerCode { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
    }
}
