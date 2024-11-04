namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderStatusFix : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "public.Orders", name: "Status_Id", newName: "OrderStatus_Id");
            RenameIndex(table: "public.Orders", name: "IX_Status_Id", newName: "IX_OrderStatus_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "public.Orders", name: "IX_OrderStatus_Id", newName: "IX_Status_Id");
            RenameColumn(table: "public.Orders", name: "OrderStatus_Id", newName: "Status_Id");
        }
    }
}
