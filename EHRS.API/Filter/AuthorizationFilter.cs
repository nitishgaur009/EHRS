using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EHRS.API.Filter
{
    public class AuthorizationFilter : AuthorizationFilterAttribute
    {
        public string Roles { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;

                var userRoles = identity.Claims.FirstOrDefault(c => c.Type == "roles");
                if (userRoles != null)
                {
                    string[] userRolesArr = userRoles.Value.Split(',');
                    string[] actionRoles = Roles.Split(',');

                    var roleExists = (from ur in userRolesArr
                                      join ar in actionRoles
                                      on ur equals ar
                                      select ur).Any();

                    if (roleExists)
                    {
                        base.OnAuthorization(actionContext);
                    }
                    else
                    {
                        actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                        return;
                    }
                }
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                return;
            }
        }
    }
}