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
    
    public partial class ProjectPhoneSupplier
    {
        public long ProjectPhoneSupplierId { get; set; }
        public long ProjectMasterId { get; set; }
        public long PhoneSupplierId { get; set; }
        public string SupplyType { get; set; }
        public bool IsHandSetSupplier { get; set; }
        public System.DateTime PoDate { get; set; }
        public System.DateTime ApproxShippingDate { get; set; }
        public string SupplierModelName { get; set; }
        public string WaltonModelName { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}