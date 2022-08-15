using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class UxDetailsInfoModel
    {
        public long? Id { get; set; }
        public Nullable<long> SwQcHeadAssignId { get; set; }
        public long? OptionId1 { get; set; }
        public Nullable<long> OptionId { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
        public Nullable<int> StandardPoint { get; set; }
        public string ProjectName { get; set; }
        public string Orders { get; set; }
        public string Options { get; set; }
        public Nullable<decimal> ObtainedPoint { get; set; }
        public string Remarks { get; set; }
        public string Minor { get; set; }
        public string Major { get; set; }
        public string Critical { get; set; }

        public bool Minor1 { get; set; }
        public bool Major1 { get; set; }
        public bool Critical1 { get; set; }
        public bool Minor2 { get; set; }
        public bool Major2 { get; set; }
        public bool Critical2 { get; set; }
        public string StandardRange { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}