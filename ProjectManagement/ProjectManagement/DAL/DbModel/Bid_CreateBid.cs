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
    
    public partial class Bid_CreateBid
    {
        public long Id { get; set; }
        public string BidName { get; set; }
        public string Category { get; set; }
        public string OpeningRemarks { get; set; }
        public string HeadAttachment { get; set; }
        public string FinalAttachment { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> AdminApproveDate { get; set; }
        public Nullable<long> AdminApproveBy { get; set; }
        public Nullable<System.DateTime> ManagementApproveDate { get; set; }
        public Nullable<long> ManagementApproveBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> BiddingEndDate { get; set; }
        public string AdminDeclineRemarks { get; set; }
        public string ManagementDeclineRemarks { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<System.DateTime> ManagementDeclineDate { get; set; }
        public Nullable<long> ManagementDeclineBy { get; set; }
    }
}
