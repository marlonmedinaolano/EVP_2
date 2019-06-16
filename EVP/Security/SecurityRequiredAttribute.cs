using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EVP.Security
{
    public class SecurityRequiredAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return SecurityLocal.IsAuthenticated;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!SecurityLocal.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "cuenta",
                            action = "login"
                        })
                    );
            }
        }
    }
}
