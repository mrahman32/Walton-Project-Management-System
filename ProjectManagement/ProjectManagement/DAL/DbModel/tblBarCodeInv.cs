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
    
    public partial class tblBarCodeInv
    {
        public System.Guid RecID { get; set; }
        public System.DateTime PrintDate { get; set; }
        public string ProductType { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string BarCode { get; set; }
        public string BarCode2 { get; set; }
        public string DelieveredTo { get; set; }
        public bool PrintSuccess { get; set; }
        public string AddedBy { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string Updatedby { get; set; }
        public string DateUpdated { get; set; }
        public string Grade { get; set; }
        public string GradeReason { get; set; }
    }
}
