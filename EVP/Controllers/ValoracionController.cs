using EVP.AdministradorService;
using EVP.Dominio;
using EVP.Libreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                var respuesta = (new RestClient<ValoracionDOM>().POST(ValoracionDOM, ServiceRest.GestionarAsistenteService +"Valoracion.svc/Valoracion").GetAwaiter().GetResult());

                return Json(new { status = true , value = "valoración registrada" }, JsonRequestBehavior.AllowGet);
            }
            catch (WebException ex)
            {
                var RestClientException = ex.Serializer(); 
                return Json(new { status = false, value = RestClientException.Descripcion }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(new { status = false, value = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}

