using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ferreteria.BD
{
    public class LocalMap: EntityTypeConfiguration<Local>
    {

        public LocalMap()
        {
            ToTable("Local");
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
        }

    }
}