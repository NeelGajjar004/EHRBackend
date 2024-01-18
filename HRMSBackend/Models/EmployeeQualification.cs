using System;
using System.Collections.Generic;

namespace HRMSBackend.Models
{
    public partial class EmployeeQualification
    {
        public int QualificationId { get; set; }
        public int EmployeeId { get; set; }
        public string QualificationName { get; set; } = null!;
        public string PassingYear { get; set; } = null!;
        public int Cgpa { get; set; }
        public string College { get; set; } = null!;
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
