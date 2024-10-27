namespace GenosStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.ActiveDiscounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiscountId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        EndsAt = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                        Salt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.AudioChipsets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Model = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.BankCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Long(nullable: false),
                        BankSystem = c.Int(nullable: false),
                        ValidThruMonth = c.Short(nullable: false),
                        ValidThruYear = c.Short(nullable: false),
                        CVC = c.Short(nullable: false),
                        Owner = c.String(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Users", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "public.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        PathToImage = c.String(),
                        Description = c.String(),
                        ActiveDiscountId = c.Int(),
                        TDP = c.Double(),
                        VendorId = c.Int(),
                        Capacity = c.Long(),
                        ReadSpeed = c.Long(),
                        WriteSpeed = c.Long(),
                        CPUId = c.Int(),
                        MotherboardId = c.Int(),
                        GraphicsCardId = c.Int(),
                        PowerSupplyId = c.Int(),
                        DisplayId = c.Int(),
                        ComputerCaseId = c.Int(),
                        KeyboardId = c.Int(),
                        MouseId = c.Int(),
                        CPUCoolerId = c.Int(),
                        TBW = c.Int(),
                        DWPD = c.Single(),
                        BitsForCell = c.Short(),
                        SSDControllerId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        SSDController_Id = c.Long(),
                        Discount_Id = c.Long(),
                        Cart_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.ActiveDiscounts", t => t.ActiveDiscountId)
                .ForeignKey("public.Vendors", t => t.VendorId, cascadeDelete: true)
                .ForeignKey("public.CPUs", t => t.CPUId)
                .ForeignKey("public.CPUCoolers", t => t.CPUCoolerId)
                .ForeignKey("public.Displays", t => t.DisplayId)
                .ForeignKey("public.GraphicsCards", t => t.GraphicsCardId)
                .ForeignKey("public.Keyboards", t => t.KeyboardId)
                .ForeignKey("public.Motherboards", t => t.MotherboardId)
                .ForeignKey("public.Mouses", t => t.MouseId)
                .ForeignKey("public.PowerSupplies", t => t.PowerSupplyId)
                .ForeignKey("public.SSDControllers", t => t.SSDController_Id)
                .ForeignKey("public.Discounts", t => t.Discount_Id)
                .ForeignKey("public.Carts", t => t.Cart_CustomerId)
                .Index(t => t.ActiveDiscountId)
                .Index(t => t.VendorId)
                .Index(t => t.CPUId)
                .Index(t => t.MotherboardId)
                .Index(t => t.GraphicsCardId)
                .Index(t => t.PowerSupplyId)
                .Index(t => t.DisplayId)
                .Index(t => t.KeyboardId)
                .Index(t => t.MouseId)
                .Index(t => t.CPUCoolerId)
                .Index(t => t.SSDController_Id)
                .Index(t => t.Discount_Id)
                .Index(t => t.Cart_CustomerId);
            
            CreateTable(
                "public.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.CPUCores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        Name = c.String(),
                        Motherboard_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Vendors", t => t.VendorId, cascadeDelete: true)
                .ForeignKey("public.Motherboards", t => t.Motherboard_Id)
                .Index(t => t.VendorId)
                .Index(t => t.Motherboard_Id);
            
            CreateTable(
                "public.Definitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Discounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.GPUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        Model = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
            CreateTable(
                "public.MotherboardChipsets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Model = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.NetworkAdapters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Model = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.SSDControllers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Model = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Carts",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("public.Users", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "public.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Users", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
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
                "public.PreparedAssemblyDiskDrives",
                c => new
                    {
                        PreparedAssembly_Id = c.Int(nullable: false),
                        DiskDrive_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PreparedAssembly_Id, t.DiskDrive_Id })
                .ForeignKey("public.Items", t => t.PreparedAssembly_Id)
                .ForeignKey("public.Items", t => t.DiskDrive_Id)
                .Index(t => t.PreparedAssembly_Id)
                .Index(t => t.DiskDrive_Id);
            
            CreateTable(
                "public.PreparedAssemblyRAMs",
                c => new
                    {
                        PreparedAssembly_Id = c.Int(nullable: false),
                        RAM_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PreparedAssembly_Id, t.RAM_Id })
                .ForeignKey("public.Items", t => t.PreparedAssembly_Id)
                .ForeignKey("public.RAMs", t => t.RAM_Id)
                .Index(t => t.PreparedAssembly_Id)
                .Index(t => t.RAM_Id);
            
            CreateTable(
                "public.OrderOrderedItems",
                c => new
                    {
                        Order_Id = c.Long(nullable: false),
                        OrderedItem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.OrderedItem_Id })
                .ForeignKey("public.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("public.OrderedItems", t => t.OrderedItem_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.OrderedItem_Id);
            
            CreateTable(
                "public.Administrators",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.ComputerCases",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Typesize = c.Int(nullable: false),
                        Lenght = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                        HasARGBLighting = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.CPUCoolers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MaxFanRPM = c.Long(nullable: false),
                        FoundationMaterial = c.Int(nullable: false),
                        RadiatorMaterial = c.Int(nullable: false),
                        TubesCount = c.Short(nullable: false),
                        TubesDiameter = c.Single(nullable: false),
                        FanCount = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.CPUs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Socket = c.Int(nullable: false),
                        CoresCount = c.Int(nullable: false),
                        ThreadsCount = c.Int(nullable: false),
                        L2CahceSize = c.Single(nullable: false),
                        L3CacheSize = c.Single(nullable: false),
                        TechnicalProcess = c.Single(nullable: false),
                        BaseFrequency = c.Single(nullable: false),
                        SupportedRAMSize = c.Int(nullable: false),
                        HasIntegratedGraphics = c.Boolean(nullable: false),
                        CPUCoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.CPUCores", t => t.CPUCoreId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.CPUCoreId);
            
            CreateTable(
                "public.Displays",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DefinitionId = c.Int(nullable: false),
                        MatrixType = c.Int(nullable: false),
                        UnderlightType = c.Int(nullable: false),
                        MaxUpdateFrequency = c.Int(nullable: false),
                        VesaSize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.GraphicsCards",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        GPUId = c.Int(nullable: false),
                        VideoRAM = c.Int(nullable: false),
                        MaxDisplaysSupported = c.Short(nullable: false),
                        UsedSlots = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.GPUs", t => t.GPUId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.GPUId);
            
            CreateTable(
                "public.HDDs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RPM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.IndividualEntities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.Keyboards",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Typesize = c.Int(nullable: false),
                        HasRGBLighting = c.Boolean(nullable: false),
                        KeyboardType = c.Int(nullable: false),
                        IsWireless = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.LegalEntities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        INN = c.Long(nullable: false),
                        KPP = c.Long(nullable: false),
                        PhysicalAddress = c.String(nullable: false),
                        LegalAddress = c.String(nullable: false),
                        IsVerified = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.Motherboards",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AudioChipset_Id = c.Long(),
                        MotherboardChipset_Id = c.Long(),
                        NetworkAdapter_Id = c.Long(),
                        FormFactor = c.Int(nullable: false),
                        CPUSocket = c.Int(nullable: false),
                        MotherboardChipsetId = c.Int(nullable: false),
                        RAMSlots = c.Short(nullable: false),
                        RAMChannels = c.Short(nullable: false),
                        MaxRAMFrequency = c.Int(nullable: false),
                        PCIESlotsCount = c.Short(nullable: false),
                        PCIEVersion = c.Int(nullable: false),
                        HasNVMeSupport = c.Boolean(nullable: false),
                        M2SlotsCount = c.Short(nullable: false),
                        SataPortsCount = c.Short(nullable: false),
                        USBPortsCount = c.Short(nullable: false),
                        RJ45PortsCount = c.Short(nullable: false),
                        DigiralAudioPortsCount = c.Short(nullable: false),
                        AudioChipsetId = c.Int(nullable: false),
                        NetworkAdapterSpeed = c.Single(nullable: false),
                        NetworkAdapterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.AudioChipsets", t => t.AudioChipset_Id)
                .ForeignKey("public.MotherboardChipsets", t => t.MotherboardChipset_Id)
                .ForeignKey("public.NetworkAdapters", t => t.NetworkAdapter_Id)
                .Index(t => t.Id)
                .Index(t => t.AudioChipset_Id)
                .Index(t => t.MotherboardChipset_Id)
                .Index(t => t.NetworkAdapter_Id);
            
            CreateTable(
                "public.Mouses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ButtonsCount = c.Short(nullable: false),
                        HasProgrammableButtons = c.Boolean(nullable: false),
                        isWireless = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.NVMeSSDs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.PowerSupplies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SataPorts = c.Short(nullable: false),
                        MolexPorts = c.Short(nullable: false),
                        PowerOutput = c.Int(nullable: false),
                        Certificate80Plus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.RAMs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RAMType = c.Int(nullable: false),
                        TotalSize = c.Int(nullable: false),
                        ModuleSize = c.Int(nullable: false),
                        ModulesCount = c.Short(nullable: false),
                        Frequency = c.Int(nullable: false),
                        CL = c.Short(nullable: false),
                        tRCD = c.Short(nullable: false),
                        tRP = c.Short(nullable: false),
                        tRAS = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.SataSSDs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.SataSSDs", "Id", "public.Items");
            DropForeignKey("public.RAMs", "Id", "public.Items");
            DropForeignKey("public.PowerSupplies", "Id", "public.Items");
            DropForeignKey("public.NVMeSSDs", "Id", "public.Items");
            DropForeignKey("public.Mouses", "Id", "public.Items");
            DropForeignKey("public.Motherboards", "NetworkAdapter_Id", "public.NetworkAdapters");
            DropForeignKey("public.Motherboards", "MotherboardChipset_Id", "public.MotherboardChipsets");
            DropForeignKey("public.Motherboards", "AudioChipset_Id", "public.AudioChipsets");
            DropForeignKey("public.Motherboards", "Id", "public.Items");
            DropForeignKey("public.LegalEntities", "Id", "public.Users");
            DropForeignKey("public.Keyboards", "Id", "public.Items");
            DropForeignKey("public.IndividualEntities", "Id", "public.Users");
            DropForeignKey("public.HDDs", "Id", "public.Items");
            DropForeignKey("public.GraphicsCards", "GPUId", "public.GPUs");
            DropForeignKey("public.GraphicsCards", "Id", "public.Items");
            DropForeignKey("public.Displays", "Id", "public.Items");
            DropForeignKey("public.CPUs", "CPUCoreId", "public.CPUCores");
            DropForeignKey("public.CPUs", "Id", "public.Items");
            DropForeignKey("public.CPUCoolers", "Id", "public.Items");
            DropForeignKey("public.ComputerCases", "Id", "public.Items");
            DropForeignKey("public.Administrators", "Id", "public.Users");
            DropForeignKey("public.Items", "Cart_CustomerId", "public.Carts");
            DropForeignKey("public.Orders", "Customer_Id", "public.Users");
            DropForeignKey("public.OrderOrderedItems", "OrderedItem_Id", "public.OrderedItems");
            DropForeignKey("public.OrderOrderedItems", "Order_Id", "public.Orders");
            DropForeignKey("public.Carts", "CustomerId", "public.Users");
            DropForeignKey("public.BankCards", "Customer_Id", "public.Users");
            DropForeignKey("public.Items", "Discount_Id", "public.Discounts");
            DropForeignKey("public.Items", "SSDController_Id", "public.SSDControllers");
            DropForeignKey("public.PreparedAssemblyRAMs", "RAM_Id", "public.RAMs");
            DropForeignKey("public.PreparedAssemblyRAMs", "PreparedAssembly_Id", "public.Items");
            DropForeignKey("public.Items", "PowerSupplyId", "public.PowerSupplies");
            DropForeignKey("public.Items", "MouseId", "public.Mouses");
            DropForeignKey("public.Items", "MotherboardId", "public.Motherboards");
            DropForeignKey("public.CPUCores", "Motherboard_Id", "public.Motherboards");
            DropForeignKey("public.Items", "KeyboardId", "public.Keyboards");
            DropForeignKey("public.Items", "GraphicsCardId", "public.GraphicsCards");
            DropForeignKey("public.GPUs", "VendorId", "public.Vendors");
            DropForeignKey("public.Items", "DisplayId", "public.Displays");
            DropForeignKey("public.PreparedAssemblyDiskDrives", "DiskDrive_Id", "public.Items");
            DropForeignKey("public.PreparedAssemblyDiskDrives", "PreparedAssembly_Id", "public.Items");
            DropForeignKey("public.Items", "CPUCoolerId", "public.CPUCoolers");
            DropForeignKey("public.Items", "CPUId", "public.CPUs");
            DropForeignKey("public.Items", "VendorId", "public.Vendors");
            DropForeignKey("public.Items", "ActiveDiscountId", "public.ActiveDiscounts");
            DropForeignKey("public.CPUCores", "VendorId", "public.Vendors");
            DropIndex("public.SataSSDs", new[] { "Id" });
            DropIndex("public.RAMs", new[] { "Id" });
            DropIndex("public.PowerSupplies", new[] { "Id" });
            DropIndex("public.NVMeSSDs", new[] { "Id" });
            DropIndex("public.Mouses", new[] { "Id" });
            DropIndex("public.Motherboards", new[] { "NetworkAdapter_Id" });
            DropIndex("public.Motherboards", new[] { "MotherboardChipset_Id" });
            DropIndex("public.Motherboards", new[] { "AudioChipset_Id" });
            DropIndex("public.Motherboards", new[] { "Id" });
            DropIndex("public.LegalEntities", new[] { "Id" });
            DropIndex("public.Keyboards", new[] { "Id" });
            DropIndex("public.IndividualEntities", new[] { "Id" });
            DropIndex("public.HDDs", new[] { "Id" });
            DropIndex("public.GraphicsCards", new[] { "GPUId" });
            DropIndex("public.GraphicsCards", new[] { "Id" });
            DropIndex("public.Displays", new[] { "Id" });
            DropIndex("public.CPUs", new[] { "CPUCoreId" });
            DropIndex("public.CPUs", new[] { "Id" });
            DropIndex("public.CPUCoolers", new[] { "Id" });
            DropIndex("public.ComputerCases", new[] { "Id" });
            DropIndex("public.Administrators", new[] { "Id" });
            DropIndex("public.OrderOrderedItems", new[] { "OrderedItem_Id" });
            DropIndex("public.OrderOrderedItems", new[] { "Order_Id" });
            DropIndex("public.PreparedAssemblyRAMs", new[] { "RAM_Id" });
            DropIndex("public.PreparedAssemblyRAMs", new[] { "PreparedAssembly_Id" });
            DropIndex("public.PreparedAssemblyDiskDrives", new[] { "DiskDrive_Id" });
            DropIndex("public.PreparedAssemblyDiskDrives", new[] { "PreparedAssembly_Id" });
            DropIndex("public.Orders", new[] { "Customer_Id" });
            DropIndex("public.Carts", new[] { "CustomerId" });
            DropIndex("public.GPUs", new[] { "VendorId" });
            DropIndex("public.CPUCores", new[] { "Motherboard_Id" });
            DropIndex("public.CPUCores", new[] { "VendorId" });
            DropIndex("public.Items", new[] { "Cart_CustomerId" });
            DropIndex("public.Items", new[] { "Discount_Id" });
            DropIndex("public.Items", new[] { "SSDController_Id" });
            DropIndex("public.Items", new[] { "CPUCoolerId" });
            DropIndex("public.Items", new[] { "MouseId" });
            DropIndex("public.Items", new[] { "KeyboardId" });
            DropIndex("public.Items", new[] { "DisplayId" });
            DropIndex("public.Items", new[] { "PowerSupplyId" });
            DropIndex("public.Items", new[] { "GraphicsCardId" });
            DropIndex("public.Items", new[] { "MotherboardId" });
            DropIndex("public.Items", new[] { "CPUId" });
            DropIndex("public.Items", new[] { "VendorId" });
            DropIndex("public.Items", new[] { "ActiveDiscountId" });
            DropIndex("public.BankCards", new[] { "Customer_Id" });
            DropTable("public.SataSSDs");
            DropTable("public.RAMs");
            DropTable("public.PowerSupplies");
            DropTable("public.NVMeSSDs");
            DropTable("public.Mouses");
            DropTable("public.Motherboards");
            DropTable("public.LegalEntities");
            DropTable("public.Keyboards");
            DropTable("public.IndividualEntities");
            DropTable("public.HDDs");
            DropTable("public.GraphicsCards");
            DropTable("public.Displays");
            DropTable("public.CPUs");
            DropTable("public.CPUCoolers");
            DropTable("public.ComputerCases");
            DropTable("public.Administrators");
            DropTable("public.OrderOrderedItems");
            DropTable("public.PreparedAssemblyRAMs");
            DropTable("public.PreparedAssemblyDiskDrives");
            DropTable("public.OrderedItems");
            DropTable("public.Orders");
            DropTable("public.Carts");
            DropTable("public.SSDControllers");
            DropTable("public.NetworkAdapters");
            DropTable("public.MotherboardChipsets");
            DropTable("public.GPUs");
            DropTable("public.Discounts");
            DropTable("public.Definitions");
            DropTable("public.CPUCores");
            DropTable("public.Vendors");
            DropTable("public.Items");
            DropTable("public.BankCards");
            DropTable("public.AudioChipsets");
            DropTable("public.Users");
            DropTable("public.ActiveDiscounts");
        }
    }
}
