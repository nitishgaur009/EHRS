using System.Collections.Generic;

namespace EHRS.BLL.Models
{
    public class UserDataModel
    {
        public UserDataModel()
        {
            Roles = new HashSet<string>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal MobileNumber { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}