using AutoMapper;
using EHRS.API.Filter;
using EHRS.API.ViewModels;
using EHRS.BLL.Abstract;
using EHRS.Common.Enums;
using System.Collections.Generic;
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
    }
}