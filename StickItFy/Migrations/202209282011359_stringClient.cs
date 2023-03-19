namespace StickItFy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringClient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carts", "ClientId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carts", "ClientId", c => c.Int(nullable: false));
        }
    }
}
