
namespace EHRS.DAL.Entity
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(PaymentMode))]
    public partial class PaymentMode
    {    
        public int Id { get; set; }
        public string Mode { get; set; }
    }
}
