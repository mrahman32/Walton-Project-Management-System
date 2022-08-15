using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.Models;

namespace ProjectManagement.ViewModels.Commercial
{

    public class VmProjectForecasting
    {
        public VmProjectForecasting()
        {
            ProjectForecastingInfoModels=new List<ProjectForecastingInfoModel>();
            ProjectForecastingInfoModels2=new List<ProjectForecastingInfoModel>();
            ProjectForecastingInfoModel=new ProjectForecastingInfoModel();
            ProjectForecastingInfoModel2=new ProjectForecastingInfoModel();
            ProjectMasterModels=new List<ProjectMasterModel>();
            ProjectMasterModel=new ProjectMasterModel();
        }
        public List<ProjectMasterModel> ProjectMasterModels { get; set; } 
        public ProjectMasterModel ProjectMasterModel{ get; set; } 
        public List<ProjectForecastingInfoModel> ProjectForecastingInfoModels { get; set; }
        public List<ProjectForecastingInfoModel> ProjectForecastingInfoModels2 { get; set; }
        public ProjectForecastingInfoModel ProjectForecastingInfoModel { get; set; }
        public ProjectForecastingInfoModel ProjectForecastingInfoModel2 { get; set; }
        public long Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public Nullable<System.DateTime> LaunchDate { get; set; }
        public string Plc { get; set; }
        public string Brand { get; set; }
        public string FSegment { get; set; }
        public Nullable<decimal> Display { get; set; }
        public string Battery { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
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
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}