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
    
    public partial class Bid_HandsetDetails
    {
        public long Id { get; set; }
        public Nullable<long> BidId { get; set; }
        public string Model { get; set; }
        public string ItemCode { get; set; }
        public string Color { get; set; }
        public string IMEI1 { get; set; }
        public string IMEI2 { get; set; }
        public Nullable<int> Qty { get; set; }
        public string QC_Functional { get; set; }
        public string QC_Aesthetical { get; set; }
        public Nullable<decimal> Per_Unit_Price { get; set; }
        public string Admin_Remarks { get; set; }
        public string Lock { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
