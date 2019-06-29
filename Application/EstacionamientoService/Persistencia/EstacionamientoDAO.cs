using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EstacionamientoService.Dominio;

namespace EstacionamientoService.Persistencia
{
    public class EstacionamientoDAO
    {

        public EstacionamientoDOM Crear(EstacionamientoDOM Entidad)
        { 
            string sql = @"INSERT INTO dbo.Estacionamiento VALUES (
                                                            @IdUsuario, 
                                                            @Direccion, 
                                                            @Telefono, 
                                                            @PrecioHora, 
                                                            @Dimencion,1);";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", Entidad.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@Direccion", Entidad.Direccion));
                    comando.Parameters.Add(new SqlParameter("@Telefono", Entidad.Telefono));
                    comando.Parameters.Add(new SqlParameter("@PrecioHora", Entidad.PrecioHora.ToString()));
                    comando.Parameters.Add(new SqlParameter("@Dimencion", Entidad.Dimencion)); 
                    comando.ExecuteNonQuery();
                }
            } 
            return Entidad;
        }
        public EstacionamientoDOM Obtener(string IdUsuario)
        {
            EstacionamientoDOM Encontrado = null;
            try
            {
                string sql = "SELECT * FROM dbo.Estacionamiento WHERE IdUsuario= @IdUsuario";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdUsuario", IdUsuario));
                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.Read())
                            {
                                Encontrado = new EstacionamientoDOM()
                                {
                                    IdEstacionamiento = (int)resultado["IdEstacionamiento"],
                                    IdUsuario = (int)resultado["IdUsuario"], 
                                    Direccion = (string)resultado["Direccion"], 
                                    Telefono = (string)resultado["Telefono"],
                                    Dimencion = (string)resultado["Dimencion"],
                                    PrecioHora = (decimal)resultado["PrecioHora"],  
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
        
        public EstacionamientoDOM Modificar(EstacionamientoDOM Entidad)
        {
            EstacionamientoDOM Modificado = null;
            try
            {
                string sql = @"UPDATE dbo.Estacionamiento SET Direccion=@Direccion , Telefono=@Telefono, PrecioHora = @PrecioHora, Dimencion=@Dimencion WHERE IdEstacionamiento=@IdEstacionamiento";
                using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdEstacionamiento", Entidad.IdEstacionamiento)); 
                        comando.Parameters.Add(new SqlParameter("@Direccion", Entidad.Direccion));
                        comando.Parameters.Add(new SqlParameter("@Telefono", Entidad.Telefono));
                        comando.Parameters.Add(new SqlParameter("@PrecioHora", Entidad.PrecioHora));
                        comando.Parameters.Add(new SqlParameter("@Dimencion", Entidad.Dimencion)); 
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

        public void Eliminar(string IdEstacionamiento)
        {
            string sql = "UPDATE dbo.Estacionamiento SET FlgActivo=@FlgActivo WHERE IdEstacionamiento=@IdEstacionamiento";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@IdEstacionamiento", System.Data.SqlDbType.Int, 0, IdEstacionamiento)); 
                    comando.Parameters.Add(new SqlParameter("@FlgActivo", 0));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<EstacionamientoDOM> Listar()
        {
            List<EstacionamientoDOM> Encontrados = new List<EstacionamientoDOM>(); 
            string sql = "SELECT * FROM dbo.Estacionamiento where FlgActivo = 1";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        { 
                            Encontrados.Add(new EstacionamientoDOM()
                            {
                                IdEstacionamiento = (int)resultado["IdEstacionamiento"],
                                IdUsuario = (int)resultado["IdUsuario"],
                                Direccion = (string)resultado["Direccion"],
                                Telefono = (string)resultado["Telefono"],
                                Dimencion = (string)resultado["Dimencion"],
                                PrecioHora = (decimal)resultado["PrecioHora"],
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
    }
}