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
    
    public partial class HwInchargeAssign
    {
        public long HwInchargeAssignId { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public string HwTestMasterId { get; set; }
        public string HwTestName { get; set; }
        public string TestPhase { get; set; }
        public string Status { get; set; }
        public Nullable<long> AssignedBy { get; set; }
        public Nullable<System.DateTime> AssignedDate { get; set; }
        public string Remarks { get; set; }
        public Nullable<long> ForwardedBy { get; set; }
        public Nullable<System.DateTime> ForwardedDate { get; set; }
    }
}