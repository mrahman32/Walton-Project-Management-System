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
    
    public partial class SwIncentive_PersonalUse
    {
        public long InsPersonalId { get; set; }
        public Nullable<long> SwQcPrUseFindId { get; set; }
        public string EmployeeCode { get; set; }
        public Nullable<long> ProjectId { get; set; }
        public Nullable<long> SwQcHeadAssignId { get; set; }
        public Nullable<int> TestPhaseId { get; set; }
        public Nullable<int> SoftwareVersionNumber { get; set; }
        public string ProjectName { get; set; }
        public string SoftwareVersionName { get; set; }
        public string IncentiveClaimArea { get; set; }
        public Nullable<int> Critical { get; set; }
        public Nullable<int> Major { get; set; }
        public Nullable<int> Minor { get; set; }
        public Nullable<decimal> BaseAmount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> ParticularPersonIncentive { get; set; }
        public Nullable<decimal> AddedAmount { get; set; }
        public string AddAmountRemarks { get; set; }
        public Nullable<decimal> Deduction { get; set; }
        public string DeductionRemarks { get; set; }
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
