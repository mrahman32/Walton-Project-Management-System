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
    
    public partial class Bid_BidderPriceDetails
    {
        public long Id { get; set; }
        public Nullable<long> BidId { get; set; }
        public Nullable<long> HeaderDetailsId { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public Nullable<decimal> MinimumPrice { get; set; }
        public string Note { get; set; }
        public Nullable<decimal> BiddingPrice { get; set; }
        public string BidderNotes { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string ApproveStatus { get; set; }
        public Nullable<bool> IsClosed { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}