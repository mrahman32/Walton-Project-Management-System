using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.DAL.DbModel;
using ProjectManagement.Models;
using ProjectManagement.Models.AssignModels;
using ProjectManagement.Models.ManagementDashboard;
using ProjectManagement.Models.StausObjects;
using ProjectManagement.ViewModels.Management;

namespace ProjectManagement.Infrastructures.Interfaces
{
    interface IManagementRepository
    {
        ProjectMasterModel GetProjectMasterModel(long id);
        List<ProjectMasterModel> GetInitialApprovalPendingProjectList();
        List<ProjectMasterWithPoCustomModel> GetRunningProjectMasterModelList();
        List<ProjectMasterWithPoCustomModel> GetCompletedProjectMasterModelList();
        string SetProjectMaster(long projectMasterId, string managementComment);
        List<PmQcAssignModel> GetPmQcAssignModels();
        void SetSampleSetApproval(long projectMasterId,string remarks);
        List<HwCmProjectFinalApprovalViewModel> GetHwCmProjectFinalApprovalViewModel();
        void SetHwCmProjectFinalApproval(long projectMasterId, string comment, string approved);
        List<ProjectMasterModel> GetProjectAlive();

        List<tblLocationTrackerMobileNumber> GetAllLocationTrackerEmployee(string network);

        List<LocationTrackerViewModel> GetAllLocationTrackReport(string network, string fromDate, string todate, string ddlPhn);

        List<WorkProgressData> ProjectMonthlyWorkprogress(long projectId);
        List<NotificationModel> GetRecentNotifications();
        List<NotificationModel> GetProjectWiseRecentNotifications(long projectId);
        string GetProjectsCountByIssueOccured();
        string GetProjectsCountByCommentOccured();
        List<PieSlideDataModel> GetIssuesForManagerPieSlide(string projectName, string status);
        long SaveFinalDecision(VmFinalApproval model);
        List<MarketPriceModel> GetMarketPriceModels();
        string SaveMarketPrice(int type, long projectId, decimal price, decimal mul, decimal marketPrice);
        string GetLockedPrice(string pName);
        List<CmStatusObject> GetAllCmStatusObject();
        DateTime? GetLastActionDate(long projectid);
        List<HwQcAssignCustomMasterModel> GetProjectForHwScreeningTestByProjectName(string projectName);
        List<HwQcAssignCustomMasterModel> GetProjectForHwRunningTestByProjectName(string projectName);
        List<HwQcAssignCustomMasterModel> GetProjectForHwFinishedTestByProjectName(string projectName);
        List<SwQcInchargeAssignModel> GetSwQcInchargeAssignByProjectName(string projectName);
        List<ProjectMasterWithPoCustomModel> SpareOrderStatus();
        List<AccessoriesPricesModel> GetAccessoriesPrices(long projectId);
        void ApproveRepeatOrder(long orderId);
        List<ProjectPoFeedbackModel> GetNegativeSourcingPoFeedbacks();
        string SaveManagementDecision(string manCom, string manDec, long id);
       
        #region bidding
        List<Bid_CreateBidModel> GetManagementApprovalPendingBid();
        List<Bid_SparePartsDetailsModel> GetBidderListWithBid(string bidId);
        List<Bid_SparePartsDetailsModel> GetBidderListWithBidPrice(string bidId);
        List<Bid_HandsetDetailsModel> GetDetailsForHandset1(string bidId);
        List<Bid_HandsetDetailsModel> GetDetailsForHandsetPersonWise(string bidId);
        List<Bid_CreateBidModel> GetParticularBid(string bidId);
        List<Bid_SparePartsDetailsModel> GetHeaderPriceDetailsForPerItems(string spareIds);
        List<Bid_SparePartsDetailsModel> GetBiddersPerItems(string bidId, string addedId);
        List<Bid_HandsetDetailsModel> GetPerItemListForHandset(string spareIds);
        List<Bid_HandsetDetailsModel> GetBidderListForHandset(string spareIds, string addedId);
        string MngmtApproveSpareBidderDetails(List<Bid_SparePartsDetailsModel> results);
        #endregion

      
    }
}
