using System;
using System.Collections.Generic;

namespace HRMSBackend.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int DepartmentCode { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
