namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemsFix : DbMigration
    {
        public override void Up()
        {
            DropIndex("public.Items", new[] { "CPUId" });
            DropIndex("public.Items", new[] { "MotherboardId" });
            DropIndex("public.Items", new[] { "GraphicsCardId" });
            DropIndex("public.Items", new[] { "PowerSupplyId" });
            DropIndex("public.Items", new[] { "DisplayId" });
            DropIndex("public.Items", new[] { "KeyboardId" });
            DropIndex("public.Items", new[] { "MouseId" });
            DropIndex("public.Items", new[] { "CPUCoolerId" });
            CreateTable(
                "public.PreparedAssemblies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CPUId = c.Int(nullable: false),
                        MotherboardId = c.Int(nullable: false),
                        GraphicsCardId = c.Int(nullable: false),
                        PowerSupplyId = c.Int(nullable: false),
                        DisplayId = c.Int(),
                        ComputerCaseId = c.Int(nullable: false),
                        KeyboardId = c.Int(),
                        MouseId = c.Int(),
                        CPUCoolerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.CPUId)
                .Index(t => t.MotherboardId)
                .Index(t => t.GraphicsCardId)
                .Index(t => t.PowerSupplyId)
                .Index(t => t.DisplayId)
                .Index(t => t.KeyboardId)
                .Index(t => t.MouseId)
                .Index(t => t.CPUCoolerId);
            
            AlterColumn("public.Items", "Discriminator", c => c.String(maxLength: 128));
            CreateIndex("public.Displays", "DefinitionId");
            AddForeignKey("public.Displays", "DefinitionId", "public.Definitions", "Id", cascadeDelete: true);
            DropColumn("public.Items", "CPUId");
            DropColumn("public.Items", "MotherboardId");
            DropColumn("public.Items", "GraphicsCardId");
            DropColumn("public.Items", "PowerSupplyId");
            DropColumn("public.Items", "DisplayId");
            DropColumn("public.Items", "ComputerCaseId");
            DropColumn("public.Items", "KeyboardId");
            DropColumn("public.Items", "MouseId");
            DropColumn("public.Items", "CPUCoolerId");
        }
        
        public override void Down()
        {
            AddColumn("public.Items", "CPUCoolerId", c => c.Int());
            AddColumn("public.Items", "MouseId", c => c.Int());
            AddColumn("public.Items", "KeyboardId", c => c.Int());
            AddColumn("public.Items", "ComputerCaseId", c => c.Int());
            AddColumn("public.Items", "DisplayId", c => c.Int());
            AddColumn("public.Items", "PowerSupplyId", c => c.Int());
            AddColumn("public.Items", "GraphicsCardId", c => c.Int());
            AddColumn("public.Items", "MotherboardId", c => c.Int());
            AddColumn("public.Items", "CPUId", c => c.Int());
            DropForeignKey("public.PreparedAssemblies", "Id", "public.Items");
            DropForeignKey("public.Displays", "DefinitionId", "public.Definitions");
            DropIndex("public.PreparedAssemblies", new[] { "CPUCoolerId" });
            DropIndex("public.PreparedAssemblies", new[] { "MouseId" });
            DropIndex("public.PreparedAssemblies", new[] { "KeyboardId" });
            DropIndex("public.PreparedAssemblies", new[] { "DisplayId" });
            DropIndex("public.PreparedAssemblies", new[] { "PowerSupplyId" });
            DropIndex("public.PreparedAssemblies", new[] { "GraphicsCardId" });
            DropIndex("public.PreparedAssemblies", new[] { "MotherboardId" });
            DropIndex("public.PreparedAssemblies", new[] { "CPUId" });
            DropIndex("public.PreparedAssemblies", new[] { "Id" });
            DropIndex("public.Displays", new[] { "DefinitionId" });
            AlterColumn("public.Items", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("public.PreparedAssemblies");
            CreateIndex("public.Items", "CPUCoolerId");
            CreateIndex("public.Items", "MouseId");
            CreateIndex("public.Items", "KeyboardId");
            CreateIndex("public.Items", "DisplayId");
            CreateIndex("public.Items", "PowerSupplyId");
            CreateIndex("public.Items", "GraphicsCardId");
            CreateIndex("public.Items", "MotherboardId");
            CreateIndex("public.Items", "CPUId");
        }
    }
}
