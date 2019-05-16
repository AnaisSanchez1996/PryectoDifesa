using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferreteria.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string NombreP { get; set; }
        public int Stock { get; set; }
        public float Precio { get; set; }
        public int IdLocal { get; set; }
        public Local Local { get; set; }
        public List<Venta> Ventas { get; set; }

    }
}