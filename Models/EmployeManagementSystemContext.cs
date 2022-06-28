using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Employee.Models
{
    public partial class EmployeManagementSystemContext : DbContext
    {
        public EmployeManagementSystemContext()
        {
        }

        public EmployeManagementSystemContext(DbContextOptions<EmployeManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmsCityMaster> EmsCityMasters { get; set; }
        public virtual DbSet<EmsEmployeeMaster> EmsEmployeeMasters { get; set; }
        public virtual DbSet<EMS_GetEmployee> EMS_GetEmployee { get; set; }

        public virtual DbSet<Response> Response { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=EmployeManagementSystem;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EmsCityMaster>(entity =>
            {
                entity.HasKey(e => e.CmId);

                entity.ToTable("EMS_CityMaster");

                entity.Property(e => e.CmId).HasColumnName("CM_ID");

                entity.Property(e => e.CmCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CM_CreatedAt");

                entity.Property(e => e.CmCreatedBy).HasColumnName("CM_CreatedBy");

                entity.Property(e => e.CmModifyAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CM_ModifyAt");

                entity.Property(e => e.CmModifyBy).HasColumnName("CM_ModifyBy");

                entity.Property(e => e.CmName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CM_Name");
            });

            modelBuilder.Entity<EmsEmployeeMaster>(entity =>
            {
                entity.HasKey(e => e.EmId);

                entity.ToTable("EMS_EmployeeMaster");

                entity.Property(e => e.EmId).HasColumnName("EM_ID");

                entity.Property(e => e.EmCity).HasColumnName("EM_City");

                entity.Property(e => e.EmCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("EM_CreatedAt");

                entity.Property(e => e.EmCreatedBy).HasColumnName("EM_CreatedBy");

                entity.Property(e => e.EmDepartment).HasColumnName("EM_Department");

                entity.Property(e => e.EmGender).HasColumnName("EM_Gender");

                entity.Property(e => e.EmModifyAt)
                    .HasColumnType("datetime")
                    .HasColumnName("EM_ModifyAt");

                entity.Property(e => e.EmModifyBy).HasColumnName("EM_ModifyBy");

                entity.Property(e => e.EmName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EM_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
