using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HRMSBackend.Models
{
    public partial class UsersTb
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPasword { get; set; } = null!;
    }
}
