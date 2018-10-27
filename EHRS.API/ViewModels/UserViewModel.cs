using System.Collections.Generic;

namespace EHRS.API.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Roles = new HashSet<RoleViewModel>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal MobileNumber { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public ICollection<RoleViewModel> Roles { get; set; }
    }
}