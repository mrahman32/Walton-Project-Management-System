using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.DAL.DbModel;
using ProjectManagement.Models;

namespace ProjectManagement.ViewModels.Hardware
{
    public class VmAftersalesPmHwIssueVerification
    {
        public VmAftersalesPmHwIssueVerification ()
        {
            AftersalesPmHwIssueVerificationModel = new AftersalesPm_HwIssueVerificationModel();
            AftersalesPmHwIssueVerificationModels = new List<AftersalesPm_HwIssueVerificationModel>();
            AftersalesPm_HwIssuePlaceRequirementModel=new AftersalesPm_HwIssuePlaceRequirementModel();
            AftersalesPm_HwIssuePlaceRequirementModels=new List<AftersalesPm_HwIssuePlaceRequirementModel>();
            AftersalesPm_HwIssueReportShareModel=new AftersalesPm_HwIssueReportShareModel();
            AftersalesPm_HwIssueReportShareModels=new List<AftersalesPm_HwIssueReportShareModel>();
        }
        public List<AftersalesPm_HwIssueVerificationModel> AftersalesPmHwIssueVerificationModels { get; set; }
        public AftersalesPm_HwIssueVerificationModel AftersalesPmHwIssueVerificationModel { get; set; }

        public List<AftersalesPm_HwIssuePlaceRequirementModel> AftersalesPm_HwIssuePlaceRequirementModels { get; set; }
        public AftersalesPm_HwIssuePlaceRequirementModel AftersalesPm_HwIssuePlaceRequirementModel { get; set; }
        public List<AftersalesPm_HwIssueReportShareModel> AftersalesPm_HwIssueReportShareModels { get; set; }
        public AftersalesPm_HwIssueReportShareModel AftersalesPm_HwIssueReportShareModel { get; set; }
    }
}