using System.Collections.Generic;

namespace EHRS.BLL.Models
{
    public class UserDataModel
    {
        public UserDataModel()
        {
            Roles = new HashSet<RoleModel>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal MobileNumber { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public ICollection<RoleModel> Roles { get; set; }
    }
}