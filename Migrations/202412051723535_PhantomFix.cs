namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhantomFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Displays", "ScreedDiagonal", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Displays", "ScreedDiagonal");
        }
    }
}
