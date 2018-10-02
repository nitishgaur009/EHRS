
using EHRS.BLL.Models;

namespace EHRS.BLL.Abstract
{
    public interface IUserService
    {
        UserLoginModel Login(string email, string password);

        bool RegisterUser(UserLoginModel userLoginModel, string password);
    }
}