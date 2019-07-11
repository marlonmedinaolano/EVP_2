using EVP.AdministradorService;
using EVP.Dominio;
using EVP.Libreria;
using EVP.Security;
using System.ServiceModel;
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
                object usuarioObject = null;
                if (TipoCuenta == "Cliente" || TipoCuenta == "Duenio")//Autenticación REST
                    usuarioObject = (new RestClient<UsuarioDOM>().GET(ServiceRest.GestionarCredencialService + "Usuario.svc/UsuarioAutenticar/" + NumDocumento + "/" + Contrasenia).GetAwaiter().GetResult());
                
                else if (TipoCuenta == "Administrador")//Autenticación SOAP
                    usuarioObject = new AdministradorClient().Autenticar(NumDocumento, Contrasenia);

                System.Web.HttpContext.Current.Session["SessionUsuario"] = usuarioObject ?? throw new System.Exception("Usuario o contraseña incorrectas");
                System.Web.HttpContext.Current.Session["SessionIsAuthenticated"] = true;
                return Json(new { status = true }, JsonRequestBehavior.AllowGet);
            }
            catch (FaultException<RepetidoException> error)
            {
                return Json(new {status = false , value= error.Detail.Descripcion } , JsonRequestBehavior.AllowGet); 
            }
            catch (System.Exception ex)
            {
                return Json(new { status = false, value = ex.Message }, JsonRequestBehavior.AllowGet);
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