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
    
    public partial class PlazaSale
    {
        public long Id { get; set; }
        public string PlazaName { get; set; }
        public string EbsCustomerId { get; set; }
        public string SaleType { get; set; }
        public string CType { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public string BarCode { get; set; }
        public string Model { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
    }
}
