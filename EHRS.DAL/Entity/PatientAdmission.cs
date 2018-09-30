
namespace EHRS.DAL.Entity
{
    using System;
    
    public partial class PatientAdmission
    {   
        public int Id { get; set; }
        public int PatientId { get; set; }
        public System.DateTime AdmissionDate { get; set; }
        public string AdmissionNotes { get; set; }
        public Nullable<System.DateTime> DischargeDate { get; set; }
        public int BillingId { get; set; }
    }
}
