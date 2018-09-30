using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHRS.DAL.Entity
{

    [Table("UserRole")]
    public partial class UserRole
    {
        [Key]
        public int Id { get; set; }
    
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
