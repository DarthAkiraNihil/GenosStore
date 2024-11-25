namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartItems : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "public.CartItems", name: "Item_Id", newName: "ItemId");
            RenameIndex(table: "public.CartItems", name: "IX_Item_Id", newName: "IX_ItemId");
            DropPrimaryKey("public.CartItems");
            AddColumn("public.Carts", "Item_Id", c => c.Int());
            AddColumn("public.CartItems", "CartId", c => c.Int(nullable: false));
            AddColumn("public.CartItems", "Quantity", c => c.Int(nullable: false));
            AddPrimaryKey("public.CartItems", new[] { "CartId", "ItemId" });
            CreateIndex("public.Carts", "Item_Id");
            AddForeignKey("public.Carts", "Item_Id", "public.Items", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("public.Carts", "Item_Id", "public.Items");
            DropIndex("public.Carts", new[] { "Item_Id" });
            DropPrimaryKey("public.CartItems");
            DropColumn("public.CartItems", "Quantity");
            DropColumn("public.CartItems", "CartId");
            DropColumn("public.Carts", "Item_Id");
            AddPrimaryKey("public.CartItems", new[] { "Cart_CustomerId", "Item_Id" });
            RenameIndex(table: "public.CartItems", name: "IX_ItemId", newName: "IX_Item_Id");
            RenameColumn(table: "public.CartItems", name: "ItemId", newName: "Item_Id");
        }
    }
}
