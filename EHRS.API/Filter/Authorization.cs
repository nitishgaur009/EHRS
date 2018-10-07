using EHRS.API.ViewModels;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EHRS.API.Filter
{
    public class Authorization : AuthorizationFilterAttribute
    {
        public string Roles { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            HttpResponseMessage response = null;
            UserAuthDataViewModel userAuthData = Common.GetUserAuthData();

            if (HttpContext.Current.User.Identity.IsAuthenticated && userAuthData != null)
            {
                if (!string.IsNullOrWhiteSpace(Roles))
                {
                    var userRoles = userAuthData.Roles;
                    if (userRoles != null && userRoles.Count > 0)
                    {
                        string[] actionRoles = Roles.Split(',');

                        var roleExists = (from ur in userRoles
                                          join ar in actionRoles
                                          on ur equals ar
                                          select ur).Any();

                        if (!roleExists)
                        {                           
                            response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    }
                }
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            if (response != null)
            {
                actionContext.Response = response;
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}