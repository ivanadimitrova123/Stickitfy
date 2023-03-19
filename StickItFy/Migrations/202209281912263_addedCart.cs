namespace StickItFy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StickerCarts",
                c => new
                    {
                        Sticker_Id = c.Int(nullable: false),
                        Cart_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sticker_Id, t.Cart_Id })
                .ForeignKey("dbo.Stickers", t => t.Sticker_Id, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_Id, cascadeDelete: true)
                .Index(t => t.Sticker_Id)
                .Index(t => t.Cart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StickerCarts", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.StickerCarts", "Sticker_Id", "dbo.Stickers");
            DropIndex("dbo.StickerCarts", new[] { "Cart_Id" });
            DropIndex("dbo.StickerCarts", new[] { "Sticker_Id" });
            DropTable("dbo.StickerCarts");
            DropTable("dbo.Carts");
        }
    }
}
