namespace Ferreteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Local", "NombreU", c => c.String());
            DropColumn("dbo.Local", "IdUsuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Local", "IdUsuario", c => c.Int(nullable: false));
            DropColumn("dbo.Local", "NombreU");
        }
    }
}
