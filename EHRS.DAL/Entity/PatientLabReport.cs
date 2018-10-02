namespace EHRS.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(PatientLabReport))]
    public partial class PatientLabReport
    {
        public PatientLabReport()
        {
            PatientBinaryReports = new HashSet<PatientLabReportBinaryData>();
        }
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

        [ForeignKey(nameof(PatientId))]
        public virtual UserLogin PatientDetail { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public virtual UserLogin DoctorDetail { get; set; }

        [ForeignKey(nameof(LabTechnicianId))]
        public virtual UserLogin LabTechnician { get; set; }

        [ForeignKey(nameof(TestId))]
        public virtual LabTest LabTest { get; set; }

        [ForeignKey(nameof(ReportAddedByLabTechnician))]
        public virtual UserLogin ReportByTechnician { get; set; }

        [ForeignKey(nameof(BillingId))]
        public virtual Billing Billing { get; set; }
        
        public virtual ICollection<PatientLabReportBinaryData> PatientBinaryReports { get; set; }
    }
}
