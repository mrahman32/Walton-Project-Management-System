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
    
    public partial class PmPhnAccessory
    {
        public long PmPhnAccessoriesID { get; set; }
        public Nullable<long> ProjectAssignId { get; set; }
        public long ProjectMasterId { get; set; }
        public string PmPhnAccessoriesEarphone { get; set; }
        public string PmPhnAccessoriesUSBCable { get; set; }
        public string PmPhnAccessoriesCharger { get; set; }
        public string PmPhnAccessoriesOTGCable { get; set; }
        public string PmPhnAccessoriesBackCover { get; set; }
        public string PmPhnAccessoriesFlipCover { get; set; }
        public string Remarks { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}