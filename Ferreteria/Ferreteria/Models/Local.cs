using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ferreteria.Models
{
    public class Local
    {
        public int Id { get; set; }
        public string NLocal { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string NombreU { get; set; }       
        //public Usuario Usuario { get; set; }
        public List<Producto> Productos { get; set; }
    }
}