namespace Ferreteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Password");
        }
    }
}
