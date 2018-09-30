namespace EHRS.DAL.Entity
{
    using System;
    
    public partial class PatientLabReport
    {   
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int LabTechnicianId { get; set; }
        public int TestId { get; set; }
        public System.DateTime TestDate { get; set; }
        public Nullable<System.DateTime> ExpectedReportDate { get; set; }
        public Nullable<System.DateTime> ActualReportDate { get; set; }
        public string ReportContent { get; set; }
        public int ReportAddedByLabTechnician { get; set; }
        public Nullable<int> BillingId { get; set; }
    }
}
