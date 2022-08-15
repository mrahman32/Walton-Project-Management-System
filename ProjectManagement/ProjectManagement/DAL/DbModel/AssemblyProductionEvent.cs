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
    
    public partial class AssemblyProductionEvent
    {
        public long Id { get; set; }
        public Nullable<long> ProjectId { get; set; }
        public string ProjectName { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public string PoCategory { get; set; }
        public Nullable<System.DateTime> MaterialReceiveDate { get; set; }
        public Nullable<System.DateTime> IqcCompleteDate { get; set; }
        public Nullable<System.DateTime> TrialProductionDate { get; set; }
        public Nullable<System.DateTime> SoftwareConfirmationDate { get; set; }
        public Nullable<System.DateTime> RnDClearanceDate { get; set; }
        public string AssemblyLineInformation { get; set; }
        public Nullable<System.DateTime> AssemblyProductionStartDate { get; set; }
        public Nullable<long> AssemblyQuantity { get; set; }
        public Nullable<long> AssemblyPerDayCapacity { get; set; }
        public Nullable<System.DateTime> AssemblyProductionEndDate { get; set; }
        public string Status { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
