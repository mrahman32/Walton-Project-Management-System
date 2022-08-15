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
    
    public partial class Cm_MaterialShipmentAndConsumableItems
    {
        public long Id { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public string OraclePoNo { get; set; }
        public string PrNo { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public string ContainerType { get; set; }
        public string IsFinalShipment { get; set; }
        public Nullable<System.DateTime> PrDate { get; set; }
        public Nullable<System.DateTime> ProjectManagerClearanceDate { get; set; }
        public Nullable<System.DateTime> WarehouseEntryDate { get; set; }
        public Nullable<int> DaysDiff { get; set; }
        public Nullable<int> EffectiveTime { get; set; }
        public string ShipmentType { get; set; }
        public Nullable<decimal> Reward { get; set; }
        public Nullable<decimal> Penalties { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> ModifiedPenalties { get; set; }
        public Nullable<decimal> FinalAmount { get; set; }
        public Nullable<int> MonNum { get; set; }
        public Nullable<long> Year { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Remarks { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}