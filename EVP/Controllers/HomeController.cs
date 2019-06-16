using EVP.Security;
using System.Web.Mvc;

namespace EVP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string NumDocumento, string Contrasenia, string TipoCuenta)
        {
            try
            {
                if (TipoCuenta != "Administrador") throw new System.Exception("Solo se permite autenticación para los administrador");
                var instChartLocal = new AdministradorService.AdministradorClient().Autenticar(NumDocumento, Contrasenia);
                if (instChartLocal != null)
                {
                    System.Web.HttpContext.Current.Session["SessionIsAuthenticated"] = true;
                    System.Web.HttpContext.Current.Session["SessionUsuario"] = instChartLocal;
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Usuario o contraseña incorrectas", JsonRequestBehavior.AllowGet);
                }
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            SecurityLocal.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}