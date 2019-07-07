using EVP.Libreria;
using GestionarCredencialService.Dominio;
using GestionarCredencialService.Errores;
using System.ServiceModel.Web;

namespace GestionarCredencialService
{
    public class Usuario : IUsuario
    {  

        public UsuarioDOM UsuarioAutenticar(string NumDocumento, string Contrasenia)
        {
            try
            {
                //return (new RestClient<UsuarioDOM>().POST(UniversidadCrear, Local.WCF_GestionarPermisoService + "Universidad")).GetAwaiter().GetResult();
                 
            }
            catch (System.Exception)
            {

                throw;
            }
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
