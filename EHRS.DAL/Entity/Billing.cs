namespace EHRS.DAL.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(Billing))]
    public partial class Billing
    {
        public Billing()
        {
            PatientAdmission = new HashSet<PatientAdmission>();
            PatientLabReport = new HashSet<PatientLabReport>();
            PatientOPD = new HashSet<PatientOPD>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AccountantId { get; set; }
        public string BillFor { get; set; }
        public decimal BillAmount { get; set; }
        public System.DateTime BillDate { get; set; }
        public int PaymentMode { get; set; }
        public string TransactionId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public virtual UserLogin PatientDetail { get; set; }

        [ForeignKey(nameof(AccountantId))]
        public virtual UserLogin AccountantDetail { get; set; }

        [ForeignKey(nameof(PaymentMode))]
        public virtual PaymentMode PaymentModeDetail { get; set; }

        public virtual ICollection<PatientOPD> PatientOPD { get; set; }

        public virtual ICollection<PatientLabReport> PatientLabReport { get; set; }

        public virtual ICollection<PatientAdmission> PatientAdmission { get; set; }
    }
}