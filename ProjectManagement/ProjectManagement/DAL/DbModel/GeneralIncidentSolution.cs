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
    
    public partial class GeneralIncidentSolution
    {
        public long SolutionId { get; set; }
        public Nullable<long> GeneralIncidentId { get; set; }
        public string Solution { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public string AddedByName { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public string AddedRole { get; set; }
        public Nullable<System.DateTime> DenyDate { get; set; }
        public string DenyRemark { get; set; }
    }
}
