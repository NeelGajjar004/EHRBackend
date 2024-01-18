using System;
using System.Collections.Generic;

namespace HRMSBackend.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public TimeSpan AttendanceTime { get; set; }
        public string AttendanceStatus { get; set; } = null!;
        public int EmployeeId { get; set; }
        public string EnterType { get; set; } = null!;
        public string Remark { get; set; } = null!;
        public int EntryInsertBy { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
