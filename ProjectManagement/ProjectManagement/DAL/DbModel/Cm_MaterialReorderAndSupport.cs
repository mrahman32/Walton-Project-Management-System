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
    
    public partial class Cm_MaterialReorderAndSupport
    {
        public long Id { get; set; }
        public Nullable<System.DateTime> OrderConfirmationDate { get; set; }
        public Nullable<System.DateTime> FactoryReceiveDate { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> FixedDateDiff { get; set; }
        public Nullable<int> DateDifference { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> FinalAmount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
