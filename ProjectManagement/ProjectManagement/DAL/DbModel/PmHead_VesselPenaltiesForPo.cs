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
    
    public partial class PmHead_VesselPenaltiesForPo
    {
        public long Id { get; set; }
        public Nullable<long> ProjectMasterID { get; set; }
        public string ProjectName { get; set; }
        public string EmployeeCode { get; set; }
        public string Orders { get; set; }
        public string ProjectType { get; set; }
        public string ShipmentType { get; set; }
        public Nullable<System.DateTime> PoDate { get; set; }
        public Nullable<System.DateTime> LSD { get; set; }
        public Nullable<int> PoVsLSDDiff { get; set; }
        public Nullable<System.DateTime> VesselDate { get; set; }
        public Nullable<int> LsdVsVesselDiffForDeduct { get; set; }
        public Nullable<long> DeductPoint { get; set; }
        public Nullable<long> FeatureBase { get; set; }
        public Nullable<long> SmartBase { get; set; }
        public Nullable<long> PoReward { get; set; }
        public Nullable<long> PerDayDeduction { get; set; }
        public Nullable<long> TotalPenalties { get; set; }
        public string RoleName { get; set; }
        public string Month { get; set; }
        public Nullable<int> MonNum { get; set; }
        public Nullable<long> Year { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
