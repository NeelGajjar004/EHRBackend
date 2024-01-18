using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRMSBackend.Models
{
    public partial class HumanResourceManagementContext : DbContext
    {
        public HumanResourceManagementContext()
        {
        }

        public HumanResourceManagementContext(DbContextOptions<HumanResourceManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Designation> Designations { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeDocument> EmployeeDocuments { get; set; } = null!;
        public virtual DbSet<EmployeeExperience> EmployeeExperiences { get; set; } = null!;
        public virtual DbSet<EmployeeQualification> EmployeeQualifications { get; set; } = null!;
        public virtual DbSet<Leaf> Leaves { get; set; } = null!;
        public virtual DbSet<LeaveAssign> LeaveAssigns { get; set; } = null!;
        public virtual DbSet<LeaveTransaction> LeaveTransactions { get; set; } = null!;
        public virtual DbSet<UsersTb> UsersTbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NEEL;Initial Catalog=HumanResourceManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.AttendanceId).HasColumnName("attendanceID");

                entity.Property(e => e.AttendanceDate)
                    .HasColumnType("date")
                    .HasColumnName("attendanceDate");

                entity.Property(e => e.AttendanceStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("attendanceStatus");

                entity.Property(e => e.AttendanceTime).HasColumnName("attendanceTime");

                entity.Property(e => e.DeleteDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EnterType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("enterType");

                entity.Property(e => e.EntryInsertBy).HasColumnName("entryInsertBy");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("remark");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendance_Employee");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentID");

                entity.Property(e => e.DeleteDate).HasColumnType("date");

                entity.Property(e => e.DepartmentCode).HasColumnName("departmentCode");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("departmentName");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.UpdateDate).HasColumnType("date");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("Designation");

                entity.Property(e => e.DesignationId).HasColumnName("designationID");

                entity.Property(e => e.DeleteDate).HasColumnType("date");

                entity.Property(e => e.DesignationCode).HasColumnName("designationCode");

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("designationName");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.UpdateDate).HasColumnType("date");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.DateofBirth)
                    .HasColumnType("date")
                    .HasColumnName("dateofBirth");

                entity.Property(e => e.DateofJoining)
                    .HasColumnType("date")
                    .HasColumnName("dateofJoining");

                entity.Property(e => e.DeleteDate).HasColumnType("date");

                entity.Property(e => e.Department).HasColumnName("Department");

                entity.Property(e => e.Designation).HasColumnName("Designation");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailID");

                entity.Property(e => e.EmployeeCode).HasColumnName("employeeCode");

                entity.Property(e => e.EmployeeImage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employeeImage");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.LeaveDate)
                    .HasColumnType("date")
                    .HasColumnName("leaveDate");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("maritalStatus");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("middleName");

                entity.Property(e => e.MobileNo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("mobileNo");

                entity.Property(e => e.Pincode).HasColumnName("pincode");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("remark");

                entity.Property(e => e.ResignDate)
                    .HasColumnType("date")
                    .HasColumnName("resignDate");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.UpdateDate).HasColumnType("date");
                
            });

            modelBuilder.Entity<EmployeeDocument>(entity =>
            {
                entity.ToTable("EmployeeDocument");

                entity.Property(e => e.EmployeeDocumentId).HasColumnName("employeeDocumentID");

                entity.Property(e => e.AadhaarCard)
                    .HasColumnType("text")
                    .HasColumnName("aadhaarCard");

                entity.Property(e => e.BankDetaills)
                    .HasColumnType("text")
                    .HasColumnName("bankDetaills");

                entity.Property(e => e.DegreeCertificate)
                    .HasColumnType("text")
                    .HasColumnName("degreeCertificate");

                entity.Property(e => e.DeleteDate).HasColumnType("date");

                entity.Property(e => e.EmployeeContract)
                    .HasColumnType("text")
                    .HasColumnName("employeeContract");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.OtherDocument)
                    .HasColumnType("text")
                    .HasColumnName("otherDocument");

                entity.Property(e => e.PanCard)
                    .HasColumnType("text")
                    .HasColumnName("panCard");

                entity.Property(e => e.Resume)
                    .HasColumnType("text")
                    .HasColumnName("resume");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDocuments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeDocument_Employee");
            });

            modelBuilder.Entity<EmployeeExperience>(entity =>
            {
                entity.HasKey(e => e.ExperienceId);

                entity.ToTable("EmployeeExperience");

                entity.Property(e => e.ExperienceId).HasColumnName("experienceID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("companyName");

                entity.Property(e => e.DeleteDate).HasColumnType("date");

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("designation");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("fromDate");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.LastSalary).HasColumnName("lastSalary");

                entity.Property(e => e.LastWorkDuration)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastWorkDuration");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("toDate");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeExperiences)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeExperience_Employee");
            });

            modelBuilder.Entity<EmployeeQualification>(entity =>
            {
                entity.HasKey(e => e.QualificationId);

                entity.ToTable("EmployeeQualification");

                entity.Property(e => e.QualificationId).HasColumnName("qualificationID");

                entity.Property(e => e.Cgpa).HasColumnName("CGPA");

                entity.Property(e => e.College)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.PassingYear)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passingYear");

                entity.Property(e => e.QualificationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("qualificationName");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeQualifications)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeQualification_Employee");
            });

            modelBuilder.Entity<Leaf>(entity =>
            {
                entity.HasKey(e => e.LeavesId);

                entity.Property(e => e.LeavesId).HasColumnName("leavesID");

                entity.Property(e => e.DeleteDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.LeaveFromDate)
                    .HasColumnType("date")
                    .HasColumnName("leaveFromDate");

                entity.Property(e => e.LeaveToDate)
                    .HasColumnType("date")
                    .HasColumnName("leaveToDate");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("reason");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("remark");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.StatusBy).HasColumnName("statusBy");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Leaves_Employee");
            });

            modelBuilder.Entity<LeaveAssign>(entity =>
            {
                entity.ToTable("LeaveAssign");

                entity.Property(e => e.LeaveAssignId).HasColumnName("leaveAssignID");

                entity.Property(e => e.AssignDate)
                    .HasColumnType("date")
                    .HasColumnName("assignDate");

                entity.Property(e => e.DeleteDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.NumberOfLeave).HasColumnName("numberOfLeave");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveAssigns)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeaveAssign_Employee");
            });

            modelBuilder.Entity<LeaveTransaction>(entity =>
            {
                entity.ToTable("LeaveTransaction");

                entity.Property(e => e.LeaveTransactionId).HasColumnName("leaveTransactionID");

                entity.Property(e => e.DeleteDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.LeaveAssignId).HasColumnName("LeaveAssignID");

                entity.Property(e => e.LeaveDate)
                    .HasColumnType("date")
                    .HasColumnName("leaveDate");

                entity.Property(e => e.LeavesId).HasColumnName("LeavesID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("remark");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("transactionType");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveTransactions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeaveTransaction_Employee");

                entity.HasOne(d => d.LeaveAssign)
                    .WithMany(p => p.LeaveTransactions)
                    .HasForeignKey(d => d.LeaveAssignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeaveTransaction_LeaveAssign");

                entity.HasOne(d => d.Leaves)
                    .WithMany(p => p.LeaveTransactions)
                    .HasForeignKey(d => d.LeavesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeaveTransaction_Leaves");
            });

            modelBuilder.Entity<UsersTb>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UsersTB");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPasword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userPasword");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
