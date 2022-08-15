using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.DAL.DbModel;
using ProjectManagement.Models;

namespace ProjectManagement.ViewModels.AftersalesPm
{
    public class VmIssueVerification
    {
        public VmIssueVerification()
        {
            ProjectMasterModels=new List<ProjectMasterModel>();
            ProjectMasterModel=new ProjectMasterModel();
            AftersalesPmIssueVerificationModels=new List<AftersalesPm_IssueVerificationModel>();
            AftersalesPmIssueVerificationModel=new AftersalesPm_IssueVerificationModel();
            AftersalesPmIssueVerificationStatusLogModel=new AftersalesPm_IssueVerificationStatusLogModel();
            AftersalesPmIssueVerificationStatusLogModels=new List<AftersalesPm_IssueVerificationStatusLogModel>();
            AftersalesPmHwIssueVerificationModel=new AftersalesPm_HwIssueVerificationModel();
            AftersalesPmHwIssueVerificationModels=new List<AftersalesPm_HwIssueVerificationModel>();
            AftersalesPm_HwIssuePlaceRequirements=new List<AftersalesPm_HwIssuePlaceRequirement>();
            AftersalesPm_HwIssuePlaceRequirement=new AftersalesPm_HwIssuePlaceRequirement();
            AftersalesPm_HwIssueVerificationLogModel = new AftersalesPm_HwIssueVerificationLogModel();
            AftersalesPm_HwIssueVerificationLogModels = new List<AftersalesPm_HwIssueVerificationLogModel>();
            AftersalesPm_HwIssueReportShareModel = new AftersalesPm_HwIssueReportShareModel();
            AftersalesPm_HwIssueReportShareModels = new List<AftersalesPm_HwIssueReportShareModel>();
        }
        public long ProjectMasterId { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectMasterModel> ProjectMasterModels { get; set; } 
        public ProjectMasterModel ProjectMasterModel { get; set; } 
        public List<AftersalesPm_IssueVerificationModel> AftersalesPmIssueVerificationModels { get; set; }  
        public AftersalesPm_IssueVerificationModel AftersalesPmIssueVerificationModel{ get; set; } 
        public AftersalesPm_IssueVerificationStatusLogModel AftersalesPmIssueVerificationStatusLogModel { get; set; } 
        public List<AftersalesPm_IssueVerificationStatusLogModel> AftersalesPmIssueVerificationStatusLogModels { get; set; } 
        public List<AftersalesPm_HwIssueVerificationModel> AftersalesPmHwIssueVerificationModels { get; set; } 
        public AftersalesPm_HwIssueVerificationModel AftersalesPmHwIssueVerificationModel { get; set; }
        public AftersalesPm_HwIssuePlaceRequirement AftersalesPm_HwIssuePlaceRequirement { get; set; } 
        public List<AftersalesPm_HwIssuePlaceRequirement> AftersalesPm_HwIssuePlaceRequirements { get; set; }

        public List<AftersalesPm_HwIssueVerificationLogModel> AftersalesPm_HwIssueVerificationLogModels { get; set; }
        public AftersalesPm_HwIssueVerificationLogModel AftersalesPm_HwIssueVerificationLogModel { get; set; }
        public List<AftersalesPm_HwIssueReportShareModel> AftersalesPm_HwIssueReportShareModels { get; set; }
        public AftersalesPm_HwIssueReportShareModel AftersalesPm_HwIssueReportShareModel { get; set; }
    }
}