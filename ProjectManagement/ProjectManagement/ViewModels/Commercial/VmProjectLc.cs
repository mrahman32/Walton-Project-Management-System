using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.DAL.DbModel;
using ProjectManagement.Models;

namespace ProjectManagement.ViewModels.Commercial
{
    public class VmProjectLc
    {
        public VmProjectLc()
        {
            ProjectMasterModel = new ProjectMasterModel();
            ProjectLcModel = new ProjectLcModel();
            PermissionModel=new LcOpeningPermissionModel();
            LcOpeningPermissionFileModels=new List<LcOpeningPermissionFileModel>();
            LcOpeningPermissionFileModel=new LcOpeningPermissionFileModel();
            LcOpeningPermissionModel=new LcOpeningPermissionModel();
            LcOpeningPermissionDetailModel = new LcOpeningPermissionDetailModel();
        }
        public ProjectMasterModel ProjectMasterModel { get; set; }
        public ProjectLcModel ProjectLcModel { get; set; }
        public string PoNumber { get; set; }
        public bool Lc1 { get; set; }
        public bool Lc2 { get; set; }
        public LcOpeningPermissionModel PermissionModel { get; set; }
        public List<LcOpeningPermissionFileModel> LcOpeningPermissionFileModels { get; set; }
        public LcOpeningPermissionFileModel LcOpeningPermissionFileModel { get; set; }
        public LcOpeningPermissionModel LcOpeningPermissionModel { get; set; }
        public LcOpeningPermissionDetailModel LcOpeningPermissionDetailModel { get; set; }
        public List<LcOpeningPermissionDetailModel> LcOpeningPermissionDetailModels { get; set; } 
    }
}