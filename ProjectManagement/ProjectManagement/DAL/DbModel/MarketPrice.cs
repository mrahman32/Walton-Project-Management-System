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
    
    public partial class MarketPrice
    {
        public long MarketPriceId { get; set; }
        public long ProjectMasterId { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal Multiplier { get; set; }
        public decimal Mrp { get; set; }
        public bool IsLocked { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}