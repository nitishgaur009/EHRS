
namespace EHRS.DAL.Entity
{
    using System.Data.Entity;

    public partial class EHRSdbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.SetKeys(modelBuilder);
        }

        private void SetKeys(DbModelBuilder builder)
        {
            builder.Entity<UserLogin>().HasKey(r => new { r.Id });
            builder.Entity<UserRole>().HasKey(r => new { r.Id });
            builder.Entity<Role>().HasKey(r => new { r.Id });
            builder.Entity<Billing>().HasKey(r => new { r.Id });
            builder.Entity<LabTest>().HasKey(r => new { r.Id });
            builder.Entity<MedicalDepartment>().HasKey(r => new { r.Id });
            builder.Entity<PatientAdmission>().HasKey(r => new { r.Id });
            builder.Entity<PatientAdmissionType>().HasKey(r => new { r.Id });
            builder.Entity<PatientAdmissonDetail>().HasKey(r => new { r.Id });
            builder.Entity<PatientLabReport>().HasKey(r => new { r.Id });
            builder.Entity<PatientLabReportBinaryData>().HasKey(r => new { r.Id });
            builder.Entity<PatientOPD>().HasKey(r => new { r.Id });
            builder.Entity<PaymentMode>().HasKey(r => new { r.Id });
        }

        public virtual DbSet<Billing> Billing { get; set; }
        public virtual DbSet<LabTest> LabTest { get; set; }
        public virtual DbSet<MedicalDepartment> MedicalDepartment { get; set; }
        public virtual DbSet<PatientAdmission> PatientAdmission { get; set; }
        public virtual DbSet<PatientAdmissionType> PatientAdmissionType { get; set; }
        public virtual DbSet<PatientAdmissonDetail> PatientAdmissonDetail { get; set; }
        public virtual DbSet<PatientLabReport> PatientLabReport { get; set; }
        public virtual DbSet<PatientLabReportBinaryData> PatientLabReportBinaryData { get; set; }
        public virtual DbSet<PatientOPD> PatientOPD { get; set; }
        public virtual DbSet<PaymentMode> PaymentMode { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
    }
}
