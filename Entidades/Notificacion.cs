using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Notificacion
    {
        public int?  IdNotificacion { get; set; }
        public Usuario UsuarioReceptor { get; set; }
        public Usuario UsuarioEmisor { get; set; }
        public string Descripcion { get; set; }
        public bool Vista { get; set; }
        public DateTime Fecha { get; set; }
    }
}
