using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Cm_MaterialShipmentAndConsumableItemsModel
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
        public string PrDate { get; set; }
          [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public string ProjectManagerClearanceDate { get; set; }
          [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public string WarehouseEntryDate { get; set; }
        public Nullable<int> DaysDiff { get; set; }
        public Nullable<int> EffectiveTime { get; set; }
        public string ShipmentType { get; set; }
        public Nullable<decimal> Reward { get; set; }
        public Nullable<decimal> Penalties { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> FinalAmount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public int? MonNum { get; set; }
        public long? Year { get; set; }
        public Nullable<decimal> ModifiedPenalties { get; set; }
        public string Remarks { get; set; }
    }
}