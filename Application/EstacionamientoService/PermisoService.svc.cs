using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_GestionarPermisoService.Dominio;
using WCF_GestionarPermisoService.Errores;
using WCF_GestionarPermisoService.Persistencia;

namespace WCF_GestionarPermisoService
{
    public class PermisoService : IPermisoService
    {
        #region Universidad

        public Universidad UniversidadCrear(Universidad Parametro)
        {
            var DAO = new UniversidadDAO();
            if (DAO.Obtener(Parametro.RUC) != null) // Ya existe
            {
                throw new WebFaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "101",
                            Descripcion = "El RUC ya existe"
                        },
                        System.Net.HttpStatusCode.Conflict
                    ); 
            }
            return DAO.Crear(Parametro);
        }

        public string UniversidadEliminar(string IdUniversidad)
        {
            try
            {
                var DAO = new UniversidadDAO();
                DAO.Eliminar(IdUniversidad);
                return "exitoso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Universidad> UniversidadListar()
        {
            var DAO = new UniversidadDAO();
            return DAO.Listar();
        }

        public Universidad UniversidadModificar(Universidad Parametro)
        {
            var DAO = new UniversidadDAO();
            return DAO.Modificar(Parametro);
        }

        public Universidad UniversidadObtener(string RUC)
        {
            var DAO = new UniversidadDAO();
            return DAO.Obtener(RUC);
        }
        #endregion

        #region Universidad Usuario
         
        public UniversidadUsuario UniversidadUsuarioCrear(UniversidadUsuario Parametro)
        {
            var DAO = new UniversidadUsuarioDAO();
            if (DAO.Obtener(Parametro.Correo) != null) // Ya existe
            {
                throw new WebFaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "409",
                            Descripcion = "El Correo ya existe"
                        },
                        System.Net.HttpStatusCode.Conflict
                    );
            }
            return DAO.Crear(Parametro);
        }

        public void UniversidadUsuarioEliminar(string IdUniversidadUsuario)
        {
            var DAO = new UniversidadUsuarioDAO();
            DAO.Eliminar(IdUniversidadUsuario);
        }

        public List<UniversidadUsuario> UniversidadUsuarioListar(string IdUniversidad)
        {
            var DAO = new UniversidadUsuarioDAO();
            return DAO.Listar(IdUniversidad);
        }

        public UniversidadUsuario UniversidadUsuarioModificar(UniversidadUsuario Parametro)
        {
            var DAO = new UniversidadUsuarioDAO();
            return DAO.Modificar(Parametro);
        }

        public UniversidadUsuario UniversidadUsuarioObtener(string IdUniversidadUsuario)
        {
            var DAO = new UniversidadUsuarioDAO();
            return DAO.Obtener(IdUniversidadUsuario);
        }
        #endregion
    }
}
