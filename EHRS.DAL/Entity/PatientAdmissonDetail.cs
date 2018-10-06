
namespace EHRS.DAL.Entity
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(PatientAdmissonDetail))]
    public partial class PatientAdmissonDetail
    {
        public int Id { get; set; }
        public int PatientAdmissionId { get; set; }
        public int DoctorId { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }

        [ForeignKey(nameof(PatientAdmissionId))]
        public virtual PatientAdmission PatientAdmission { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public virtual UserLogin DoctorDetail { get; set; }

        [ForeignKey(nameof(UpdatedBy))]
        public virtual UserLogin UpdatedByUser { get; set; }
    }
}
