using System;
using System.Collections.Generic;

namespace HRMSBackend.Models
{
    public partial class LeaveAssign
    {
        public LeaveAssign()
        {
            LeaveTransactions = new HashSet<LeaveTransaction>();
        }

        public int LeaveAssignId { get; set; }
        public int EmployeeId { get; set; }
        public int NumberOfLeave { get; set; }
        public DateTime AssignDate { get; set; }
        public int Year { get; set; }
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
