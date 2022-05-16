using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        #region Metodos publicos

        public static List<Entidades.Usuario> Listar()
        {

            DataTable dt = new DataTable();
            dt =  Datos.Usuarios.Listar();

            List<Entidades.Usuario> listaUsuarios = new List<Entidades.Usuario>();

            foreach (DataRow item in dt.Rows)
            {
                listaUsuarios.Add(ArmarDatos(item));
            }


            return listaUsuarios;
        }

        public static Entidades.Usuario Obtener(int idUsuario)
        {
            DataTable dt = new DataTable();
            dt = Datos.Usuarios.Obtener(idUsuario);

            return ArmarDatos(dt.Rows[0]);
        }

        public static Entidades.Usuario Obtener(string email, string clave)
        {
            DataTable dt = new DataTable();
            //dt = Datos.Usuarios.Obtener(email, Utilidades.Seguridad.Encriptar(clave));
            dt = Datos.Usuarios.Obtener(email, clave);

            if (dt.Rows.Count > 0)
                return ArmarDatos(dt.Rows[0]);
            else
                return null;
        }

        public static Entidades.Usuario Obtener(string email)
        {
            DataTable dt = new DataTable();
            dt = Datos.Usuarios.Obtener(email, "");

            if (dt.Rows.Count > 0)
                return ArmarDatos(dt.Rows[0]);
            else
                return null;
        }

        public static void CambiarEstado(int idUsuario,Entidades.Enumerables.Estados Estado)
        {
           Datos.Usuarios.CambiarEstado(idUsuario, (int)Estado);
        }

        public static int Grabar(Entidades.Usuario usuario)
        {
            try
            {
                if (esValida(usuario, out string error))
                {
                    if (usuario.IdUsuario == null)
                        return Insertar(usuario);
                    else
                        return Modificar(usuario);
                }
                else
                    throw new Exception(error);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        #endregion

        #region Metodos privados

        private static int Insertar(Entidades.Usuario usuario)
        {
           return  Datos.Usuarios.Insertar (usuario);
        }

        private static int Modificar(Entidades.Usuario usuario)
        {
            Datos.Usuarios.Modificar(usuario);
            
            return usuario.IdUsuario.Value;
        }

        private static bool esValida(Entidades.Usuario usuario, out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(usuario.Nombre))
                error += "El nombre ingresado se encuentra vacio; ";


            if (string.IsNullOrEmpty(usuario.Apellido))
                error += "El Apellido ingresado se encuentra vacio; ";


            if (string.IsNullOrEmpty(usuario.Direccion))
                error += "La Direccion ingresado se encuentra vacia; ";


            if (usuario.Edad <=0)
                error += "La Edad ingresada no es válida. Tiene que ser mayor a 0; ";


            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private static Entidades.Usuario ArmarDatos(DataRow item)
        {
            Entidades.Usuario Usuario = new Entidades.Usuario();
            
            
            Usuario.IdUsuario = Convert.ToInt32(item["IdUsuario"]);
            Usuario.Nombre = item["Nombre"].ToString();
            Usuario.Apellido = item["Apellido"].ToString();
           // Usuario.Permiso = Permiso.Obtener(Convert.ToInt32(item["IdPermiso"]));
            Usuario.Estado = (Entidades.Enumerables.Estados)(Convert.ToInt32(item["IdEstado"]));
            Usuario.Clave = item["Clave"].ToString();
            Usuario.Direccion = item["Direccion"].ToString();
            Usuario.Email = item["Email"].ToString();

            if (item["IdTipoUsuario"] != null)
                Usuario.TipoUsuario = (Entidades.Enumerables.TipoUsuarios)(Convert.ToInt32(item["IdTipoUsuario"]));
            else
                Usuario.TipoUsuario = Entidades.Enumerables.TipoUsuarios.SinTipo;

            return Usuario;
        }

        #endregion

    }
}
