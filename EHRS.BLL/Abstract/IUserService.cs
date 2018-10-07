
using EHRS.BLL.Models;

namespace EHRS.BLL.Abstract
{
    public interface IUserService
    {
        UserDataModel Login(LoginModel userLoginModel);

        bool RegisterUser(UserDataModel userDataModel, string password, UserDataModel loggedUser);
    }
}