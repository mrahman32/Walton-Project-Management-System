using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OfficeOpenXml.FormulaParsing.Utilities;
using ProjectManagement.DAL.DbModel;

namespace ProjectManagement.Models
{
    public class MaterialWasterReportCreateModel
    {
        [Required]
        public string ReportName { get; set; }
        [Required]
        public int MonthNumber { get; set; }
        public string MonthName { get; set; }
        [Required]
        public int YearNumber { get; set; }
        [Required]
        public List<MaterialWastageFileUpload> MaterialWastageFileUploads { get; set; }
    }

    public class MaterialWastageFileUpload
    {
        [Required]
        public long MaterialTypeId { get; set; }
        [Required]
        public string MaterialTypeName { get; set; }
        [Required]
        public HttpPostedFileBase HttpPostedFileBase { get; set; }

        public List<MaterialWastageItemType> MaterialWastageItemTypes { get; set; }
    }
}