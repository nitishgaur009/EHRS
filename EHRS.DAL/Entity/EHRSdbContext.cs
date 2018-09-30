
namespace EHRS.DAL.Entity
{
    using System.Data.Entity;

    public partial class EHRSdbContext : DbContext
    {
        public EHRSdbContext()
            : base("name=EHRSdbContext")
        {
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
