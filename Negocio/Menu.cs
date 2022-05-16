using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Menu
    {
     
        #region Metodos publicos
        
        public static List<Entidades.Menu> Buscar(int idUsuario)
        {
            DataTable dt = new DataTable();
            dt = Datos.Menus.Buscar(idUsuario);
            List<Entidades.Menu> ListaUsuarios = new List<Entidades.Menu>();

            foreach (DataRow item in dt.Rows)
            {
                ListaUsuarios.Add(ArmarDatos(item));
            }
           
            return ListaUsuarios;
        }

        #endregion

        #region Metodos privados
       
        private static Entidades.Menu ArmarDatos(DataRow item)
        {
            Entidades.Menu Menu = new Entidades.Menu();
            Menu.IdMenu = Convert.ToInt32(item["IdMenu"]);
            Menu.Descripcion = item["Descripcion"].ToString();
            Menu.Controlador = item["Controlador"].ToString();
            Menu.Accion = item["Accion"].ToString();
            Menu.Activo = Convert.ToBoolean(item["Activo"]);

            return Menu;
        }
        #endregion
    }
}
