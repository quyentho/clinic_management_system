using clinic.BusinessDomain.Statistic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace clinic
{
    public partial class clinicEntities : DbContext
    {
        public clinicEntities()
            : base("name=clinicEntities")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<clinic_service> clinic_service { get; set; }
        public virtual DbSet<medicine> medicines { get; set; }
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<permission> permissions { get; set; }
        public virtual DbSet<prescription> prescriptions { get; set; }
        public virtual DbSet<staff> staffs { get; set; }
        public virtual DbSet<ServiceStatistic> ServiceStatistics { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<bill>()
                .HasMany(e => e.prescriptions)
                .WithRequired(e => e.bill)
                .HasForeignKey(e => e.bill_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bill>()
                .HasMany(e => e.clinic_service)
                .WithMany(e => e.bills)
                .Map(m => m.ToTable("services_in_bill").MapLeftKey("bills_id"));

            modelBuilder.Entity<medicine>()
                .HasMany(e => e.prescriptions)
                .WithRequired(e => e.medicine)
                .HasForeignKey(e => e.medicine_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .HasMany(e => e.bills)
                .WithRequired(e => e.patient)
                .HasForeignKey(e => e.patient_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<permission>()
                .HasMany(e => e.accounts)
                .WithRequired(e => e.permission)
                .HasForeignKey(e => e.permission_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<permission>()
                .HasMany(e => e.staffs)
                .WithRequired(e => e.permission)
                .HasForeignKey(e => e.permission_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.accounts)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.staff_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.bills)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.staff_created)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.prescriptions)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.staff_id)
                .WillCascadeOnDelete(false);
        }
    }
}
