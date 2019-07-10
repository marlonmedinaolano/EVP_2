using EVP.Libreria;
using GestionarAsistenteService.Dominio;
using GestionarAsistenteService.Errores;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

namespace GestionarAsistenteService
{
    public class Valoracion : IValoracion
    {
        public ValoracionDOM Crear(ValoracionDOM Parametro)
        {
            try
            {
                return (new RestClient<ValoracionDOM>().POST(Parametro, "http://localhost:52164/Valoracion.svc/Valoracion").GetAwaiter().GetResult());

            }
            catch (WebException ex)
            {



                var RestClientException = ex.Serializer();
                throw new WebFaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "400",
                            Descripcion = RestClientException.Descripcion
                        },
                        System.Net.HttpStatusCode.Conflict
                    );
            }
        }

        public string Eliminar(string IdValoracion)
        {
            try
            {
                return (new RestClient<string>().DELETE( "http://localhost:52164/Valoracion.svc/Valoracion/" + IdValoracion).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public List<ValoracionDOM> Listar()
        {
            try
            {
                return (new RestClient<List<ValoracionDOM>>().GET("http://localhost:52164/Valoracion.svc/Valoracion" ).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public ValoracionDOM Modificar(ValoracionDOM Parametro)
        {
            try
            {
                return (new RestClient<ValoracionDOM>().PUT(Parametro, "http://localhost:52164/Valoracion.svc/Valoracion").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
