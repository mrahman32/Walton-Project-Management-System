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
    
    public partial class tblMargineOfError
    {
        public long Id { get; set; }
        public string Model { get; set; }
        public Nullable<int> MarketStock { get; set; }
        public Nullable<int> ExpectedStock { get; set; }
        public Nullable<decimal> MargineOfError { get; set; }
        public Nullable<decimal> AppliedMOE { get; set; }
        public Nullable<System.DateTime> StockDate { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<int> SampleQuantity { get; set; }
    }
}
