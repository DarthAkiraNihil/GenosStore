namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemTypeAndCarts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.Items", "Cart_CustomerId", "public.Carts");
            DropIndex("public.Items", new[] { "Cart_CustomerId" });
            CreateTable(
                "public.ItemTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.CartItems",
                c => new
                    {
                        Cart_CustomerId = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cart_CustomerId, t.Item_Id })
                .ForeignKey("public.Carts", t => t.Cart_CustomerId, cascadeDelete: true)
                .ForeignKey("public.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Cart_CustomerId)
                .Index(t => t.Item_Id);
            
            CreateIndex("public.Items", "ItemTypeId");
            AddForeignKey("public.Items", "ItemTypeId", "public.ItemTypes", "Id", cascadeDelete: true);
            DropColumn("public.Items", "ItemType");
            DropColumn("public.Items", "Cart_CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("public.Items", "Cart_CustomerId", c => c.Int());
            AddColumn("public.Items", "ItemType", c => c.Int(nullable: false));
            DropForeignKey("public.CartItems", "Item_Id", "public.Items");
            DropForeignKey("public.CartItems", "Cart_CustomerId", "public.Carts");
            DropForeignKey("public.Items", "ItemTypeId", "public.ItemTypes");
            DropIndex("public.CartItems", new[] { "Item_Id" });
            DropIndex("public.CartItems", new[] { "Cart_CustomerId" });
            DropIndex("public.Items", new[] { "ItemTypeId" });
            DropTable("public.CartItems");
            DropTable("public.ItemTypes");
            CreateIndex("public.Items", "Cart_CustomerId");
            AddForeignKey("public.Items", "Cart_CustomerId", "public.Carts", "CustomerId");
        }
    }
}
