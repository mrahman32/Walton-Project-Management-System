using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Cm_UserInfosForNewPolicyModel
    {
        public long CmnUserId { get; set; }
        public string UserFullName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string EmployeeCode { get; set; }
        public string AssignRoles { get; set; }
        public string ExtendedRoleName { get; set; }

        public int? Share { get; set; }
        public long? CarryAmount { get; set; }
        public Decimal? TotalAmount { get; set; }
        public Decimal? ThisMonthAmount { get; set; }
        public Decimal? TotalDeduction { get; set; }
        public Decimal? TotalDeduction1 { get; set; }
        public Decimal? TotalReward { get; set; }
        public Decimal? PerPersonReward { get; set; }
        public Decimal? PerPersonPenalties { get; set; }
        public Decimal? TotalReward1 { get; set; }
        public Decimal? Reward { get; set; }
        public Decimal? TotalPenalties { get; set; }
        public Decimal? Penalties { get; set; }
        public Decimal? TotalRefund { get; set; }
        public Decimal? TotalRefund1 { get; set; }
        public Decimal? SpecialAmount { get; set; }
        public Decimal? Incentive { get; set; }
        public Decimal? Incentives { get; set; }
        public Decimal? Percentages { get; set; }
        public Decimal? Percentage { get; set; }
        public Decimal? FinalAmount { get; set; }
        public Decimal? TotalIncentive { get; set; }
        public string SpecialRemarks { get; set; }
        public string Remarks { get; set; }
     
    }
}