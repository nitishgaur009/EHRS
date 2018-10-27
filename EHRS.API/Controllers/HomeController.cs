using EHRS.API.Filter;
using EHRS.BLL.Abstract;
using EHRS.BLL.Models;
using System;
using System.Web.Http;

namespace EHRS.API.Controllers
{
    public class HomeController : BaseController
    {
        IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorization(Roles = new string[] { "CanRegisterUser" })]
        public IHttpActionResult RegisterUser()
        {
            UserAuthDataModel userModel = new UserAuthDataModel()
            {
                FirstName = "Admin",
                LastName = "Admin",
                Address = "Admin",
                Email = "admin@ehrs.com",
                BirthDate = Convert.ToDateTime("1990-01-01"),
                MobileNumber = 9811816005
            };

           // bool blnAdded = _userService.RegisterUser(userModel, "admin", new UserAuthDataModel());
            return Ok();
        }
    }
}