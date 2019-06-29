using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UsuarioService.Dominio;
using UsuarioService.Errores;

namespace UsuarioService
{
    [ServiceContract]
    public interface IService1
    {

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Usuario Crear(Usuario Parametro);

        [OperationContract] 
        Usuario Obtener(string NroDocumento);

        [OperationContract] 
        Usuario Modificar(Usuario Parametro);

        [OperationContract] 
        string Eliminar(string IdUsuario);

        [OperationContract] 
        List<Usuario> Listar();
    }


}
