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
    
    public partial class tblCashIn
    {
        public System.Guid CashInID { get; set; }
        public System.DateTime CashInDate { get; set; }
        public System.Guid SalesPointID { get; set; }
        public string ReferanceNo { get; set; }
        public System.Guid CashInHeadID { get; set; }
        public decimal ItemQty { get; set; }
        public decimal CashInValue { get; set; }
        public string CurCode { get; set; }
        public string Remark { get; set; }
        public string AddedBy { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual tblSalesPoint tblSalesPoint { get; set; }
        public virtual tblTransectionHead tblTransectionHead { get; set; }
    }
}