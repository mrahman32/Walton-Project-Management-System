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
    
    public partial class ProjectOrderAcknowledgeMasterLog
    {
        public long Id { get; set; }
        public Nullable<long> AckMasterId { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public string AcknowledgeStatus { get; set; }
        public Nullable<long> AcknowledgeBy { get; set; }
        public Nullable<System.DateTime> AcknowledgeDate { get; set; }
        public string AcknowledgeRemarks { get; set; }
        public Nullable<System.DateTime> HoldEndDate { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
