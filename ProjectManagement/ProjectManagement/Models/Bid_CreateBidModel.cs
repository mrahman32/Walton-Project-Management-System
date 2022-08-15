using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Bid_CreateBidModel
    {
        public Bid_CreateBidModel()
        {
            FilesDetails = new List<FilesDetail>();
            FilesDetails1 = new List<FilesDetail>();
        }
        public List<FilesDetail> FilesDetails { get; set; }
        public List<FilesDetail> FilesDetails1 { get; set; }
        public long Id { get; set; }
        public long BidId { get; set; }
        public long ProjectMasterId { get; set; }
        public string OpeningRemarks { get; set; }
        public string HeadAttachment { get; set; }
        public string BidderAttachment { get; set; }
        public string FinalAttachment { get; set; }
        public string Remarks { get; set; }
        public string BidderNotes { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public decimal? MinimumPrice { get; set; }
        public bool? IsActive { get; set; }
        public long? Added { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AddedDate { get; set; }
        public long? Updated { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? BiddingEndDate { get; set; }
        public List<HttpPostedFileBase> UploderDocs { get; set; }
        public List<HttpPostedFileBase> UploderDocs2 { get; set; }
        public string SupportingDocument { get; set; }
        public string BidName { get; set; }
        public string sCheck { get; set; }
        public string ApproveStatus { get; set; }
        public int? NewLog { get; set; }
        public int? OngoingLog { get; set; }
        public int? CompletedLog { get; set; }
        public int? ReopenedLog { get; set; }
        public decimal? BiddingPrice { get; set; }
        public int? AllNew { get; set; }
        public int? AllReopened { get; set; }
        public int? AllClosed { get; set; }
        public int? AllOngoing { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? ExtendedDate { get; set; }
        public string ExtendedReason { get; set; }
        public string UserFullName { get; set; }
        public int? Closing { get; set; }
        public string CategoryName { get; set; }
        public string Category { get; set; }

        [Required(ErrorMessage = "Please Select Excel File."), RegularExpression(@"([a-zA-Z0-9\s_\\.\-:\+-])+(.xlsx|.xls)$", ErrorMessage = "Only Excel File allowed.")]
        public HttpPostedFileBase ExcelFile { get; set; }
        public int? Bidder_Bid_Qty { get; set; }
        public decimal? BidderPerUnitPrice { get; set; }
        public string BidderRemarks { get; set; }
        public bool checkResp { get; set; }
        public Nullable<System.DateTime> AdminApproveDate { get; set; }
        public Nullable<long> AdminApproveBy { get; set; }
        public Nullable<System.DateTime> ManagementApproveDate { get; set; }
        public Nullable<long> ManagementApproveBy { get; set; }
        public string AdminDeclineRemarks { get; set; }
        public string ManagementDeclineRemarks { get; set; }
        public Nullable<System.DateTime> ManagementDeclineDate { get; set; }
        public Nullable<long> ManagementDeclineBy { get; set; }
        public string ManagementApproveByName { get; set; }
        public string AdminApproveByName { get; set; }
    }
}