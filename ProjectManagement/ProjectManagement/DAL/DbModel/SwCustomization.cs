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
    
    public partial class SwCustomization
    {
        public SwCustomization()
        {
            this.SwCustomizationTypes = new HashSet<SwCustomizationType>();
        }
    
        public long SwCustomizationId { get; set; }
        public string CustomizationName { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual ICollection<SwCustomizationType> SwCustomizationTypes { get; set; }
    }
}
