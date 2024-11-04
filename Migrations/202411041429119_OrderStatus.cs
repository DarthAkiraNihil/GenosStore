namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderStatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.Orders", "Status_Id", "public.OrderStatus");
            DropIndex("public.Orders", new[] { "Status_Id" });
            AlterColumn("public.Orders", "Status_Id", c => c.Long(nullable: false));
            CreateIndex("public.Orders", "Status_Id");
            AddForeignKey("public.Orders", "Status_Id", "public.OrderStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("public.Orders", "Status_Id", "public.OrderStatus");
            DropIndex("public.Orders", new[] { "Status_Id" });
            AlterColumn("public.Orders", "Status_Id", c => c.Long());
            CreateIndex("public.Orders", "Status_Id");
            AddForeignKey("public.Orders", "Status_Id", "public.OrderStatus", "Id");
        }
    }
}
