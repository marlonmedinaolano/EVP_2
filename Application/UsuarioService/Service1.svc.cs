using System;
using System.Collections.Generic;
using System.ServiceModel.Web;
using UsuarioService.Dominio;
using UsuarioService.Errores;
using UsuarioService.Persistencia;

namespace UsuarioService
{
    public class Service1 : IService1
    {
        public Usuario Crear(Usuario Parametro)
        {
            var DAO = new UsuarioDAO();
            if (DAO.Obtener(Parametro.NroDocumento) != null) // Ya existe
            {
                throw new WebFaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "101",
                            Descripcion = "El NroDocumento ya existe"
                        },
                        System.Net.HttpStatusCode.Conflict
                    );
            }
            return DAO.Crear(Parametro);
        }

        public string Eliminar(string IdUsuario)
        {
            try
            {
                var DAO = new UsuarioDAO();
                DAO.Eliminar(IdUsuario);
                return "exitoso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Usuario> Listar()
        {
            var DAO = new UsuarioDAO();
            return DAO.Listar();
        }

        public Usuario Modificar(Usuario Parametro)
        {
            var DAO = new UsuarioDAO();
            return DAO.Modificar(Parametro);
        }

        public Usuario Obtener(string RUC)
        {
            var DAO = new UsuarioDAO();
            return DAO.Obtener(RUC);
        }

    }
}
