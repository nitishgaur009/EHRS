namespace EHRS.DAL.Entity
{    
    public partial class PatientLabReportBinaryData
    {
        public int Id { get; set; }
        public int PatientLabReportId { get; set; }
        public string FileExtension { get; set; }
        public byte[] FileContent { get; set; }
    }
}
