using NotificacionService.Errores;
using System.ServiceModel.Web;

namespace NotificacionService
{
    public class Notificacion : INotificacion
    { 

        public void Notificar(string Correo)
        {
            throw new WebFaultException<RepetidoException>
                (
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "Error al enviar el correo"
                    },
                    System.Net.HttpStatusCode.Conflict
                );
        }
         
    }
}
