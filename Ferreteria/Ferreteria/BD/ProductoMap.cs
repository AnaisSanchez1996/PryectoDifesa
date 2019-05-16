using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ferreteria.BD
{
    public class ProductoMap: EntityTypeConfiguration<Producto>
    {
        public ProductoMap()
        {
            ToTable("Producto");
            HasKey(o => o.Id);
            HasRequired(s => s.Local).WithMany(g => g.Productos).HasForeignKey(s => s.IdLocal);
            HasMany(s => s.Ventas)
                .WithMany(c => c.Productos)
                .Map(cs =>
                {
                    cs.MapLeftKey("CodigoP");
                    cs.MapRightKey("CodigoV");
                    cs.ToTable("ProductoVentas");
                    Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                });

        }




    }
}