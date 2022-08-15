using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Bid_SparePartsDetailsModel
    {
        public long Id { get; set; }
        public Nullable<long> BidId { get; set; }
        public Nullable<long> SpareIds { get; set; }
        public string Model { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> SalableQty { get; set; }
        public Nullable<decimal> Per_Unit_Price { get; set; }
        public string Admin_Remarks { get; set; }
        public string SQA_Comment { get; set; }
        public string Lock { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public int? TotalRow { get; set; }
        public bool? IsClosed { get; set; }
        public bool? IsActive { get; set; }
        public string ApproveStatus { get; set; }
        public string BidderRemarks { get; set; }
        public decimal? BidderPerUnitPrice { get; set; }
        public int? Bidder_Bid_Qty { get; set; }
        public Nullable<System.DateTime> BiddingDate { get; set; }
        public Nullable<System.DateTime> BidCreationDate { get; set; }
        public string UserFullName { get; set; }
        public string EmployeeCode { get; set; }
        public string TableVals { get; set; }
        public int? TotalUpdateInfo { get; set; }
        public string Category { get; set; }
    }
}