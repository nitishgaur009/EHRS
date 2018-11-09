using AutoMapper;
using EHRS.API.Filter;
using EHRS.API.ViewModels;
using EHRS.BLL.Abstract;
using EHRS.BLL.Models;
using EHRS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace EHRS.API.Controllers
{
    public class UserController : BaseController
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorization(Roles = new string[] { nameof(PermissionsEnum.CanOperateAllUser)})]
        public IHttpActionResult GetAll()
        {
            var usersViewModel = Mapper.Map<IEnumerable<UserViewModel>>(_userService.GetAllUsers());
            UserListViewModel lstModel = new UserListViewModel
            {
                Users = usersViewModel
            };

            return Ok(lstModel);
        }

        [HttpPost]
        [Authorization(Roles = new string[] { nameof(PermissionsEnum.CanOperateAllUser), nameof(PermissionsEnum.CanRegisterPatient) })]
        public async Task<IHttpActionResult> AddUser(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userModel = Mapper.Map<UserModel>(userViewModel);
                await _userService.RegisterUser(userModel);
                return Ok(true);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}