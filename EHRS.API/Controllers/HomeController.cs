﻿using EHRS.BLL.Abstract;
using EHRS.BLL.Models;
using System;
using System.Collections.Generic;
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
            UserDataModel userModel = new UserDataModel()
            {
                FirstName = "Admin",
                LastName = "Admin",
                Address = "Admin",
                Email = "admin@ehrs.com",
                BirthDate = Convert.ToDateTime("1990-01-01"),
                MobileNumber = 9811816005,
                Roles = new List<RoleModel>()
                {
                    new RoleModel()
                    {
                        Id = 1
                    }
                }
            };

            bool blnAdded = _userService.RegisterUser(userModel, "admin", new UserDataModel());
            return Ok(blnAdded);
        }
    }
}