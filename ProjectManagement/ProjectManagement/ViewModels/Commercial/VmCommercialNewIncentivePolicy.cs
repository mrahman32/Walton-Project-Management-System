using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.DAL.DbModel;
using ProjectManagement.Models;

namespace ProjectManagement.ViewModels.Commercial
{
    public class VmCommercialNewIncentivePolicy
    {
        public VmCommercialNewIncentivePolicy()
        {
            Cm_MaterialReorderAndSupportModels = new List<Cm_MaterialReorderAndSupportModel>();
            Cm_MaterialReorderAndSupportModel = new Cm_MaterialReorderAndSupportModel();
            Cm_SpareArrangementAndSupportModels = new List<Cm_SpareArrangementAndSupportModel>();
            Cm_SpareArrangementAndSupportModel = new Cm_SpareArrangementAndSupportModel();
            Cm_ReportAnalysisModels = new List<Cm_ReportAnalysisModel>();
            Cm_ReportAnalysisModel = new Cm_ReportAnalysisModel();
            Cm_NegotiationsAndDevelopmentModel=new Cm_NegotiationsAndDevelopmentModel();
            Cm_NegotiationsAndDevelopmentModels=new List<Cm_NegotiationsAndDevelopmentModel>();
            Cm_PenaltiesModel=new Cm_PenaltiesModel();
            Cm_PenaltiesModels=new List<Cm_PenaltiesModel>();
            Cm_MaterialShipmentAndConsumableItemsModels = new List<Cm_MaterialShipmentAndConsumableItemsModel>();
            Cm_MaterialShipmentAndConsumableItemsModel = new Cm_MaterialShipmentAndConsumableItemsModel();
            Cm_TotalPoLcAndTtModels = new List<Cm_TotalPoLcAndTtModel>();
            Cm_TotalPoLcAndTtModel = new Cm_TotalPoLcAndTtModel();
            Cm_UserInfosForNewPolicyModels=new List<Cm_UserInfosForNewPolicyModel>();
            Cm_UserInfosForNewPolicyModel=new Cm_UserInfosForNewPolicyModel();
            Cm_UserInfosForNewPolicyModels2 = new List<Cm_UserInfosForNewPolicyModel>();
            Cm_UserInfosForNewPolicyModel2 = new Cm_UserInfosForNewPolicyModel();
        }

        public List<Cm_MaterialReorderAndSupportModel> Cm_MaterialReorderAndSupportModels { get; set; }
        public Cm_MaterialReorderAndSupportModel Cm_MaterialReorderAndSupportModel { get; set; }
        public List<Cm_SpareArrangementAndSupportModel> Cm_SpareArrangementAndSupportModels { get; set; }
        public Cm_SpareArrangementAndSupportModel Cm_SpareArrangementAndSupportModel { get; set; }
        public List<Cm_ReportAnalysisModel> Cm_ReportAnalysisModels { get; set; }
        public Cm_ReportAnalysisModel Cm_ReportAnalysisModel { get; set; }
        public List<Cm_NegotiationsAndDevelopmentModel> Cm_NegotiationsAndDevelopmentModels { get; set; }
        public Cm_NegotiationsAndDevelopmentModel Cm_NegotiationsAndDevelopmentModel { get; set; }
        public List<Cm_PenaltiesModel> Cm_PenaltiesModels { get; set; }
        public Cm_PenaltiesModel Cm_PenaltiesModel { get; set; }
        public Cm_MaterialShipmentAndConsumableItemsModel Cm_MaterialShipmentAndConsumableItemsModel { get;  set; }
        public List<Cm_MaterialShipmentAndConsumableItemsModel> Cm_MaterialShipmentAndConsumableItemsModels { get;  set; }
        public List<Cm_TotalPoLcAndTtModel> Cm_TotalPoLcAndTtModels { get; set; }
        public Cm_TotalPoLcAndTtModel Cm_TotalPoLcAndTtModel { get; set; }
        public Cm_UserInfosForNewPolicyModel Cm_UserInfosForNewPolicyModel { get;  set; }
        public List<Cm_UserInfosForNewPolicyModel> Cm_UserInfosForNewPolicyModels { get;  set; }

        public Cm_UserInfosForNewPolicyModel Cm_UserInfosForNewPolicyModel2 { get; set; }
        public List<Cm_UserInfosForNewPolicyModel> Cm_UserInfosForNewPolicyModels2 { get; set; }

        public string Category { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        //

     
    }
}