using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.ViewModels.Management
{
    public class LocationTrackerViewModel
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Network { get; set; }
        public string Mobile { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Address { get; set; }
        public DateTime? LocationDate { get; set; }

    }
}