namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SSDFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.SataSSDs", "Id", "public.DiskDrives");
            DropIndex("public.DiskDrives", new[] { "SSDController_Id" });
            CreateTable(
                "public.SSDs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SSDController_Id = c.Long(),
                        TBW = c.Int(nullable: false),
                        DWPD = c.Single(nullable: false),
                        BitsForCell = c.Short(nullable: false),
                        SSDControllerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.DiskDrives", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.SSDController_Id);
            
            AddForeignKey("public.SataSSDs", "Id", "public.SSDs", "Id");
            DropColumn("public.DiskDrives", "SSDController_Id");
            DropColumn("public.DiskDrives", "TBW");
            DropColumn("public.DiskDrives", "DWPD");
            DropColumn("public.DiskDrives", "BitsForCell");
            DropColumn("public.DiskDrives", "SSDControllerId");
        }
        
        public override void Down()
        {
            AddColumn("public.DiskDrives", "SSDControllerId", c => c.Int());
            AddColumn("public.DiskDrives", "BitsForCell", c => c.Short());
            AddColumn("public.DiskDrives", "DWPD", c => c.Single());
            AddColumn("public.DiskDrives", "TBW", c => c.Int());
            AddColumn("public.DiskDrives", "SSDController_Id", c => c.Long());
            DropForeignKey("public.SataSSDs", "Id", "public.SSDs");
            DropForeignKey("public.SSDs", "Id", "public.DiskDrives");
            DropIndex("public.SSDs", new[] { "SSDController_Id" });
            DropIndex("public.SSDs", new[] { "Id" });
            DropTable("public.SSDs");
            CreateIndex("public.DiskDrives", "SSDController_Id");
            AddForeignKey("public.SataSSDs", "Id", "public.DiskDrives", "Id");
        }
    }
}
