namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SSDFix2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.NVMeSSDs", "Id", "public.Items");
            AddForeignKey("public.NVMeSSDs", "Id", "public.SSDs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("public.NVMeSSDs", "Id", "public.SSDs");
            AddForeignKey("public.NVMeSSDs", "Id", "public.Items", "Id");
        }
    }
}
