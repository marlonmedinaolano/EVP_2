﻿
namespace GestionarEstacionamientoService.Dominio
{
    using System.Runtime.Serialization;

    [DataContract]
    public class EstacionamientoDOM
    {
        [DataMember]
        public int IdEstacionamiento { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public string Telefono { get; set; }

        [DataMember]
        public decimal PrecioHora { get; set; }
        [DataMember]
        public string Dimencion { get; set; }

    }
}