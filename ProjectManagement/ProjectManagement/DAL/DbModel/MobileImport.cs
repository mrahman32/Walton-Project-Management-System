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
    
    public partial class MobileImport
    {
        public int MobileImportId { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public string Port { get; set; }
        public Nullable<System.DateTime> LandDate { get; set; }
        public Nullable<System.DateTime> PayDate { get; set; }
        public string Qty { get; set; }
        public string Value { get; set; }
        public string CD { get; set; }
        public string VAT { get; set; }
        public string AIT { get; set; }
        public string TotalDuty { get; set; }
        public string AvgValueBdt { get; set; }
        public string AvgValueUsd { get; set; }
        public string AvgMktValue { get; set; }
        public string ValueSagnment25P { get; set; }
        public string ValueSagnment50P { get; set; }
        public string ValueSagnment100P { get; set; }
    }
}