namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItemsFix : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("public.OrderedItems");
            AddPrimaryKey("public.OrderedItems", new[] { "OrderId", "ItemId" });
            DropColumn("public.OrderedItems", "Id");
        }
        
        public override void Down()
        {
            AddColumn("public.OrderedItems", "Id", c => c.Long(nullable: false, identity: true));
            DropPrimaryKey("public.OrderedItems");
            AddPrimaryKey("public.OrderedItems", "Id");
        }
    }
}
