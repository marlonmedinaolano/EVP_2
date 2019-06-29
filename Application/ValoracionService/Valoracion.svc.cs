using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ValoracionService.Dominio;
using ValoracionService.Errores;
using ValoracionService.Persistencia;

namespace ValoracionService
{
    public class Valoracion : IValoracion
    { 

        public ValoracionDOM Crear(ValoracionDOM Parametro)
        {
            var DAO = new ValoracionDAO();
            //if (DAO.Obtener(Parametro.NumDocumento) != null) // Ya existe
            //{
            //    throw new WebFaultException<RepetidoException>
            //        (
            //            new RepetidoException()
            //            {
            //                Codigo = "101",
            //                Descripcion = "El Número documento ya existe"
            //            },
            //            System.Net.HttpStatusCode.Conflict
            //        );
            //}
            return DAO.Crear(Parametro);
        }

        public string Eliminar(string IdValoracion)
        {
            try
            {
                var DAO = new ValoracionDAO();
                DAO.Eliminar(IdValoracion);
                return "exitoso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<ValoracionDOM> Listar()
        {
            var DAO = new ValoracionDAO();
            return DAO.Listar();
        }

        public ValoracionDOM Modificar(ValoracionDOM Parametro)
        {
            var DAO = new ValoracionDAO();
            return DAO.Modificar(Parametro);
        }

        public ValoracionDOM Obtener(string IdValoracion)
        {
            var DAO = new ValoracionDAO();
            return DAO.Obtener(IdValoracion);
        }
         
    }
}
