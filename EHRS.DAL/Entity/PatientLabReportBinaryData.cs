
namespace EHRS.DAL.Entity
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(PatientLabReportBinaryData))]
    public partial class PatientLabReportBinaryData
    {
        public int Id { get; set; }
        public int PatientLabReportId { get; set; }
        public string FileExtension { get; set; }
        public byte[] FileContent { get; set; }

        [ForeignKey(nameof(PatientLabReportId))]
        public virtual PatientLabReport PatientLabReport { get; set; }
    }
}
