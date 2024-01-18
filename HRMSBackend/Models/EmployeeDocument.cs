using System;
using System.Collections.Generic;

namespace HRMSBackend.Models
{
    public partial class EmployeeDocument
    {
        public int EmployeeDocumentId { get; set; }
        public int EmployeeId { get; set; }
        public string Resume { get; set; } = null!;
        public string EmployeeContract { get; set; } = null!;
        public string DegreeCertificate { get; set; } = null!;
        public string AadhaarCard { get; set; } = null!;
        public string PanCard { get; set; } = null!;
        public string BankDetaills { get; set; } = null!;
        public string OtherDocument { get; set; } = null!;
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
