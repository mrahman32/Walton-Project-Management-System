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
    
    public partial class SMSGroup
    {
        public SMSGroup()
        {
            this.SMSMembers = new HashSet<SMSMember>();
        }
    
        public string GroupId { get; set; }
        public Nullable<int> GroupNo { get; set; }
        public Nullable<System.DateTime> GroupDate { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string Updatedby { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    
        public virtual ICollection<SMSMember> SMSMembers { get; set; }
    }
}
