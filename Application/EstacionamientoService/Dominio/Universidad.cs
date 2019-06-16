
namespace WCF_GestionarPermisoService.Dominio
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Universidad
    {
        [DataMember]
        public int IdUniversidad { get; set; }
        [DataMember]
        public string RUC { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }
         

    }
}