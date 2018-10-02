
namespace EHRS.DAL.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(PatientOPD))]
    public partial class PatientOPD
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public System.DateTime OPD_Date { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> NextVisitDate { get; set; }
        public int BillingId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public virtual UserLogin PatientDetail { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual MedicalDepartment MedicalDepartment { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public virtual UserLogin DoctorDetail { get; set; }

        [ForeignKey(nameof(BillingId))]
        public virtual Billing Billing { get; set; }
    }
}