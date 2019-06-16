using EVP.Libreria;
using System.Collections.Generic;
using System.Data.SqlClient;
using WCF_GestionarPermisoService.Dominio;

namespace WCF_GestionarPermisoService.Persistencia
{
    public class UniversidadUsuarioDAO
    {

        public UniversidadUsuario Crear(UniversidadUsuario Entidad)
        {
            UniversidadUsuario Creado = null;
            try
            {
                string sql = "INSERT INTO dbo.UniversidadUsuario VALUES (@IdUniversidad, @Correo , @Nombre, @Apellido, @Contrasenia, 1);";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdUniversidad", Entidad.Universidad.IdUniversidad.ToString()));
                        comando.Parameters.Add(new SqlParameter("@Correo", Entidad.Correo));
                        comando.Parameters.Add(new SqlParameter("@Nombre", Entidad.Nombre));
                        comando.Parameters.Add(new SqlParameter("@Apellido", Entidad.Apellido));
                        comando.Parameters.Add(new SqlParameter("@Contrasenia", EncryptRSA.Encriptar(Entidad.Contrasenia, Local.ClavePublica)));
                        comando.ExecuteNonQuery();
                    }
                }
                Creado = Obtener(Entidad.Correo);
            }
            catch (System.Exception ex)
            {
                var ms = ex.Message;
            }


            return Creado;
        }

        public UniversidadUsuario Obtener(string Correo)
        {
            UniversidadUsuario Encontrado = null;
            string sql = "SELECT * FROM dbo.UniversidadUsuario WHERE Correo = @Correo";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Correo", Correo));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            Encontrado = new UniversidadUsuario()
                            {
                                IdUniversidadUsuario = (int)resultado["IdUniversidadUsuario"],
                                Correo = (string)resultado["Correo"], 
                                Apellido = (string)resultado["Apellido"],
                                Nombre = (string)resultado["Nombre"],
                                Universidad = new Universidad()
                                {
                                    IdUniversidad = (int)resultado["IdUniversidad"],
                                }
                            };
                        }
                    }
                }
            }
            return Encontrado;
        }
         
        public UniversidadUsuario Modificar(UniversidadUsuario Entidad)
        {
            UniversidadUsuario Modificado = null;
            string sql = "UPDATE dbo.UniversidadUsuario SET Nombre=@Nombre, Apellido = @Apellido, Contrasenia = @Contrasenia WHERE IdUniversidadUsuario=@IdUniversidadUsuario";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUniversidadUsuario", Entidad.IdUniversidadUsuario.ToString()));
                    comando.Parameters.Add(new SqlParameter("@Nombre", Entidad.Nombre));
                    comando.Parameters.Add(new SqlParameter("@Apellido", Entidad.Apellido));
                    comando.Parameters.Add(new SqlParameter("@Contrasenia", EncryptRSA.Encriptar(Entidad.Contrasenia, Local.ClavePublica)));
                    comando.ExecuteNonQuery();
                }
            }
            Modificado = Obtener(Entidad.Correo);
            return Modificado;
        }

        public void Eliminar(string IdUniversidadUsuario)
        {
            string sql = "UPDATE dbo.UniversidadUsuario SET FlgActivo=@FlgActivo WHERE IdUniversidadUsuario=@IdUniversidadUsuario";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUniversidadUsuario", IdUniversidadUsuario.ToString()));
                    comando.Parameters.Add(new SqlParameter("@FlgActivo", 0));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<UniversidadUsuario> Listar(string IdUniversidad)
        {
            List<UniversidadUsuario> Encontrados = new List<UniversidadUsuario>(); 
            string sql = "SELECT * FROM dbo.UniversidadUsuario where FlgActivo = 1 and IdUniversidad =  @IdUniversidad";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUniversidad", IdUniversidad));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        { 
                            Encontrados.Add(new UniversidadUsuario()
                            {
                                IdUniversidadUsuario = (int)resultado["IdUniversidadUsuario"],
                                Correo = (string)resultado["Correo"], 
                                Apellido = (string)resultado["Apellido"],
                                Nombre = (string)resultado["Nombre"] ,
                                Universidad = new Universidad()
                                {
                                    IdUniversidad = (int)resultado["IdUniversidad"],
                                }
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
    }
}