namespace EHRS.DAL.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(Billing))]
    public partial class Billing
    {   
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AccountantId { get; set; }
        public string BillFor { get; set; }
        public decimal BillAmount { get; set; }
        public System.DateTime BillDate { get; set; }
        public int PaymentMode { get; set; }
        public Nullable<int> TransactionId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public virtual UserLogin PatientDetail { get; set; }

        [ForeignKey(nameof(AccountantId))]
        public virtual UserLogin AccountantDetail { get; set; }

        [ForeignKey(nameof(PaymentMode))]
        public virtual PaymentMode PaymentModeDetail { get; set; }

        public virtual PatientOPD PatientOPD { get; set; }

        public virtual PatientLabReport PatientLabReport { get; set; }

        public virtual PatientAdmission PatientAdmission { get; set; }
    }
}