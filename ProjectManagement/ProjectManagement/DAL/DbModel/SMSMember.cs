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
    
    public partial class SMSMember
    {
        public long SLNo { get; set; }
        public string MobileNo { get; set; }
        public string EmployeeCode { get; set; }
        public string MemberName { get; set; }
        public string Department { get; set; }
        public string Factory { get; set; }
        public string Designation { get; set; }
        public string GroupId { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    
        public virtual SMSGroup SMSGroup { get; set; }
    }
}
