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
    
    public partial class SmtCapacityExceedLog
    {
        public long Id { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public string SmtCapacityCrossedForModel { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public Nullable<long> RunningSmtQuantity { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string OrderQuantity { get; set; }
        public Nullable<System.DateTime> PoDate { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
    }
}
