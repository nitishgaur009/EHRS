namespace EHRS.DAL.Entity
{
    using System;
    
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
    }
}
