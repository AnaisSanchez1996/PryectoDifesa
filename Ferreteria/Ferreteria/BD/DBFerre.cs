using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ferreteria.BD
{
    public class DBFerre: DbContext
    {

        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<Producto> Productos { get; set; }
        public IDbSet<Local> Locals { get; set; }
        public IDbSet<Venta> Ventas { get; set; }

        public DBFerre()
        {
            Database.SetInitializer<DBFerre>(null);  //Para no tener problemas con la base de datos al modificar
        }
        //public DbEntities()
        //{
        //    Database.SetInitializer<DbEntities>(null);  //Para no tener problemas con la base de datos al modificar
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

           

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ProductoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new VentaMap());
            modelBuilder.Configurations.Add(new LocalMap());
           




        }


    }
}