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
    
    public partial class MajorIssue
    {
        public long MajorIssueId { get; set; }
        public string ServicePoint { get; set; }
        public long IncidentId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public System.DateTime ReceivedDate { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string ModelName { get; set; }
        public string ProblemDescription { get; set; }
        public string ProblemNames { get; set; }
    }
}
