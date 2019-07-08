using EVP.Libreria;
using GestionarAsistenteService.Dominio;
using System.Collections.Generic;

namespace GestionarAsistenteService
{
    public class Alquiler : IAlquiler
    {
        public AlquilerDOM Crear(AlquilerDOM Parametro)
        {
            try
            {
                return (new RestClient<AlquilerDOM>().POST(Parametro, "http://localhost:12165/Alquiler.svc/Alquiler").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }
         
        public string Eliminar(string IdAlquiler)
        {
            try
            {
                return (new RestClient<string>().DELETE( "http://localhost:12165/Alquiler.svc/Alquiler/" + IdAlquiler).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public List<AlquilerDOM> Listar()
        {
            try
            {
                return (new RestClient<List<AlquilerDOM>>().GET("http://localhost:12165/Alquiler.svc/Alquiler").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public AlquilerDOM Modificar(AlquilerDOM Parametro)
        {
            try
            {
                return (new RestClient<AlquilerDOM>().PUT(Parametro, "http://localhost:12165/Alquiler.svc/Alquiler").GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public AlquilerDOM Obtener(string IdEstacionamiento)
        {
            try
            {
                return (new RestClient<AlquilerDOM>().GET("http://localhost:12165/Alquiler.svc/Alquiler/" + IdEstacionamiento).GetAwaiter().GetResult());

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
