using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.DAL.DbModel;
using ProjectManagement.Models;
using ProjectManagement.ViewModels;
using ProjectManagement.ViewModels.MaterialWastage;

namespace ProjectManagement.Infrastructures.Interfaces
{
    public interface IMaterialWastageRepository
    {
        bool GetMaterialWastageReportByMonthAndYear(int monthNumber, int yearNumber, long itemTypeId);
        MaterialWastageReportTopSheetViewModel GetMaterailWastageTopSheet(long id);
        List<MaterialWastageItemType> GetMaterialWastageItemType();
        string DeleteBulkMaterialFromExistingReport(long reportMasterId, long materialTypeId);
        ResponseModel AddNewFileToExistingReport(EditMaterialWastageViewModel model);
    }
}
