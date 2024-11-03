namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumToTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.CPUCores", "Motherboard_Id", "public.Motherboards");
            DropForeignKey("public.Items", "Discount_Id", "public.Discounts");
            DropForeignKey("public.OrderOrderedItems", "Order_Id", "public.Orders");
            DropForeignKey("public.OrderOrderedItems", "OrderedItem_Id", "public.OrderedItems");
            DropForeignKey("public.Orders", "Customer_Id", "public.Users");
            DropForeignKey("public.Motherboards", "AudioChipset_Id", "public.AudioChipsets");
            DropForeignKey("public.Motherboards", "MotherboardChipset_Id", "public.MotherboardChipsets");
            DropForeignKey("public.Motherboards", "NetworkAdapter_Id", "public.NetworkAdapters");
            DropForeignKey("public.SSDs", "SSDController_Id", "public.SSDControllers");
            DropIndex("public.Items", new[] { "Discount_Id" });
            DropIndex("public.CPUCores", new[] { "Motherboard_Id" });
            DropIndex("public.Orders", new[] { "Customer_Id" });
            DropIndex("public.OrderOrderedItems", new[] { "Order_Id" });
            DropIndex("public.OrderOrderedItems", new[] { "OrderedItem_Id" });
            DropIndex("public.Motherboards", new[] { "AudioChipset_Id" });
            DropIndex("public.Motherboards", new[] { "MotherboardChipset_Id" });
            DropIndex("public.Motherboards", new[] { "NetworkAdapter_Id" });
            DropIndex("public.SSDs", new[] { "SSDController_Id" });
            RenameColumn(table: "public.Orders", name: "Customer_Id", newName: "CustomerId");
            DropPrimaryKey("public.AudioChipsets");
            DropPrimaryKey("public.MotherboardChipsets");
            DropPrimaryKey("public.NetworkAdapters");
            DropPrimaryKey("public.SSDControllers");
            CreateTable(
                "public.SimpleComputerComponents",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SimpleComputerComponentTypeId = c.Int(nullable: false),
                        Model = c.String(),
                        Name = c.String(),
                        Type_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.SimpleComputerComponentTypes", t => t.Type_Id, cascadeDelete: true)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "public.SimpleComputerComponentTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.BankSystems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Certificates80Plus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.CoolerMaterials",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.ComputerCaseTypesizes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.MotherboardFormFactors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.DCPUSocket",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.PCIEVersions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.RAMTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.VideoPorts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.MatrixTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Underlights",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.VesaSizes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.DPIModes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DPI = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.KeyboardType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.KeyboardTypesizes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.OrderedItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        BoughtFor = c.Double(nullable: false),
                        Order_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("public.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "public.OrderStatus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.ComputerCaseMotherboardFormFactors",
                c => new
                    {
                        ComputerCase_Id = c.Int(nullable: false),
                        MotherboardFormFactor_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ComputerCase_Id, t.MotherboardFormFactor_Id })
                .ForeignKey("public.ComputerCases", t => t.ComputerCase_Id, cascadeDelete: true)
                .ForeignKey("public.MotherboardFormFactors", t => t.MotherboardFormFactor_Id, cascadeDelete: true)
                .Index(t => t.ComputerCase_Id)
                .Index(t => t.MotherboardFormFactor_Id);
            
            CreateTable(
                "public.MotherboardCPUCores",
                c => new
                    {
                        Motherboard_Id = c.Int(nullable: false),
                        CPUCore_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Motherboard_Id, t.CPUCore_Id })
                .ForeignKey("public.Motherboards", t => t.Motherboard_Id, cascadeDelete: true)
                .ForeignKey("public.CPUCores", t => t.CPUCore_Id, cascadeDelete: true)
                .Index(t => t.Motherboard_Id)
                .Index(t => t.CPUCore_Id);
            
            CreateTable(
                "public.CPURAMTypes",
                c => new
                    {
                        CPU_Id = c.Int(nullable: false),
                        RAMType_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.CPU_Id, t.RAMType_Id })
                .ForeignKey("public.CPUs", t => t.CPU_Id, cascadeDelete: true)
                .ForeignKey("public.RAMTypes", t => t.RAMType_Id, cascadeDelete: true)
                .Index(t => t.CPU_Id)
                .Index(t => t.RAMType_Id);
            
            CreateTable(
                "public.MotherboardRAMTypes",
                c => new
                    {
                        Motherboard_Id = c.Int(nullable: false),
                        RAMType_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Motherboard_Id, t.RAMType_Id })
                .ForeignKey("public.Motherboards", t => t.Motherboard_Id, cascadeDelete: true)
                .ForeignKey("public.RAMTypes", t => t.RAMType_Id, cascadeDelete: true)
                .Index(t => t.Motherboard_Id)
                .Index(t => t.RAMType_Id);
            
            CreateTable(
                "public.GraphicsCardVideoPorts",
                c => new
                    {
                        GraphicsCard_Id = c.Int(nullable: false),
                        VideoPort_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.GraphicsCard_Id, t.VideoPort_Id })
                .ForeignKey("public.GraphicsCards", t => t.GraphicsCard_Id, cascadeDelete: true)
                .ForeignKey("public.VideoPorts", t => t.VideoPort_Id, cascadeDelete: true)
                .Index(t => t.GraphicsCard_Id)
                .Index(t => t.VideoPort_Id);
            
            CreateTable(
                "public.MotherboardVideoPorts",
                c => new
                    {
                        Motherboard_Id = c.Int(nullable: false),
                        VideoPort_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Motherboard_Id, t.VideoPort_Id })
                .ForeignKey("public.Motherboards", t => t.Motherboard_Id, cascadeDelete: true)
                .ForeignKey("public.VideoPorts", t => t.VideoPort_Id, cascadeDelete: true)
                .Index(t => t.Motherboard_Id)
                .Index(t => t.VideoPort_Id);
            
            CreateTable(
                "public.MouseDPIModes",
                c => new
                    {
                        Mouse_Id = c.Int(nullable: false),
                        DPIMode_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Mouse_Id, t.DPIMode_Id })
                .ForeignKey("public.Mouses", t => t.Mouse_Id, cascadeDelete: true)
                .ForeignKey("public.DPIModes", t => t.DPIMode_Id, cascadeDelete: true)
                .Index(t => t.Mouse_Id)
                .Index(t => t.DPIMode_Id);
            
            AddColumn("public.BankCards", "BankSystemId", c => c.Int(nullable: false));
            AddColumn("public.BankCards", "BankSystem_Id", c => c.Long(nullable: false));
            AddColumn("public.ComputerCases", "ComputerCaseTypesize_Id", c => c.Long(nullable: false));
            AddColumn("public.ComputerCases", "ComputerCaseTypesizeId", c => c.Int(nullable: false));
            AddColumn("public.Items", "ItemTypeId", c => c.Int(nullable: false));
            AddColumn("public.Items", "ItemType", c => c.Int(nullable: false));
            AddColumn("public.CPUCoolers", "FoundationMaterial_Id", c => c.Long(nullable: false));
            AddColumn("public.CPUCoolers", "RadiatorMaterial_Id", c => c.Long(nullable: false));
            AddColumn("public.CPUCoolers", "FoundationMaterialId", c => c.Int(nullable: false));
            AddColumn("public.CPUCoolers", "RadiatroMaterialId", c => c.Int(nullable: false));
            AddColumn("public.CPUs", "CPUSocket_Id", c => c.Long(nullable: false));
            AddColumn("public.CPUs", "CPUSockerId", c => c.Int(nullable: false));
            AddColumn("public.Displays", "MatrixType_Id", c => c.Long(nullable: false));
            AddColumn("public.Displays", "Underlight_Id", c => c.Long(nullable: false));
            AddColumn("public.Displays", "VesaSize_Id", c => c.Long(nullable: false));
            AddColumn("public.Displays", "MatrixTypeId", c => c.Int(nullable: false));
            AddColumn("public.Displays", "UnderlightId", c => c.Int(nullable: false));
            AddColumn("public.Displays", "VesaSizeId", c => c.Int(nullable: false));
            AddColumn("public.Keyboards", "KeyboardType_Id", c => c.Long(nullable: false));
            AddColumn("public.Keyboards", "Typesize_Id", c => c.Long(nullable: false));
            AddColumn("public.Keyboards", "KeyboardTypesizeId", c => c.Int(nullable: false));
            AddColumn("public.Keyboards", "KeyboardTypeId", c => c.Int(nullable: false));
            AddColumn("public.Motherboards", "CPUSocket_Id", c => c.Long(nullable: false));
            AddColumn("public.Motherboards", "FormFactor_Id", c => c.Long(nullable: false));
            AddColumn("public.Motherboards", "PCIEVersion_Id", c => c.Long(nullable: false));
            AddColumn("public.Motherboards", "MotherboardFormFactorId", c => c.Int(nullable: false));
            AddColumn("public.Motherboards", "CPUSocketId", c => c.Int(nullable: false));
            AddColumn("public.Motherboards", "PCIEVersionId", c => c.Int(nullable: false));
            AddColumn("public.PowerSupplies", "Certificate80Plus_Id", c => c.Long(nullable: false));
            AddColumn("public.PowerSupplies", "Certiticate80PlusId", c => c.Int(nullable: false));
            AddColumn("public.RAMs", "RAMType_Id", c => c.Long(nullable: false));
            AddColumn("public.RAMs", "RamTypeId", c => c.Int(nullable: false));
            AddColumn("public.Orders", "OrderStatusId", c => c.Int(nullable: false));
            AddColumn("public.Orders", "Status_Id", c => c.Long());
            AlterColumn("public.IndividualEntities", "Name", c => c.String());
            AlterColumn("public.IndividualEntities", "Surname", c => c.String());
            AlterColumn("public.IndividualEntities", "PhoneNumber", c => c.String());
            AlterColumn("public.LegalEntities", "PhysicalAddress", c => c.String());
            AlterColumn("public.LegalEntities", "LegalAddress", c => c.String());
            AlterColumn("public.Users", "Email", c => c.String());
            AlterColumn("public.Users", "PasswordHash", c => c.String());
            AlterColumn("public.Users", "Salt", c => c.String());
            AlterColumn("public.AudioChipsets", "Id", c => c.Long(nullable: false));
            AlterColumn("public.BankCards", "Owner", c => c.String());
            AlterColumn("public.Motherboards", "AudioChipset_Id", c => c.Long(nullable: false));
            AlterColumn("public.Motherboards", "MotherboardChipset_Id", c => c.Long(nullable: false));
            AlterColumn("public.Motherboards", "NetworkAdapter_Id", c => c.Long(nullable: false));
            AlterColumn("public.SSDs", "SSDController_Id", c => c.Long(nullable: false));
            AlterColumn("public.MotherboardChipsets", "Id", c => c.Long(nullable: false));
            AlterColumn("public.NetworkAdapters", "Id", c => c.Long(nullable: false));
            AlterColumn("public.SSDControllers", "Id", c => c.Long(nullable: false));
            AlterColumn("public.Orders", "CustomerId", c => c.Int(nullable: false));
            AddPrimaryKey("public.AudioChipsets", "Id");
            AddPrimaryKey("public.MotherboardChipsets", "Id");
            AddPrimaryKey("public.NetworkAdapters", "Id");
            AddPrimaryKey("public.SSDControllers", "Id");
            CreateIndex("public.BankCards", "BankSystem_Id");
            CreateIndex("public.Orders", "CustomerId");
            CreateIndex("public.Orders", "Status_Id");
            CreateIndex("public.AudioChipsets", "Id");
            CreateIndex("public.ComputerCases", "ComputerCaseTypesize_Id");
            CreateIndex("public.CPUCoolers", "FoundationMaterial_Id");
            CreateIndex("public.CPUCoolers", "RadiatorMaterial_Id");
            CreateIndex("public.CPUs", "CPUSocket_Id");
            CreateIndex("public.Displays", "MatrixType_Id");
            CreateIndex("public.Displays", "Underlight_Id");
            CreateIndex("public.Displays", "VesaSize_Id");
            CreateIndex("public.Keyboards", "KeyboardType_Id");
            CreateIndex("public.Keyboards", "Typesize_Id");
            CreateIndex("public.MotherboardChipsets", "Id");
            CreateIndex("public.Motherboards", "AudioChipset_Id");
            CreateIndex("public.Motherboards", "CPUSocket_Id");
            CreateIndex("public.Motherboards", "FormFactor_Id");
            CreateIndex("public.Motherboards", "MotherboardChipset_Id");
            CreateIndex("public.Motherboards", "NetworkAdapter_Id");
            CreateIndex("public.Motherboards", "PCIEVersion_Id");
            CreateIndex("public.NetworkAdapters", "Id");
            CreateIndex("public.SSDs", "SSDController_Id");
            CreateIndex("public.PowerSupplies", "Certificate80Plus_Id");
            CreateIndex("public.PreparedAssemblies", "ComputerCaseId");
            CreateIndex("public.RAMs", "RAMType_Id");
            CreateIndex("public.SSDControllers", "Id");
            AddForeignKey("public.BankCards", "BankSystem_Id", "public.BankSystems", "Id", cascadeDelete: true);
            AddForeignKey("public.Orders", "Status_Id", "public.OrderStatus", "Id");
            AddForeignKey("public.AudioChipsets", "Id", "public.SimpleComputerComponents", "Id");
            AddForeignKey("public.ComputerCases", "ComputerCaseTypesize_Id", "public.ComputerCaseTypesizes", "Id", cascadeDelete: true);
            AddForeignKey("public.CPUCoolers", "FoundationMaterial_Id", "public.CoolerMaterials", "Id", cascadeDelete: true);
            AddForeignKey("public.CPUCoolers", "RadiatorMaterial_Id", "public.CoolerMaterials", "Id", cascadeDelete: true);
            AddForeignKey("public.CPUs", "CPUSocket_Id", "public.DCPUSocket", "Id", cascadeDelete: true);
            AddForeignKey("public.Displays", "MatrixType_Id", "public.MatrixTypes", "Id", cascadeDelete: true);
            AddForeignKey("public.Displays", "Underlight_Id", "public.Underlights", "Id", cascadeDelete: true);
            AddForeignKey("public.Displays", "VesaSize_Id", "public.VesaSizes", "Id", cascadeDelete: true);
            AddForeignKey("public.Keyboards", "KeyboardType_Id", "public.KeyboardType", "Id", cascadeDelete: true);
            AddForeignKey("public.Keyboards", "Typesize_Id", "public.KeyboardTypesizes", "Id", cascadeDelete: true);
            AddForeignKey("public.MotherboardChipsets", "Id", "public.SimpleComputerComponents", "Id");
            AddForeignKey("public.Motherboards", "CPUSocket_Id", "public.DCPUSocket", "Id", cascadeDelete: true);
            AddForeignKey("public.Motherboards", "FormFactor_Id", "public.MotherboardFormFactors", "Id", cascadeDelete: true);
            AddForeignKey("public.Motherboards", "PCIEVersion_Id", "public.PCIEVersions", "Id", cascadeDelete: true);
            AddForeignKey("public.NetworkAdapters", "Id", "public.SimpleComputerComponents", "Id");
            AddForeignKey("public.PowerSupplies", "Certificate80Plus_Id", "public.Certificates80Plus", "Id", cascadeDelete: true);
            AddForeignKey("public.PreparedAssemblies", "ComputerCaseId", "public.ComputerCases", "Id");
            AddForeignKey("public.RAMs", "RAMType_Id", "public.RAMTypes", "Id", cascadeDelete: true);
            AddForeignKey("public.SSDControllers", "Id", "public.SimpleComputerComponents", "Id");
            AddForeignKey("public.Orders", "CustomerId", "public.Users", "Id", cascadeDelete: true);
            AddForeignKey("public.Motherboards", "AudioChipset_Id", "public.AudioChipsets", "Id");
            AddForeignKey("public.Motherboards", "MotherboardChipset_Id", "public.MotherboardChipsets", "Id");
            AddForeignKey("public.Motherboards", "NetworkAdapter_Id", "public.NetworkAdapters", "Id");
            AddForeignKey("public.SSDs", "SSDController_Id", "public.SSDControllers", "Id");
            DropColumn("public.ActiveDiscounts", "DiscountId");
            DropColumn("public.AudioChipsets", "Model");
            DropColumn("public.AudioChipsets", "Name");
            DropColumn("public.BankCards", "BankSystem");
            DropColumn("public.ComputerCases", "Typesize");
            DropColumn("public.Items", "Discount_Id");
            DropColumn("public.CPUCoolers", "FoundationMaterial");
            DropColumn("public.CPUCoolers", "RadiatorMaterial");
            DropColumn("public.CPUs", "Socket");
            DropColumn("public.Displays", "MatrixType");
            DropColumn("public.Displays", "UnderlightType");
            DropColumn("public.Displays", "VesaSize");
            DropColumn("public.Keyboards", "Typesize");
            DropColumn("public.Keyboards", "KeyboardType");
            DropColumn("public.Motherboards", "FormFactor");
            DropColumn("public.Motherboards", "CPUSocket");
            DropColumn("public.Motherboards", "PCIEVersion");
            DropColumn("public.PowerSupplies", "Certificate80Plus");
            DropColumn("public.RAMs", "RAMType");
            DropColumn("public.CPUCores", "Motherboard_Id");
            DropColumn("public.MotherboardChipsets", "Model");
            DropColumn("public.MotherboardChipsets", "Name");
            DropColumn("public.NetworkAdapters", "Model");
            DropColumn("public.NetworkAdapters", "Name");
            DropColumn("public.SSDControllers", "Model");
            DropColumn("public.SSDControllers", "Name");
            DropColumn("public.Orders", "Status");
            DropTable("public.Discounts");
            DropTable("public.OrderedItems");
            DropTable("public.OrderOrderedItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "public.OrderOrderedItems",
                c => new
                    {
                        Order_Id = c.Long(nullable: false),
                        OrderedItem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.OrderedItem_Id });
            
            CreateTable(
                "public.OrderedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        BoughtFor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Discounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("public.Orders", "Status", c => c.Int(nullable: false));
            AddColumn("public.SSDControllers", "Name", c => c.String());
            AddColumn("public.SSDControllers", "Model", c => c.String());
            AddColumn("public.NetworkAdapters", "Name", c => c.String());
            AddColumn("public.NetworkAdapters", "Model", c => c.String());
            AddColumn("public.MotherboardChipsets", "Name", c => c.String());
            AddColumn("public.MotherboardChipsets", "Model", c => c.String());
            AddColumn("public.CPUCores", "Motherboard_Id", c => c.Int());
            AddColumn("public.RAMs", "RAMType", c => c.Int(nullable: false));
            AddColumn("public.PowerSupplies", "Certificate80Plus", c => c.Int(nullable: false));
            AddColumn("public.Motherboards", "PCIEVersion", c => c.Int(nullable: false));
            AddColumn("public.Motherboards", "CPUSocket", c => c.Int(nullable: false));
            AddColumn("public.Motherboards", "FormFactor", c => c.Int(nullable: false));
            AddColumn("public.Keyboards", "KeyboardType", c => c.Int(nullable: false));
            AddColumn("public.Keyboards", "Typesize", c => c.Int(nullable: false));
            AddColumn("public.Displays", "VesaSize", c => c.Int(nullable: false));
            AddColumn("public.Displays", "UnderlightType", c => c.Int(nullable: false));
            AddColumn("public.Displays", "MatrixType", c => c.Int(nullable: false));
            AddColumn("public.CPUs", "Socket", c => c.Int(nullable: false));
            AddColumn("public.CPUCoolers", "RadiatorMaterial", c => c.Int(nullable: false));
            AddColumn("public.CPUCoolers", "FoundationMaterial", c => c.Int(nullable: false));
            AddColumn("public.Items", "Discount_Id", c => c.Long());
            AddColumn("public.ComputerCases", "Typesize", c => c.Int(nullable: false));
            AddColumn("public.BankCards", "BankSystem", c => c.Int(nullable: false));
            AddColumn("public.AudioChipsets", "Name", c => c.String());
            AddColumn("public.AudioChipsets", "Model", c => c.String());
            AddColumn("public.ActiveDiscounts", "DiscountId", c => c.Int(nullable: false));
            DropForeignKey("public.SSDs", "SSDController_Id", "public.SSDControllers");
            DropForeignKey("public.Motherboards", "NetworkAdapter_Id", "public.NetworkAdapters");
            DropForeignKey("public.Motherboards", "MotherboardChipset_Id", "public.MotherboardChipsets");
            DropForeignKey("public.Motherboards", "AudioChipset_Id", "public.AudioChipsets");
            DropForeignKey("public.Orders", "CustomerId", "public.Users");
            DropForeignKey("public.SSDControllers", "Id", "public.SimpleComputerComponents");
            DropForeignKey("public.RAMs", "RAMType_Id", "public.RAMTypes");
            DropForeignKey("public.PreparedAssemblies", "ComputerCaseId", "public.ComputerCases");
            DropForeignKey("public.PowerSupplies", "Certificate80Plus_Id", "public.Certificates80Plus");
            DropForeignKey("public.NetworkAdapters", "Id", "public.SimpleComputerComponents");
            DropForeignKey("public.Motherboards", "PCIEVersion_Id", "public.PCIEVersions");
            DropForeignKey("public.Motherboards", "FormFactor_Id", "public.MotherboardFormFactors");
            DropForeignKey("public.Motherboards", "CPUSocket_Id", "public.DCPUSocket");
            DropForeignKey("public.MotherboardChipsets", "Id", "public.SimpleComputerComponents");
            DropForeignKey("public.Keyboards", "Typesize_Id", "public.KeyboardTypesizes");
            DropForeignKey("public.Keyboards", "KeyboardType_Id", "public.KeyboardType");
            DropForeignKey("public.Displays", "VesaSize_Id", "public.VesaSizes");
            DropForeignKey("public.Displays", "Underlight_Id", "public.Underlights");
            DropForeignKey("public.Displays", "MatrixType_Id", "public.MatrixTypes");
            DropForeignKey("public.CPUs", "CPUSocket_Id", "public.DCPUSocket");
            DropForeignKey("public.CPUCoolers", "RadiatorMaterial_Id", "public.CoolerMaterials");
            DropForeignKey("public.CPUCoolers", "FoundationMaterial_Id", "public.CoolerMaterials");
            DropForeignKey("public.ComputerCases", "ComputerCaseTypesize_Id", "public.ComputerCaseTypesizes");
            DropForeignKey("public.AudioChipsets", "Id", "public.SimpleComputerComponents");
            DropForeignKey("public.SimpleComputerComponents", "Type_Id", "public.SimpleComputerComponentTypes");
            DropForeignKey("public.Orders", "Status_Id", "public.OrderStatus");
            DropForeignKey("public.OrderedItems", "Order_Id", "public.Orders");
            DropForeignKey("public.OrderedItems", "ItemId", "public.Items");
            DropForeignKey("public.MouseDPIModes", "DPIMode_Id", "public.DPIModes");
            DropForeignKey("public.MouseDPIModes", "Mouse_Id", "public.Mouses");
            DropForeignKey("public.MotherboardVideoPorts", "VideoPort_Id", "public.VideoPorts");
            DropForeignKey("public.MotherboardVideoPorts", "Motherboard_Id", "public.Motherboards");
            DropForeignKey("public.GraphicsCardVideoPorts", "VideoPort_Id", "public.VideoPorts");
            DropForeignKey("public.GraphicsCardVideoPorts", "GraphicsCard_Id", "public.GraphicsCards");
            DropForeignKey("public.MotherboardRAMTypes", "RAMType_Id", "public.RAMTypes");
            DropForeignKey("public.MotherboardRAMTypes", "Motherboard_Id", "public.Motherboards");
            DropForeignKey("public.CPURAMTypes", "RAMType_Id", "public.RAMTypes");
            DropForeignKey("public.CPURAMTypes", "CPU_Id", "public.CPUs");
            DropForeignKey("public.MotherboardCPUCores", "CPUCore_Id", "public.CPUCores");
            DropForeignKey("public.MotherboardCPUCores", "Motherboard_Id", "public.Motherboards");
            DropForeignKey("public.ComputerCaseMotherboardFormFactors", "MotherboardFormFactor_Id", "public.MotherboardFormFactors");
            DropForeignKey("public.ComputerCaseMotherboardFormFactors", "ComputerCase_Id", "public.ComputerCases");
            DropForeignKey("public.BankCards", "BankSystem_Id", "public.BankSystems");
            DropIndex("public.SSDControllers", new[] { "Id" });
            DropIndex("public.RAMs", new[] { "RAMType_Id" });
            DropIndex("public.PreparedAssemblies", new[] { "ComputerCaseId" });
            DropIndex("public.PowerSupplies", new[] { "Certificate80Plus_Id" });
            DropIndex("public.SSDs", new[] { "SSDController_Id" });
            DropIndex("public.NetworkAdapters", new[] { "Id" });
            DropIndex("public.Motherboards", new[] { "PCIEVersion_Id" });
            DropIndex("public.Motherboards", new[] { "NetworkAdapter_Id" });
            DropIndex("public.Motherboards", new[] { "MotherboardChipset_Id" });
            DropIndex("public.Motherboards", new[] { "FormFactor_Id" });
            DropIndex("public.Motherboards", new[] { "CPUSocket_Id" });
            DropIndex("public.Motherboards", new[] { "AudioChipset_Id" });
            DropIndex("public.MotherboardChipsets", new[] { "Id" });
            DropIndex("public.Keyboards", new[] { "Typesize_Id" });
            DropIndex("public.Keyboards", new[] { "KeyboardType_Id" });
            DropIndex("public.Displays", new[] { "VesaSize_Id" });
            DropIndex("public.Displays", new[] { "Underlight_Id" });
            DropIndex("public.Displays", new[] { "MatrixType_Id" });
            DropIndex("public.CPUs", new[] { "CPUSocket_Id" });
            DropIndex("public.CPUCoolers", new[] { "RadiatorMaterial_Id" });
            DropIndex("public.CPUCoolers", new[] { "FoundationMaterial_Id" });
            DropIndex("public.ComputerCases", new[] { "ComputerCaseTypesize_Id" });
            DropIndex("public.AudioChipsets", new[] { "Id" });
            DropIndex("public.MouseDPIModes", new[] { "DPIMode_Id" });
            DropIndex("public.MouseDPIModes", new[] { "Mouse_Id" });
            DropIndex("public.MotherboardVideoPorts", new[] { "VideoPort_Id" });
            DropIndex("public.MotherboardVideoPorts", new[] { "Motherboard_Id" });
            DropIndex("public.GraphicsCardVideoPorts", new[] { "VideoPort_Id" });
            DropIndex("public.GraphicsCardVideoPorts", new[] { "GraphicsCard_Id" });
            DropIndex("public.MotherboardRAMTypes", new[] { "RAMType_Id" });
            DropIndex("public.MotherboardRAMTypes", new[] { "Motherboard_Id" });
            DropIndex("public.CPURAMTypes", new[] { "RAMType_Id" });
            DropIndex("public.CPURAMTypes", new[] { "CPU_Id" });
            DropIndex("public.MotherboardCPUCores", new[] { "CPUCore_Id" });
            DropIndex("public.MotherboardCPUCores", new[] { "Motherboard_Id" });
            DropIndex("public.ComputerCaseMotherboardFormFactors", new[] { "MotherboardFormFactor_Id" });
            DropIndex("public.ComputerCaseMotherboardFormFactors", new[] { "ComputerCase_Id" });
            DropIndex("public.OrderedItems", new[] { "Order_Id" });
            DropIndex("public.OrderedItems", new[] { "ItemId" });
            DropIndex("public.Orders", new[] { "Status_Id" });
            DropIndex("public.Orders", new[] { "CustomerId" });
            DropIndex("public.BankCards", new[] { "BankSystem_Id" });
            DropIndex("public.SimpleComputerComponents", new[] { "Type_Id" });
            DropPrimaryKey("public.SSDControllers");
            DropPrimaryKey("public.NetworkAdapters");
            DropPrimaryKey("public.MotherboardChipsets");
            DropPrimaryKey("public.AudioChipsets");
            AlterColumn("public.Orders", "CustomerId", c => c.Int());
            AlterColumn("public.SSDControllers", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("public.NetworkAdapters", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("public.MotherboardChipsets", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("public.SSDs", "SSDController_Id", c => c.Long());
            AlterColumn("public.Motherboards", "NetworkAdapter_Id", c => c.Long());
            AlterColumn("public.Motherboards", "MotherboardChipset_Id", c => c.Long());
            AlterColumn("public.Motherboards", "AudioChipset_Id", c => c.Long());
            AlterColumn("public.BankCards", "Owner", c => c.String(nullable: false));
            AlterColumn("public.AudioChipsets", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("public.Users", "Salt", c => c.String(nullable: false));
            AlterColumn("public.Users", "PasswordHash", c => c.String(nullable: false));
            AlterColumn("public.Users", "Email", c => c.String(nullable: false));
            AlterColumn("public.LegalEntities", "LegalAddress", c => c.String(nullable: false));
            AlterColumn("public.LegalEntities", "PhysicalAddress", c => c.String(nullable: false));
            AlterColumn("public.IndividualEntities", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("public.IndividualEntities", "Surname", c => c.String(nullable: false));
            AlterColumn("public.IndividualEntities", "Name", c => c.String(nullable: false));
            DropColumn("public.Orders", "Status_Id");
            DropColumn("public.Orders", "OrderStatusId");
            DropColumn("public.RAMs", "RamTypeId");
            DropColumn("public.RAMs", "RAMType_Id");
            DropColumn("public.PowerSupplies", "Certiticate80PlusId");
            DropColumn("public.PowerSupplies", "Certificate80Plus_Id");
            DropColumn("public.Motherboards", "PCIEVersionId");
            DropColumn("public.Motherboards", "CPUSocketId");
            DropColumn("public.Motherboards", "MotherboardFormFactorId");
            DropColumn("public.Motherboards", "PCIEVersion_Id");
            DropColumn("public.Motherboards", "FormFactor_Id");
            DropColumn("public.Motherboards", "CPUSocket_Id");
            DropColumn("public.Keyboards", "KeyboardTypeId");
            DropColumn("public.Keyboards", "KeyboardTypesizeId");
            DropColumn("public.Keyboards", "Typesize_Id");
            DropColumn("public.Keyboards", "KeyboardType_Id");
            DropColumn("public.Displays", "VesaSizeId");
            DropColumn("public.Displays", "UnderlightId");
            DropColumn("public.Displays", "MatrixTypeId");
            DropColumn("public.Displays", "VesaSize_Id");
            DropColumn("public.Displays", "Underlight_Id");
            DropColumn("public.Displays", "MatrixType_Id");
            DropColumn("public.CPUs", "CPUSockerId");
            DropColumn("public.CPUs", "CPUSocket_Id");
            DropColumn("public.CPUCoolers", "RadiatroMaterialId");
            DropColumn("public.CPUCoolers", "FoundationMaterialId");
            DropColumn("public.CPUCoolers", "RadiatorMaterial_Id");
            DropColumn("public.CPUCoolers", "FoundationMaterial_Id");
            DropColumn("public.Items", "ItemType");
            DropColumn("public.Items", "ItemTypeId");
            DropColumn("public.ComputerCases", "ComputerCaseTypesizeId");
            DropColumn("public.ComputerCases", "ComputerCaseTypesize_Id");
            DropColumn("public.BankCards", "BankSystem_Id");
            DropColumn("public.BankCards", "BankSystemId");
            DropTable("public.MouseDPIModes");
            DropTable("public.MotherboardVideoPorts");
            DropTable("public.GraphicsCardVideoPorts");
            DropTable("public.MotherboardRAMTypes");
            DropTable("public.CPURAMTypes");
            DropTable("public.MotherboardCPUCores");
            DropTable("public.ComputerCaseMotherboardFormFactors");
            DropTable("public.OrderStatus");
            DropTable("public.OrderedItems");
            DropTable("public.KeyboardTypesizes");
            DropTable("public.KeyboardType");
            DropTable("public.DPIModes");
            DropTable("public.VesaSizes");
            DropTable("public.Underlights");
            DropTable("public.MatrixTypes");
            DropTable("public.VideoPorts");
            DropTable("public.RAMTypes");
            DropTable("public.PCIEVersions");
            DropTable("public.DCPUSocket");
            DropTable("public.MotherboardFormFactors");
            DropTable("public.ComputerCaseTypesizes");
            DropTable("public.CoolerMaterials");
            DropTable("public.Certificates80Plus");
            DropTable("public.BankSystems");
            DropTable("public.SimpleComputerComponentTypes");
            DropTable("public.SimpleComputerComponents");
            AddPrimaryKey("public.SSDControllers", "Id");
            AddPrimaryKey("public.NetworkAdapters", "Id");
            AddPrimaryKey("public.MotherboardChipsets", "Id");
            AddPrimaryKey("public.AudioChipsets", "Id");
            RenameColumn(table: "public.Orders", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("public.SSDs", "SSDController_Id");
            CreateIndex("public.Motherboards", "NetworkAdapter_Id");
            CreateIndex("public.Motherboards", "MotherboardChipset_Id");
            CreateIndex("public.Motherboards", "AudioChipset_Id");
            CreateIndex("public.OrderOrderedItems", "OrderedItem_Id");
            CreateIndex("public.OrderOrderedItems", "Order_Id");
            CreateIndex("public.Orders", "Customer_Id");
            CreateIndex("public.CPUCores", "Motherboard_Id");
            CreateIndex("public.Items", "Discount_Id");
            AddForeignKey("public.SSDs", "SSDController_Id", "public.SSDControllers", "Id");
            AddForeignKey("public.Motherboards", "NetworkAdapter_Id", "public.NetworkAdapters", "Id");
            AddForeignKey("public.Motherboards", "MotherboardChipset_Id", "public.MotherboardChipsets", "Id");
            AddForeignKey("public.Motherboards", "AudioChipset_Id", "public.AudioChipsets", "Id");
            AddForeignKey("public.Orders", "Customer_Id", "public.Users", "Id");
            AddForeignKey("public.OrderOrderedItems", "OrderedItem_Id", "public.OrderedItems", "Id", cascadeDelete: true);
            AddForeignKey("public.OrderOrderedItems", "Order_Id", "public.Orders", "Id", cascadeDelete: true);
            AddForeignKey("public.Items", "Discount_Id", "public.Discounts", "Id");
            AddForeignKey("public.CPUCores", "Motherboard_Id", "public.Motherboards", "Id");
        }
    }
}
