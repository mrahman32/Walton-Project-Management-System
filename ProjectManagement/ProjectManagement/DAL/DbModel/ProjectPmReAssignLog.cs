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
    
    public partial class ProjectPmReAssignLog
    {
        public long ProjectPmReAssignId { get; set; }
        public long ProjectMasterId { get; set; }
        public string PONumber { get; set; }
        public System.DateTime InactiveDate { get; set; }
        public long InactiveUserId { get; set; }
        public long ActiveProjectManagerUserId { get; set; }
        public string ProjectHeadInActiveRemarks { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> ApproxPmInchargeToPmFinishDate { get; set; }
    }
}
