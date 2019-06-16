using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UsuarioService.Dominio;

namespace UsuarioService.Persistencia
{
    public class UsuarioDAO
    {

        public Usuario Crear(Usuario Entidad)
        { 
            string sql = @"INSERT INTO dbo.Usuario VALUES (
                                                            @Nombre, 
                                                            @ApePaterno, 
                                                            @ApeMaterno, 
                                                            @Sexo, 
                                                            @TipoUsuario, 
                                                            @TipoDocumento, 
                                                            @NroDocumento, 
                                                            @Direccion, 
                                                            @FechaNacimiento, 
                                                            @Email, 
                                                            @Contrasenia,1);";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", Entidad.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@Nombre", Entidad.Nombre));
                    comando.Parameters.Add(new SqlParameter("@ApePaterno", Entidad.ApePaterno));
                    comando.Parameters.Add(new SqlParameter("@ApeMaterno", Entidad.ApeMaterno));
                    comando.Parameters.Add(new SqlParameter("@Sexo", Entidad.Sexo));
                    comando.Parameters.Add(new SqlParameter("@TipoUsuario", Entidad.TipoUsuario));
                    comando.Parameters.Add(new SqlParameter("@TipoDocumento", Entidad.TipoDocumento));
                    comando.Parameters.Add(new SqlParameter("@NroDocumento", Entidad.NroDocumento));
                    comando.Parameters.Add(new SqlParameter("@Direccion", Entidad.Direccion));
                    comando.Parameters.Add(new SqlParameter("@FechaNacimiento", Entidad.FechaNacimiento));
                    comando.Parameters.Add(new SqlParameter("@Email", Entidad.Email));
                    comando.Parameters.Add(new SqlParameter("@Contrasenia", Entidad.Contrasenia));
                    comando.ExecuteNonQuery();
                }
            } 
            return Entidad;
        }
        public Usuario Obtener(string NroDocumento)
        {
            Usuario Encontrado = null;
            try
            {
                string sql = "SELECT * FROM dbo.Usuario WHERE NroDocumento= @NroDocumento";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@NroDocumento", NroDocumento));
                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.Read())
                            {
                                Encontrado = new Usuario()
                                {
                                    IdUsuario = (int)resultado["IdUsuario"],
                                    ApeMaterno = (string)resultado["ApeMaterno"],
                                    ApePaterno = (string)resultado["ApePaterno"],
                                    Direccion = (string)resultado["Direccion"],
                                    Email = (string)resultado["Email"],
                                    Nombre = (string)resultado["Nombre"],
                                    TipoUsuario = (string)resultado["TipoUsuario"],
                                    NroDocumento = (string)resultado["NroDocumento"],
                                    Sexo = (string)resultado["Sexo"],
                                    TipoDocumento = (string)resultado["TipoDocumento"],
                                    FechaNacimiento = (string)resultado["FechaNacimiento"],
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
         
        public Usuario Modificar(Usuario Entidad)
        {
                Usuario Modificado = null;
            try
            {
                string sql = @"UPDATE dbo.Usuario SET Nombre=@Nombre , ApePaterno=@ApePaterno, ApeMaterno = @ApeMaterno, Sexo=@Sexo, 
                                TipoUsuario = @TipoUsuario, TipoDocumento=@TipoDocumento, NroDocumento=@NroDocumento , Direccion=@Direccion,
                                FechaNacimiento =@FechaNacimiento, Email=@Email WHERE IdUsuario=@IdUsuario";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdUsuario", Entidad.IdUsuario));
                        comando.Parameters.Add(new SqlParameter("@Nombre", Entidad.Nombre));
                        comando.Parameters.Add(new SqlParameter("@ApePaterno", Entidad.ApePaterno));
                        comando.Parameters.Add(new SqlParameter("@ApeMaterno", Entidad.ApeMaterno));
                        comando.Parameters.Add(new SqlParameter("@Sexo", Entidad.Sexo));
                        comando.Parameters.Add(new SqlParameter("@TipoUsuario", Entidad.TipoUsuario));
                        comando.Parameters.Add(new SqlParameter("@TipoDocumento", Entidad.TipoDocumento));
                        comando.Parameters.Add(new SqlParameter("@NroDocumento", Entidad.NroDocumento));
                        comando.Parameters.Add(new SqlParameter("@Direccion", Entidad.Direccion));
                        comando.Parameters.Add(new SqlParameter("@FechaNacimiento", Entidad.FechaNacimiento));
                        comando.Parameters.Add(new SqlParameter("@Email", Entidad.Email)); 
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

        public void Eliminar(string IdUsuario)
        {
            string sql = "UPDATE dbo.Usuario SET FlgActivo=@FlgActivo WHERE IdUsuario=@IdUsuario";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int, 0, IdUsuario)); 
                    comando.Parameters.Add(new SqlParameter("@FlgActivo", 0));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Usuario> Listar()
        {
            List<Usuario> Encontrados = new List<Usuario>(); 
            string sql = "SELECT * FROM dbo.Usuario where FlgActivo = 1";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        { 
                            Encontrados.Add(new Usuario()
                            {
                                IdUsuario = (int)resultado["IdUsuario"],
                                ApeMaterno = (string)resultado["ApeMaterno"],
                                ApePaterno = (string)resultado["ApePaterno"],
                                Direccion = (string)resultado["Direccion"],
                                Email = (string)resultado["Email"],
                                Nombre = (string)resultado["Nombre"],
                                TipoUsuario = (string)resultado["TipoUsuario"],
                                NroDocumento = (string)resultado["NroDocumento"],
                                Sexo = (string)resultado["Sexo"],
                                TipoDocumento = (string)resultado["TipoDocumento"],
                                FechaNacimiento = (string)resultado["FechaNacimiento"],
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
    }
}