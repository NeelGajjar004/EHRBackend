using System;
using System.Collections.Generic;

namespace HRMSBackend.Models
{
    public partial class Leaf
    {
        public Leaf()
        {
            LeaveTransactions = new HashSet<LeaveTransaction>();
        }

        public int LeavesId { get; set; }
        public int EmployeeId { get; set; }
        public string Reason { get; set; } = null!;
        public DateTime LeaveFromDate { get; set; }
        public DateTime LeaveToDate { get; set; }
        public string Remark { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int StatusBy { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<LeaveTransaction> LeaveTransactions { get; set; }
    }
}
