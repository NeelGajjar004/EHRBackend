using System;
using System.Collections.Generic;

namespace HRMSBackend.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Attendances = new HashSet<Attendance>();
            EmployeeDocuments = new HashSet<EmployeeDocument>();
            EmployeeExperiences = new HashSet<EmployeeExperience>();
            EmployeeQualifications = new HashSet<EmployeeQualification>();
            LeaveAssigns = new HashSet<LeaveAssign>();
            LeaveTransactions = new HashSet<LeaveTransaction>();
            Leaves = new HashSet<Leaf>();
        }

        public int EmployeeId { get; set; }
        public int EmployeeCode { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime DateofBirth { get; set; }
        public decimal MobileNo { get; set; }
        public string Gender { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public int Pincode { get; set; }
        public string EmailId { get; set; } = null!;
        public string MaritalStatus { get; set; } = null!;
        public DateTime DateofJoining { get; set; }
        public string EmployeeImage { get; set; } = null!;
        public DateTime? ResignDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string? Remark { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<EmployeeDocument> EmployeeDocuments { get; set; }
        public virtual ICollection<EmployeeExperience> EmployeeExperiences { get; set; }
        public virtual ICollection<EmployeeQualification> EmployeeQualifications { get; set; }
        public virtual ICollection<LeaveAssign> LeaveAssigns { get; set; }
        public virtual ICollection<LeaveTransaction> LeaveTransactions { get; set; }
        public virtual ICollection<Leaf> Leaves { get; set; }
    }
}
