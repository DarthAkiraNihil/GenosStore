namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDNotRequired : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "public.DCPUSocket", newName: "CPUSocket");
            AddColumn("public.ComputerCases", "Length", c => c.Single(nullable: false));
            DropColumn("public.ComputerCases", "Lenght");
        }
        
        public override void Down()
        {
            AddColumn("public.ComputerCases", "Lenght", c => c.Single(nullable: false));
            DropColumn("public.ComputerCases", "Length");
            RenameTable(name: "public.CPUSocket", newName: "DCPUSocket");
        }
    }
}
