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
    
    public partial class tblActivatedInvoiceValueVsSpareValue
    {
        public long Id { get; set; }
        public string ModelName { get; set; }
        public Nullable<decimal> TotalActivatedInvoiceValue { get; set; }
        public Nullable<decimal> SpareTotal { get; set; }
        public Nullable<decimal> PCBA { get; set; }
        public Nullable<decimal> LCD { get; set; }
        public Nullable<decimal> Touch { get; set; }
        public Nullable<decimal> Battery { get; set; }
        public Nullable<decimal> IC { get; set; }
        public Nullable<decimal> Accessories { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string AddedBy { get; set; }
    }
}
