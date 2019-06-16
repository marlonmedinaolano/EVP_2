
namespace WCF_GestionarPermisoService.Dominio
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UniversidadUsuario
    {
        [DataMember]
        public int IdUniversidadUsuario { get; set; }
        [DataMember]
        public Universidad Universidad { get; set; }
        [DataMember]
        public string Correo { get; set; }
         
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }

        [DataMember]
        public string Contrasenia { get; set; }

    }
}