using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Bid_BidderAttachmentModel
    {
        public Bid_BidderAttachmentModel()
        {
            FilesDetails = new List<FilesDetail>();
            FilesDetails1 = new List<FilesDetail>();
        }
        public List<FilesDetail> FilesDetails { get; set; }
        public List<FilesDetail> FilesDetails1 { get; set; }
        public long Id { get; set; }
        public string BidderAttachment { get; set; }
        public string FinalAttachment { get; set; }
        public string UserFullName { get; set; }
        public Nullable<long> Added { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<long> BidId { get; set; }
    }
}