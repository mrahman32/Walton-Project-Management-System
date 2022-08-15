//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagement.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class AfterServiceReplacement
    {
        public long AfterServiceRepID { get; set; }
        public Nullable<long> ServiceID { get; set; }
        public string ServicePointName { get; set; }
        public string IME { get; set; }
        public string Model { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public Nullable<System.DateTime> ServicePlaceDate { get; set; }
        public string DealerName { get; set; }
        public string CustomerMobile { get; set; }
        public Nullable<bool> PermissionFromCoOrdinator { get; set; }
        public string RepalcementCause { get; set; }
        public string ServiceInchargeComment { get; set; }
        public Nullable<bool> WarrantyAvailability { get; set; }
        public string Invoice { get; set; }
        public Nullable<decimal> FaultyHandetPrice { get; set; }
        public Nullable<decimal> FaultyHandsetPriceByPlaza { get; set; }
        public Nullable<decimal> NewHandsetPrice { get; set; }
        public Nullable<decimal> DepricationRate { get; set; }
        public Nullable<decimal> AcceptFromCustomer { get; set; }
        public string NewHandsetIMEI { get; set; }
        public string NewHandsetModel { get; set; }
        public string ReplacementGivenBy { get; set; }
        public string CreatedBy { get; set; }
        public string WastageStatus { get; set; }
        public string WastageRemarks { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}