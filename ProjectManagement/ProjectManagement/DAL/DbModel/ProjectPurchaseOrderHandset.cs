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
    
    public partial class ProjectPurchaseOrderHandset
    {
        public long ProjectPurchaseOrdeHandsetId { get; set; }
        public long ProjectPurchaseOrderFormId { get; set; }
        public Nullable<long> SerialNo { get; set; }
        public string Model { get; set; }
        public Nullable<int> OrderQuantity { get; set; }
        public string Color { get; set; }
        public string Value { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
