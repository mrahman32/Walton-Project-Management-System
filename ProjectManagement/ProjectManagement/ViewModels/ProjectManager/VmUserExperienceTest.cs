using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.Models;
using ProjectManagement.Models.AssignModels;

namespace ProjectManagement.ViewModels.ProjectManager
{
    public class VmUserExperienceTest
    {
        public VmUserExperienceTest()
        {
            UxDetailsInfoModels=new List<UxDetailsInfoModel>();
            UxDetailsInfoModel=new UxDetailsInfoModel();
            UxStandardModel=new UxStandardModel();
            UxStandardModels=new List<UxStandardModel>();
            UxStandardModel1 = new UxStandardModel();
            UxStandardModels1 = new List<UxStandardModel>();
            PmQcAssignModels = new List<PmQcAssignModel>();
            PmQcAssignModel = new PmQcAssignModel();
        }

        public List<PmQcAssignModel> PmQcAssignModels { get; set; }
        public PmQcAssignModel PmQcAssignModel { get; set; }

        public List<UxDetailsInfoModel> UxDetailsInfoModels { get; set; }
        public UxDetailsInfoModel UxDetailsInfoModel { get; set; }
        public List<UxStandardModel> UxStandardModels { get; set; }
        public UxStandardModel UxStandardModel { get; set; }
        public List<UxStandardModel> UxStandardModels1 { get; set; }
        public UxStandardModel UxStandardModel1 { get; set; }
        public long SwQcHeadAssignId { get; set; }

        //
        public string ProjectName { get; set; }
        public string FinalComments { get; set; }
        public string Attachments { get; set; }
        public List<string> AttachmentsList { get; set; }
        public List<HttpPostedFileBase> FileHttpB { get; set; }
        public long Id { get; set; }  
        public Nullable<long> OptionId { get; set; }
        public Nullable<long> StandardId { get; set; }
        public Nullable<long> ProjectMasterId { get; set; }
    }
}