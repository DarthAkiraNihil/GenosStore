namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiskSCCFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.HDDs", "Id", "public.Items");
            DropForeignKey("public.SataSSDs", "Id", "public.Items");
            DropIndex("public.Items", new[] { "SSDController_Id" });
            CreateTable(
                "public.DiskDrives",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Capacity = c.Long(nullable: false),
                        ReadSpeed = c.Long(nullable: false),
                        WriteSpeed = c.Long(nullable: false),
                        SSDController_Id = c.Long(),
                        TBW = c.Int(),
                        DWPD = c.Single(),
                        BitsForCell = c.Short(),
                        SSDControllerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.SSDController_Id);
            
            AddForeignKey("public.HDDs", "Id", "public.DiskDrives", "Id");
            AddForeignKey("public.SataSSDs", "Id", "public.DiskDrives", "Id");
            DropColumn("public.Items", "Capacity");
            DropColumn("public.Items", "ReadSpeed");
            DropColumn("public.Items", "WriteSpeed");
            DropColumn("public.Items", "TBW");
            DropColumn("public.Items", "DWPD");
            DropColumn("public.Items", "BitsForCell");
            DropColumn("public.Items", "SSDControllerId");
            DropColumn("public.Items", "SSDController_Id");
        }
        
        public override void Down()
        {
            AddColumn("public.Items", "SSDController_Id", c => c.Long());
            AddColumn("public.Items", "SSDControllerId", c => c.Int());
            AddColumn("public.Items", "BitsForCell", c => c.Short());
            AddColumn("public.Items", "DWPD", c => c.Single());
            AddColumn("public.Items", "TBW", c => c.Int());
            AddColumn("public.Items", "WriteSpeed", c => c.Long());
            AddColumn("public.Items", "ReadSpeed", c => c.Long());
            AddColumn("public.Items", "Capacity", c => c.Long());
            DropForeignKey("public.SataSSDs", "Id", "public.DiskDrives");
            DropForeignKey("public.HDDs", "Id", "public.DiskDrives");
            DropForeignKey("public.DiskDrives", "Id", "public.Items");
            DropIndex("public.DiskDrives", new[] { "SSDController_Id" });
            DropIndex("public.DiskDrives", new[] { "Id" });
            DropTable("public.DiskDrives");
            CreateIndex("public.Items", "SSDController_Id");
            AddForeignKey("public.SataSSDs", "Id", "public.Items", "Id");
            AddForeignKey("public.HDDs", "Id", "public.Items", "Id");
        }
    }
}
