
namespace EHRS.DAL.Entity
{
    using System;
    
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
    }
}
