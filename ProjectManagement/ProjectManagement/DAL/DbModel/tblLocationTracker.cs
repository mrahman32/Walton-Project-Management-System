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
    
    public partial class tblLocationTracker
    {
        public long Id { get; set; }
        public string MobileNumber { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Address { get; set; }
        public string TimeStamp { get; set; }
        public Nullable<System.DateTime> LocationDate { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDateTime { get; set; }
    }
}
