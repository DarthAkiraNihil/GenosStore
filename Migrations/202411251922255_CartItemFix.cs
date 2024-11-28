namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartItemFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("public.CartItems", "CartId");
            RenameColumn(table: "public.CartItems", name: "Cart_CustomerId", newName: "CartId");
            RenameIndex(table: "public.CartItems", name: "IX_Cart_CustomerId", newName: "IX_CartId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "public.CartItems", name: "IX_CartId", newName: "IX_Cart_CustomerId");
            RenameColumn(table: "public.CartItems", name: "CartId", newName: "Cart_CustomerId");
            AddColumn("public.CartItems", "CartId", c => c.Int(nullable: false));
        }
    }
}
