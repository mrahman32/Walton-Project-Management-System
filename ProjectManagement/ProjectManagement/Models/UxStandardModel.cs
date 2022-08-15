using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class UxStandardModel
    {
        public UxStandardModel()
        {
            FilesDetails = new List<FilesDetail>();      
        }
        public List<FilesDetail> FilesDetails { get; set; }
        public long Id { get; set; }
        public Nullable<long> SwQcHeadAssignId { get; set; }
        public string StandardRange { get; set; }
        public string Descriptions { get; set; }
        public Nullable<long> OptionId { get; set; }
        public Nullable<long> StandardId { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public string FinalComments { get; set; }
        public string Attachments { get; set; }
        public List<string> AttachmentsList { get; set; }
        public List<HttpPostedFileBase> FileHttpB { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<int> StartRange { get; set; }
        public Nullable<int> EndRange { get; set; }
    }
}