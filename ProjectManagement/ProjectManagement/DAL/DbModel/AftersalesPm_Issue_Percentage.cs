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
    
    public partial class AftersalesPm_Issue_Percentage
    {
        public long Id { get; set; }
        public Nullable<long> IssuesIncentiveId { get; set; }
        public Nullable<long> GeneralIncidentId { get; set; }
        public string GeneralIncidentTitle { get; set; }
        public string EmployeeCode { get; set; }
        public string EmpName { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<int> Percentage { get; set; }
        public Nullable<decimal> PerPersonAmount { get; set; }
        public string IncentiveRemarks { get; set; }
        public string Month { get; set; }
        public Nullable<int> MonNum { get; set; }
        public Nullable<long> Year { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<long> Updated { get; set; }
    }
}
