using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AlquilerService.Dominio;

namespace AlquilerService.Persistencia
{
    public class AlquilerDAO
    {

        public AlquilerDOM Crear(AlquilerDOM Entidad)
        { 
            string sql = @"INSERT INTO dbo.Alquiler VALUES (@IdUsuario, 
                                                            @IdEstacionamiento, 
                                                            @FechaInicio, 
                                                            @FechaFin, 
                                                            @Hora,1);";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", Entidad.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@IdEstacionamiento", Entidad.IdEstacionamiento));
                    comando.Parameters.Add(new SqlParameter("@FechaInicio", Entidad.FechaInicio));
                    comando.Parameters.Add(new SqlParameter("@FechaFin", Entidad.FechaFin));
                    comando.Parameters.Add(new SqlParameter("@Hora", Entidad.Hora)); 
                    comando.ExecuteNonQuery();
                }
            } 
            return Entidad;
        }
        public AlquilerDOM Obtener(string IdEstacionamiento)
        {
            AlquilerDOM Encontrado = null;
            try
            {
                string sql = "SELECT * FROM dbo.Alquiler WHERE IdEstacionamiento= @IdEstacionamiento";
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
                                Encontrado = new AlquilerDOM()
                                {
                                    IdAlquiler = (int)resultado["IdAlquiler"],
                                    FechaFin = (string)resultado["FechaFin"],
                                    FechaInicio = (string)resultado["FechaInicio"],
                                    Hora = (int)resultado["Hora"],
                                    IdEstacionamiento = (int)resultado["IdEstacionamiento"],
                                    IdUsuario = (int)resultado["IdUsuario"], 
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
        
        public AlquilerDOM Modificar(AlquilerDOM Entidad)
        {
            AlquilerDOM Modificado = null;
            try
            {
                string sql = @"UPDATE dbo.Alquiler SET FechaInicio=@FechaInicio , FechaFin=@FechaFin, Hora = @Hora WHERE IdAlquiler=@IdAlquiler";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdAlquiler", Entidad.IdAlquiler));
                        comando.Parameters.Add(new SqlParameter("@IdUsuario", Entidad.IdUsuario));
                        comando.Parameters.Add(new SqlParameter("@IdEstacionamiento", Entidad.IdEstacionamiento));
                        comando.Parameters.Add(new SqlParameter("@FechaInicio", Entidad.FechaInicio));
                        comando.Parameters.Add(new SqlParameter("@FechaFin", Entidad.FechaFin));
                        comando.Parameters.Add(new SqlParameter("@Hora", Entidad.Hora));
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

        public void Eliminar(string IdAlquiler)
        {
            string sql = "UPDATE dbo.Alquiler SET FlgActivo=@FlgActivo WHERE IdAlquiler=@IdAlquiler";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdAlquiler", System.Data.SqlDbType.Int, 0, IdAlquiler)); 
                    comando.Parameters.Add(new SqlParameter("@FlgActivo", 0));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<AlquilerDOM> Listar()
        {
            List<AlquilerDOM> Encontrados = new List<AlquilerDOM>(); 
            string sql = "SELECT * FROM dbo.Alquiler where FlgActivo = 1";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        { 
                            Encontrados.Add(new AlquilerDOM()
                            {
                                IdAlquiler = (int)resultado["IdAlquiler"],
                                FechaFin = (string)resultado["FechaFin"],
                                FechaInicio = (string)resultado["FechaInicio"],
                                Hora = (int)resultado["Hora"],
                                IdEstacionamiento = (int)resultado["IdEstacionamiento"],
                                IdUsuario = (int)resultado["IdUsuario"],
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
    }
}