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
    
    public partial class ScheduleDetail
    {
        public long ID { get; set; }
        public long ScheduleID { get; set; }
        public Nullable<int> MonthNumber { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> CellPhoneType { get; set; }
        public Nullable<long> ScheduledQty { get; set; }
    
        public virtual MasterSchedule MasterSchedule { get; set; }
    }
}
