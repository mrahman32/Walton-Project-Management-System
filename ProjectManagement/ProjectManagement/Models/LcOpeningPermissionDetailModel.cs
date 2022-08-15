using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class LcOpeningPermissionDetailModel
    {
        public long Id { get; set; }
        public Nullable<long> PermissionId { get; set; }
        public Nullable<long> ProjectId { get; set; }
        public string OraclePoNo { get; set; }
        public string OracleLcNo { get; set; }
        public Nullable<System.DateTime> OpeningDate { get; set; }
        public Nullable<System.DateTime> BankOpeningDate { get; set; }
        public Nullable<System.DateTime> SupplierDraftDate { get; set; }
        public Nullable<System.DateTime> LcPassDate { get; set; }
        public Nullable<System.DateTime> SampleSendDate { get; set; }
        public Nullable<System.DateTime> BtrcNocDate { get; set; }
        public Nullable<System.DateTime> NocReceiveDate { get; set; }
        public Nullable<decimal> LcValue { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> BdtLcAmount { get; set; }
        public Nullable<bool> IsComplete { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}