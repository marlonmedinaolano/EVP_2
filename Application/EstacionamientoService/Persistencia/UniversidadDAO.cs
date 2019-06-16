using System.Collections.Generic;
using System.Data.SqlClient;
using WCF_GestionarPermisoService.Dominio;

namespace WCF_GestionarPermisoService.Persistencia
{
    public class UniversidadDAO
    {

        public Universidad Crear(Universidad Entidad)
        { 
            string sql = "INSERT INTO dbo.Universidad VALUES (@RUC, @RazonSocial, 1);";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@RUC", Entidad.RUC));
                    comando.Parameters.Add(new SqlParameter("@RazonSocial", Entidad.RazonSocial));
                    comando.ExecuteNonQuery();
                }
            } 
            return Entidad;
        }
        public Universidad Obtener(string RUC)
        {
            Universidad Encontrado = null;
            try
            {
                string sql = "SELECT * FROM dbo.Universidad WHERE RUC=@RUC";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@RUC", RUC));
                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.Read())
                            {
                                Encontrado = new Universidad()
                                {
                                    IdUniversidad = (int)resultado["IdUniversidad"],
                                    RUC = (string)resultado["RUC"],
                                    RazonSocial = (string)resultado["RazonSocial"],
                                };
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                var ms = ex.Message;
            }
            return Encontrado;
        }
         
        public Universidad Modificar(Universidad Entidad)
        {
                Universidad Modificado = null;
            try
            {
                string sql = "UPDATE dbo.Universidad SET RazonSocial=@RazonSocial , RUC=@RUC WHERE IdUniversidad=@IdUniversidad";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@RazonSocial", Entidad.RazonSocial));
                        comando.Parameters.Add(new SqlParameter("@IdUniversidad", Entidad.IdUniversidad.ToString()));
                        comando.Parameters.Add(new SqlParameter("@RUC", Entidad.RUC));
                        comando.ExecuteNonQuery();
                    }
                }
                Modificado = Entidad;
            }
            catch (System.Exception ex)
            {
                var ms = ex.Message;
            }
            return Modificado;
        }

        public void Eliminar(string IdUniversidad)
        {
            string sql = "UPDATE dbo.Universidad SET FlgActivo=@FlgActivo WHERE IdUniversidad=@IdUniversidad";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUniversidad", System.Data.SqlDbType.Int, 0, IdUniversidad)); 
                    comando.Parameters.Add(new SqlParameter("@FlgActivo", 0));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Universidad> Listar()
        {
            List<Universidad> Encontrados = new List<Universidad>(); 
            string sql = "SELECT * FROM dbo.Universidad where FlgActivo = 1";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        { 
                            Encontrados.Add(new Universidad()
                            {
                                IdUniversidad = (int)resultado["IdUniversidad"],
                                RUC = (string)resultado["RUC"],
                                RazonSocial = (string)resultado["RazonSocial"] 
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
    }
}