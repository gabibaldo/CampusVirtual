using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Notificaciones
    {
        public static DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("Notificaciones_Listar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Notificaciones: " + ex.Message);
            }
        }

        public static DataTable ListarporUsuarioEmisor(int idUsuarioEmisor)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_ListarporUsuarioEmisor", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdNotificacion", idUsuarioEmisor));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Notificaciones: " + ex.Message);
            }
        }

        public static DataTable ListarporUsuarioReceptor(int idUsuarioReceptor)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_ListarporUsuarioReceptor", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioReceptor", idUsuarioReceptor));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Notificaciones: " + ex.Message);
            }
        }

        public static int Insertar(Entidades.Notificacion Notificacion)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_Insertar", cn);



                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioReceptor", Notificacion.UsuarioReceptor.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioEmisor", Notificacion.UsuarioEmisor.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Descripción", Notificacion.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Vista", Notificacion.Vista));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", DateTime.Now));


                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la Notificacion: " + ex.Message);
            }
        }

        public static void Modificar(Entidades.Notificacion Notificacion)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_Modificar", cn);



                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdNotificacion", Notificacion.IdNotificacion));
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioReceptor", Notificacion.UsuarioReceptor.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioEmisor", Notificacion.UsuarioEmisor.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Descripción", Notificacion.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Vista", Notificacion.Vista));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", DateTime.Now));


                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al Modificar la Notificacion: " + ex.Message);
            }
        }

        public static void Eliminar(int idNotificacion)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_Eliminar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdNotificacion", idNotificacion));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Eliminar la Notificacion: " + ex.Message);
            }
        }

    }
}
