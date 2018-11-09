
using EHRS.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHRS.BLL.Abstract
{
    public interface IUserService
    {
        UserAuthDataModel Login(LoginModel userLoginModel);

        Task<bool> RegisterUser(UserModel userDataModel);

        IEnumerable<UserModel> GetAllUsers();
    }
}