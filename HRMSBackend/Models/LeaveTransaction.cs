using System;
using System.Collections.Generic;

namespace HRMSBackend.Models
{
    public partial class LeaveTransaction
    {
        public int LeaveTransactionId { get; set; }
        public int LeavesId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime LeaveDate { get; set; }
        public string TransactionType { get; set; } = null!;
        public string Remark { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int Year { get; set; }
        public int LeaveAssignId { get; set; }
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual LeaveAssign LeaveAssign { get; set; } = null!;
        public virtual Leaf Leaves { get; set; } = null!;
    }
}
