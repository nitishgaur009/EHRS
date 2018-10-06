
namespace EHRS.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(PatientAdmission))]
    public partial class PatientAdmission
    {   
        public PatientAdmission()
        {
            PatientAdmissionDetails = new HashSet<PatientAdmissonDetail>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public System.DateTime AdmissionDate { get; set; }
        public string AdmissionNotes { get; set; }
        public Nullable<System.DateTime> DischargeDate { get; set; }
        public int BillingId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public virtual UserLogin PatientDetail { get; set; }

        [ForeignKey(nameof(BillingId))]
        public virtual Billing Billing { get; set; }

        public virtual ICollection<PatientAdmissonDetail> PatientAdmissionDetails { get; set; }
    }
}
