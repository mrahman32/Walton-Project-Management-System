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
    
    public partial class tblSalesPointDailyStock
    {
        public System.Guid DailyStockID { get; set; }
        public System.Guid SalesPointID { get; set; }
        public System.DateTime StockDeclDate { get; set; }
        public System.Guid ProductID { get; set; }
        public int StockQty { get; set; }
        public string AddedBy { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual tblSalesPoint tblSalesPoint { get; set; }
        public virtual tblTransectionHead tblTransectionHead { get; set; }
    }
}
