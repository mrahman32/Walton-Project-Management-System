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
    
    public partial class tblDealerDistributionDetail
    {
        public System.Guid DealerdistributionId { get; set; }
        public string DealerCode { get; set; }
        public string BarCode { get; set; }
        public string BarCode2 { get; set; }
        public string Model { get; set; }
        public string DONumber { get; set; }
        public Nullable<System.DateTime> DistributionDate { get; set; }
        public Nullable<bool> IsSoldOut { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<decimal> ListPrice { get; set; }
        public Nullable<decimal> SellingPrice { get; set; }
    }
}
