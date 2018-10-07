using EHRS.API.ViewModels;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Script.Serialization;

namespace EHRS.API
{
    public static class Common
    {
        public static UserAuthDataViewModel GetUserAuthData()
        {
            UserAuthDataViewModel userAuthData = null;

            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
                    var userIdentity = identity.Claims.FirstOrDefault(c => c.Type == "UserAuthData");
                    if (userIdentity != null)
                    {
                        userAuthData = new JavaScriptSerializer().Deserialize<UserAuthDataViewModel>(userIdentity.Value);
                    }
                }
            }

            return userAuthData;
        }
    }
}