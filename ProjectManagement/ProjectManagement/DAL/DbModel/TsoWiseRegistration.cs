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
    
    public partial class TsoWiseRegistration
    {
        public long Id { get; set; }
        public Nullable<System.Guid> RegistrationId { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string Model { get; set; }
        public string ImeiOne { get; set; }
        public string ImeiTwo { get; set; }
        public string DealerName { get; set; }
        public string DealerCode { get; set; }
        public string Zone { get; set; }
        public string Division { get; set; }
        public string RSM { get; set; }
        public string RSM_EMP_ID { get; set; }
        public string ASM { get; set; }
        public string ASM_EMP_ID { get; set; }
        public string TSO { get; set; }
        public string TSO_EMP_ID { get; set; }
        public Nullable<System.DateTime> SystemDate { get; set; }
        public string AddedBy { get; set; }
        public string DigitechCode { get; set; }
    }
}