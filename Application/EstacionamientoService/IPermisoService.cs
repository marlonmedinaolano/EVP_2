using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_GestionarPermisoService.Dominio;
using WCF_GestionarPermisoService.Errores;

namespace WCF_GestionarPermisoService
{
    [ServiceContract]
    public interface IPermisoService
    {
        #region Universidad

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Universidad", ResponseFormat = WebMessageFormat.Json)] 
        Universidad UniversidadCrear(Universidad Parametro);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Universidad/{RUC}", ResponseFormat = WebMessageFormat.Json)]
        Universidad UniversidadObtener(string RUC);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Universidad", ResponseFormat = WebMessageFormat.Json)]
        Universidad UniversidadModificar(Universidad Parametro);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Universidad/{IdUniversidad}", ResponseFormat = WebMessageFormat.Json)]
        string UniversidadEliminar(string IdUniversidad);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Universidad", ResponseFormat = WebMessageFormat.Json)]
        List<Universidad> UniversidadListar();
        #endregion

        #region Universidad Usuario

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UniversidadUsuario", ResponseFormat = WebMessageFormat.Json)]
        UniversidadUsuario UniversidadUsuarioCrear(UniversidadUsuario Parametro);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "UniversidadUsuario/{IdUniversidadUsuario}", ResponseFormat = WebMessageFormat.Json)]
        UniversidadUsuario UniversidadUsuarioObtener(string IdUniversidadUsuario);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "UniversidadUsuario", ResponseFormat = WebMessageFormat.Json)]
        UniversidadUsuario UniversidadUsuarioModificar(UniversidadUsuario Parametro);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "UniversidadUsuario/{IdUniversidadUsuario}", ResponseFormat = WebMessageFormat.Json)]
        void UniversidadUsuarioEliminar(string IdUniversidadUsuario);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "UniversidadUsuarios/{IdUniversidad}", ResponseFormat = WebMessageFormat.Json)]
        List<UniversidadUsuario> UniversidadUsuarioListar(string IdUniversidad);
        #endregion
    }
}
