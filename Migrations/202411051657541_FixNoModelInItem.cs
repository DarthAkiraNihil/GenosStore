namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNoModelInItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Items", "Model", c => c.String());
            AddColumn("public.Items", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("public.Items", "Name");
            DropColumn("public.Items", "Model");
        }
    }
}
