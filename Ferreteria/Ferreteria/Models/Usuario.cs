using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferreteria.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        //public Local Local { get; set; }
        public List<Venta> Ventas { get; set; }

        //public int Id { get; set; }
        //public string CodigoP { get; set; }
        //public string CodigoVentaV { get; set; }
        //public float Precio { get; set; }
        //public float Total { get; set; }
        //public Venta Ventas { get; set; }
        //public Producto Productos { get; set; }

    }
}