
namespace EVP.Dominio
{
    using System.Runtime.Serialization;
    
    public class ValoracionDOM
    {
        public int IdValoracion { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstacionamiento { get; set; }
        public string Comentario { get; set; }
        public int Puntuacion { get; set; } 

    }
}