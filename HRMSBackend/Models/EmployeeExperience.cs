using System;
using System.Collections.Generic;

namespace HRMSBackend.Models
{
    public partial class EmployeeExperience
    {
        public int ExperienceId { get; set; }
        public int EmployeeId { get; set; }
        public string Designation { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int LastSalary { get; set; }
        public string LastWorkDuration { get; set; } = null!;
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
