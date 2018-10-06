
namespace EHRS.DAL.Entity
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(UserRole))]
    public partial class UserRole
    {
        public int Id { get; set; }
    
        public int RoleId { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserLogin UserData { get; set; }
    }
}
