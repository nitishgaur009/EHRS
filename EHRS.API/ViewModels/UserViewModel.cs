using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EHRS.API.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Roles = new HashSet<RoleViewModel>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public decimal MobileNumber { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public ICollection<RoleViewModel> Roles { get; set; }
    }
}