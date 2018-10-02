using EHRS.BLL.Abstract;
using EHRS.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHRS.API.Controllers
{
    public class HomeController : ApiController
    {
        IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IHttpActionResult RegisterUser()
        {
            UserLoginModel userData = new UserLoginModel();
            _userService.RegisterUser(userData, "hello");
            return Ok();
        }
    }
}
