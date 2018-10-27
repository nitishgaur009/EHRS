using System.Collections.Generic;

namespace EHRS.API.ViewModels
{
    public class UserListViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}