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
    
    public partial class ProjectPrice
    {
        public long ProjectPriceId { get; set; }
        public long ProjectMasterId { get; set; }
        public decimal Price { get; set; }
        public System.DateTime PriceDate { get; set; }
        public string PriceStage { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual ProjectMaster ProjectMaster { get; set; }
    }
}
