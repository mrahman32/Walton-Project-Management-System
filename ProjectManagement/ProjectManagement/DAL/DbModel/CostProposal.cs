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
    
    public partial class CostProposal
    {
        public long Id { get; set; }
        public long CostMasterId { get; set; }
        public string PriceProposal { get; set; }
        public long ProposedBy { get; set; }
        public System.DateTime ProposedDate { get; set; }
        public Nullable<bool> IsCancelled { get; set; }
        public Nullable<System.DateTime> CancelledDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual CostMaster CostMaster { get; set; }
    }
}
