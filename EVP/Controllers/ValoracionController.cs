using EVP.AdministradorService;
using EVP.Dominio;
using EVP.Libreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace EVP.Controllers
{
    public class ValoracionController : Controller
    {
        [HttpPost]
        public ActionResult Valoracion(ValoracionDOM ValoracionDOM)
        {
            try
            {
                ValoracionDOM.IdUsuario = (Security.SecurityLocal.Usuario as UsuarioDOM).IdUsuario;
                var respuesta = (new RestClient<string>().POST(ValoracionDOM, "http://localhost:52164/Valoracion.svc/Valoracion").GetAwaiter().GetResult());

                return Json(new { status = true , value = respuesta }, JsonRequestBehavior.AllowGet);
            }
            catch (FaultException<RepetidoException> error)
            {
                return Json(new { status = false, value = error.Detail.Descripcion }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(new { status = false, value = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
