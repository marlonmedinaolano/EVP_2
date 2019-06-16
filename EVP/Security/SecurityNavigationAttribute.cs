
namespace EVP.Security
{
    using System;
    using System.Runtime.Caching;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Web.Routing;

    public class SecurityNavigationAttribute : AuthorizeAttribute
    {
        private static MemoryCache _cache = MemoryCache.Default;
        private string windows;

        public SecurityNavigationAttribute(string windows)
        {
            this.windows = windows;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                if (SecurityLocal.Usuario == null)
                {
                    _cache.Set("statusNavigation", "Login", new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddDays(1) });
                    return false;
                }

                if (windows == "SessionUsuario" || windows == "SessionIsAuthenticated")
                {
                    _cache.Set("statusNavigation", "NotFoundPage", new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddDays(1) });
                    return false;
                }  

                return true;

                //System.Web.HttpContext.Current.Session[windows] = new ChartSecurityPrivilege()
                //{
                //    Consult = false,
                //    New = false,
                //    Edit = false,
                //    Delete = false
                //};

            }
            catch (Exception)
            {
                _cache.Set("statusNavigation", "InternalError", new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddDays(1) });
                return true;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            var statusNavigation = _cache.Get("statusNavigation") as string;
            if (statusNavigation == "Login")
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
            else if (statusNavigation == "NotFoundPage")
            {
                filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary(
                      new
                      {
                          controller = "Home",
                          action = "NotFoundPage"
                      })
                  );
            }
            else if (statusNavigation == "InternalError")
            {
                filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary(
                      new
                      {
                          controller = "Home",
                          action = "InternalError"
                      })
                  );
            }
            else if (statusNavigation == "WithoutPermission")
            {
                filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary(
                      new
                      {
                          controller = "Home",
                          action = "WithoutPermission"
                      })
                  );
            }
        }
    }
}
