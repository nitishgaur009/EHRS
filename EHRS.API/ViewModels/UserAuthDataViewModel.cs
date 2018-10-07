using System.Collections.Generic;

namespace EHRS.API.ViewModels
{
    public class UserAuthDataViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<RoleViewModel> Roles { get; set; }
    }
}