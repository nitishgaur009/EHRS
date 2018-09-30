namespace EHRS.DAL.Entity
{
    
    public partial class PatientAdmissonDetail
    {
        public int Id { get; set; }
        public int PatientAdmissionId { get; set; }
        public int DoctorId { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}
