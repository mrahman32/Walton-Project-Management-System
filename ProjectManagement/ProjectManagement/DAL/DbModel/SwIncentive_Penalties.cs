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
    
    public partial class SwIncentive_Penalties
    {
        public long InsPenaltiesId { get; set; }
        public string EmployeeCode { get; set; }
        public string PenaltiesReason { get; set; }
        public string ProjectName { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public Nullable<decimal> TotalIssuePercentage { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> TotalPenalties { get; set; }
        public string PenaltiesPercentage { get; set; }
        public Nullable<int> AssignedPersons { get; set; }
        public Nullable<decimal> PreviousDeductedAmount { get; set; }
        public Nullable<decimal> ParticularPersonsPenalties { get; set; }
        public string PenaltiesRemarks { get; set; }
        public Nullable<decimal> FinalAmount { get; set; }
        public string Month { get; set; }
        public Nullable<int> MonNum { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
