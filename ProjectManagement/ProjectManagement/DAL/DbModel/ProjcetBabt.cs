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
    
    public partial class ProjcetBabt
    {
        public long ProjectBabtId { get; set; }
        public long ProjectMasterId { get; set; }
        public Nullable<long> PmAssignId { get; set; }
        public Nullable<long> ProjectPurchaseOrderFormId { get; set; }
        public Nullable<System.DateTime> PmImeiRangeRequestDate { get; set; }
        public Nullable<long> BabtRawId { get; set; }
        public string TacNo { get; set; }
        public string ImeiRangeFrom { get; set; }
        public string ImeiRangeTo { get; set; }
        public Nullable<System.DateTime> RangeToPmDate { get; set; }
        public Nullable<System.DateTime> RangeToSupplierDate { get; set; }
        public Nullable<long> RequestedImeiQuantity { get; set; }
        public Nullable<long> GivenQuantityFromCommercial { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
