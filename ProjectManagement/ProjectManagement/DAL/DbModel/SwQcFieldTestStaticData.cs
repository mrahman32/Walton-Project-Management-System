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
    
    public partial class SwQcFieldTestStaticData
    {
        public long Id { get; set; }
        public string OperatorName { get; set; }
        public string Operator { get; set; }
        public string FrequencyBand { get; set; }
        public string TestName { get; set; }
        public string TestCategory { get; set; }
        public string TestDuration { get; set; }
        public string TestFocus1 { get; set; }
        public string TestFocus2 { get; set; }
        public string TestFocus3 { get; set; }
        public string NumberOfCalls { get; set; }
        public string Location { get; set; }
        public string SpeedLimit { get; set; }
        public string TRssiBars { get; set; }
        public string TCallDrop { get; set; }
        public string TNoiseInterference { get; set; }
        public string TLongMute { get; set; }
        public string BRssiBars { get; set; }
        public string BCallDrop { get; set; }
        public string BNoiseInterference { get; set; }
        public string BLongMute { get; set; }
        public string Pass { get; set; }
        public string Fail { get; set; }
        public string TestPhaseName { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
