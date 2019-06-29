﻿using System.Collections.Generic;
using System.Data.SqlClient;
using ValoracionService.Dominio;

namespace ValoracionService.Persistencia
{
    public class ValoracionDAO
    {

        public ValoracionDOM Crear(ValoracionDOM Entidad)
        { 
            string sql = @"INSERT INTO dbo.Valoracion VALUES (
                                                            @IdUsuario, 
                                                            @IdEstacionamiento, 
                                                            @Comentario, 
                                                            @Puntuacion );";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Tipo", Entidad.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@Nombre", Entidad.IdEstacionamiento));
                    comando.Parameters.Add(new SqlParameter("@Apellidos", Entidad.Comentario));
                    comando.Parameters.Add(new SqlParameter("@NumDocumento", Entidad.Puntuacion)); 
                    comando.ExecuteNonQuery();
                }
            } 
            return Entidad;
        }
        public ValoracionDOM Obtener(string IdEstacionamiento)
        {
            ValoracionDOM Encontrado = null;
            try
            {
                string sql = "SELECT * FROM dbo.Valoracion WHERE IdEstacionamiento= @IdEstacionamiento";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdEstacionamiento", IdEstacionamiento));
                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.Read())
                            {
                                Encontrado = new ValoracionDOM()
                                {
                                    IdUsuario = (int)resultado["IdUsuario"],
                                    IdEstacionamiento = (int)resultado["IdEstacionamiento"],
                                    Comentario = (string)resultado["Comentario"],
                                    Puntuacion = (int)resultado["Puntuacion"] 
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

        public ValoracionDOM Modificar(ValoracionDOM Entidad)
        {
            ValoracionDOM Modificado = null;
            try
            {
                string sql = @"UPDATE dbo.Valoracion SET IdUsuario=@IdUsuario , IdEstacionamiento=@IdEstacionamiento, Comentario = @Comentario, Puntuacion=@Puntuacion, 
                                Direccion = @Direccion, Celular=@Celular WHERE IdValoracion=@IdValoracion";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdValoracion", Entidad.IdValoracion));
                        comando.Parameters.Add(new SqlParameter("@IdUsuario", Entidad.IdUsuario));
                        comando.Parameters.Add(new SqlParameter("@IdEstacionamiento", Entidad.IdEstacionamiento));
                        comando.Parameters.Add(new SqlParameter("@Comentario", Entidad.Comentario));
                        comando.Parameters.Add(new SqlParameter("@Puntuacion", Entidad.Puntuacion));
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

        public void Eliminar(string IdValoracion)
        {
            string sql = "UPDATE dbo.Valoracion SET FlgActivo=@FlgActivo WHERE IdValoracion=@IdValoracion";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdValoracion", System.Data.SqlDbType.Int, 0, IdValoracion)); 
                    comando.Parameters.Add(new SqlParameter("@FlgActivo", 0));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<ValoracionDOM> Listar()
        {
            List<ValoracionDOM> Encontrados = new List<ValoracionDOM>(); 
            string sql = "SELECT * FROM dbo.Valoracion where FlgActivo = 1";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        { 
                            Encontrados.Add(new ValoracionDOM()
                            {
                                IdValoracion = (int)resultado["IdValoracion"],
                                Comentario = (string)resultado["Comentario"],
                                IdEstacionamiento = (int)resultado["IdEstacionamiento"],
                                IdUsuario = (int)resultado["IdUsuario"],
                                Puntuacion = (int)resultado["Puntuacion"],
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
    }
}