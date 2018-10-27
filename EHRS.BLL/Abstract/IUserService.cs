
using EHRS.BLL.Models;
using System.Collections.Generic;

namespace EHRS.BLL.Abstract
{
    public interface IUserService
    {
        UserAuthDataModel Login(LoginModel userLoginModel);

        bool RegisterUser(UserAuthDataModel userDataModel, string password, UserAuthDataModel loggedUser);

        IEnumerable<UserModel> GetAllUsers();
    }
}