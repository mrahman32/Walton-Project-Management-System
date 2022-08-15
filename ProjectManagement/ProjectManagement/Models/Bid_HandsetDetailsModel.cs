using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Bid_HandsetDetailsModel
    {
        public long Id { get; set; }
        public Nullable<long> BidId { get; set; }
        public Nullable<long> HandsetIds { get; set; }
        public string Model { get; set; }
        public string ItemCode { get; set; }
        public string Color { get; set; }
        public string IMEI1 { get; set; }
        public string IMEI2 { get; set; }
        public Nullable<int> Qty { get; set; }
        public string QC_Functional { get; set; }
        public string QC_Aesthetical { get; set; }
        public Nullable<decimal> Per_Unit_Price { get; set; }
        public string Admin_Remarks { get; set; }
        public string Lock { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<System.DateTime> BidCreationDate { get; set; }
        public Nullable<System.DateTime> BidUpdatedDate { get; set; }
        public Nullable<bool> IsClosed { get; set; }
        public int TotalRow { get; set; }
        public string ApproveStatus { get; set; }
        public string BidderRemarks { get; set; }
        public decimal? BidderPerUnitPrice { get; set; }
        public int? Bidder_Bid_Qty { get; set; }
        public Nullable<System.DateTime> BiddingDate { get; set; }
        public string TableVals { get; set; }
        public string UserFullName { get; set; }
        public int? TotalUpdateInfo { get; set; }
        public string Category { get; set; }
    }
}