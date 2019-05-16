using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ferreteria.BD
{
    public class VentaMap: EntityTypeConfiguration<Venta>
    {
        public VentaMap()
        {
            ToTable("Venta");
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(s => s.Usuarios).WithMany(g => g.Ventas).HasForeignKey(s => s.IdUsuario);
        }
    }
}