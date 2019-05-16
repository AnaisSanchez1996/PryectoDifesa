using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferreteria.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string CodigoV { get; set; }
        public DateTime FechaV { get; set; }
        public int IdUsuario { get; set; }
        public List<Producto> Productos { get; set; }
        public Usuario Usuarios { get; set; }
    }
}