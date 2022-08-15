using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class ProjectForecastingInfoModel
    {
        public long Id { get; set; }
        public long ProjectMasterId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> LaunchDate { get; set; }
        public string Plc { get; set; }
        public string Brand { get; set; }
        public string FSegment { get; set; }
        public Nullable<decimal> Display { get; set; }
        public string Battery { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Nullable<decimal> Fob { get; set; }
        public Nullable<long> January { get; set; }
        public Nullable<long> February { get; set; }
        public Nullable<long> March { get; set; }
        public Nullable<long> April { get; set; }
        public Nullable<long> May { get; set; }
        public Nullable<long> June { get; set; }
        public Nullable<long> July { get; set; }
        public Nullable<long> August { get; set; }
        public Nullable<long> September { get; set; }
        public Nullable<long> October { get; set; }
        public Nullable<long> November { get; set; }
        public Nullable<long> December { get; set; }
        public Nullable<long> TotalSum { get; set; }
        public Nullable<long> Added { get; set; }
        public DateTime? AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<long> LogAdded { get; set; }
        public Nullable<System.DateTime> LogAddedDate { get; set; }
        public Nullable<long> Quantity { get; set; }
        public Nullable<long> BDStock { get; set; }
        public Nullable<long> OpenPo { get; set; }
        public Nullable<long> TTL { get; set; }
        public string Model { get; set; }
    }
}