
namespace EHRS.DAL.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PaymentMode")]
    public partial class PaymentMode
    {    
        [Key]
        public int Id { get; set; }
        public string Mode { get; set; }
    }
}
