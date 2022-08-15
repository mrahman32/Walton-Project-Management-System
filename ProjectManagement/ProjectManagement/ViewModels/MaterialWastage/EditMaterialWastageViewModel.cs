using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.DAL.DbModel;
using ProjectManagement.Models;

namespace ProjectManagement.ViewModels.MaterialWastage
{
    public class EditMaterialWastageViewModel
    {
        public MaterialWastageMaster MaterialWastageMaster { get; set; }
        public List<EditMaterialDetail> EditMaterialDetails { get; set; }
        public List<MaterialWastageFileUpload> MaterialWastageFileUploads { get; set; }
        public string RecommendationRemarks { get; set; }
        public string ApprovalRemarks { get; set; }

    }

    public class EditMaterialDetail
    {
        public long MasterId { get; set; }
        public long MaterialTypeId { get; set; }
        public string MaterialTypeName { get; set; }
        public List<MaterialWastageDetail> MaterialWastageDetails { get; set; }
        public double Average1 { get; set; }
        public double Average2 { get; set; }
        public double Average3 { get; set; }
        public double Average4 { get; set; }
    }
}