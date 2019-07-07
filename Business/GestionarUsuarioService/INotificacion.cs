using NotificacionService.Errores;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace NotificacionService
{
    [ServiceContract]
    public interface INotificacion
    {

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Notificar", ResponseFormat = WebMessageFormat.Json)]
        void Notificar(string correo);
         
    }
}
