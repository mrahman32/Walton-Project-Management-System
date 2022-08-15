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
    
    public partial class ProjectOrderQuantityDetail
    {
        public long Id { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public string ProjectModel { get; set; }
        public Nullable<long> OrderQuantity { get; set; }
        public string RamVendor { get; set; }
        public string RomVendor { get; set; }
        public Nullable<decimal> VariantPrice { get; set; }
        public string CurrencyName { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public bool BTRCPush { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> MarketClearanceDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<long> VariantClosingBy { get; set; }
        public Nullable<System.DateTime> VariantClosingDate { get; set; }
        public string ClosingRemarks { get; set; }
        public Nullable<long> DeactivatedBy { get; set; }
        public Nullable<System.DateTime> DeactivationDate { get; set; }
        public Nullable<long> ActivationBy { get; set; }
        public Nullable<System.DateTime> ActivationDate { get; set; }
    }
}
