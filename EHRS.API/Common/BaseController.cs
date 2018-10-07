using EHRS.API.Filter;
using EHRS.API.ViewModels;
using System.Web.Http;

namespace EHRS.API
{
    [Authorization]
    public class BaseController : ApiController
    {
        public UserAuthDataViewModel UserAuthData { get; set; }

        public BaseController()
        {
            if (UserAuthData == null)
            {
                UserAuthData = Common.GetUserAuthData();
            }
        }
    }
}