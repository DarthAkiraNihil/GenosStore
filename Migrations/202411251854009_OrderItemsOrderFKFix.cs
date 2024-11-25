namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItemsOrderFKFix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "public.OrderedItems", newName: "OrderItems");
            DropIndex("public.OrderItems", new[] { "Order_Id" });
            DropColumn("public.OrderItems", "OrderId");
            RenameColumn(table: "public.OrderItems", name: "Order_Id", newName: "OrderId");
            DropPrimaryKey("public.OrderItems");
            AlterColumn("public.OrderItems", "OrderId", c => c.Long(nullable: false));
            AddPrimaryKey("public.OrderItems", new[] { "OrderId", "ItemId" });
            CreateIndex("public.OrderItems", "OrderId");
        }
        
        public override void Down()
        {
            DropIndex("public.OrderItems", new[] { "OrderId" });
            DropPrimaryKey("public.OrderItems");
            AlterColumn("public.OrderItems", "OrderId", c => c.Int(nullable: false));
            AddPrimaryKey("public.OrderItems", new[] { "OrderId", "ItemId" });
            RenameColumn(table: "public.OrderItems", name: "OrderId", newName: "Order_Id");
            AddColumn("public.OrderItems", "OrderId", c => c.Int(nullable: false));
            CreateIndex("public.OrderItems", "Order_Id");
            RenameTable(name: "public.OrderItems", newName: "OrderedItems");
        }
    }
}
