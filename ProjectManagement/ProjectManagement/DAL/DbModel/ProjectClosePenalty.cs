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
    
    public partial class ProjectClosePenalty
    {
        public long ProjectClosePenaltyId { get; set; }
        public Nullable<long> ProjectPurchaseOrderFormId { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public string ProjectName { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public Nullable<System.DateTime> PoDate { get; set; }
        public Nullable<int> PoCreatedBeforeMonth { get; set; }
        public Nullable<int> DaysPassedAfterSevenMonth { get; set; }
        public Nullable<int> Penalty { get; set; }
        public Nullable<System.DateTime> IsCompletedDate { get; set; }
    }
}