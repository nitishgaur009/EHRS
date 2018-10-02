
namespace EHRS.BLL.Models
{
    public class UserRoleModel
    {
        public int Id { get; set; }

        public int RoleId { get; set; }
        public int UserId { get; set; }

        public RoleModel Role { get; set; }
    }
}