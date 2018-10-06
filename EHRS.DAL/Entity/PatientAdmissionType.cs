
namespace EHRS.DAL.Entity
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(PatientAdmissionType))]   
    public partial class PatientAdmissionType
    {
        public int Id { get; set; }
        public string AdmissionType { get; set; }
    }
}