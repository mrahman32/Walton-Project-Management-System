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
    
    public partial class ProjectOrderPerformanceSum
    {
        public long Id { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public string Model { get; set; }
        public string Orders { get; set; }
        public Nullable<System.DateTime> LaunchDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> Days { get; set; }
        public Nullable<int> OrderWiseTotalActivation { get; set; }
        public Nullable<int> TotalServiceReceive { get; set; }
        public Nullable<int> TotalIssue { get; set; }
        public Nullable<decimal> TotalIssuePercentage { get; set; }
        public Nullable<int> TotalSpareConsumption { get; set; }
        public Nullable<decimal> SpareUsedPercentage { get; set; }
        public string Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
    }
}
