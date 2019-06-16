
namespace UsuarioService.Dominio
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string ApePaterno { get; set; }

        [DataMember]
        public string ApeMaterno { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string TipoUsuario { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }
        [DataMember]
        public string NroDocumento { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string FechaNacimiento { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Contrasenia { get; set; }

    }
}