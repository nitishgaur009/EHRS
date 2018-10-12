using EHRS.API.Filter;
using EHRS.BLL.Abstract;
using EHRS.BLL.Models;
using EHRS.Common.Enums;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace EHRS.API.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        [Authorization(Roles = new string[] { nameof(PermissionsEnum.CanRegisterAllUser), nameof(PermissionsEnum.CanRegisterPatient) })]
        public async Task<IHttpActionResult> RegisterUser()
        {
            return Ok();
        }
    }
}
