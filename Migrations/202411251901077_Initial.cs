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
                "public.SimpleComputerComponents",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Model = c.String(nullable: false),
                        Name = c.String(nullable: false),
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
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.BankCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Long(nullable: false),
                        BankSystemId = c.Int(nullable: false),
                        ValidThruMonth = c.Short(nullable: false),
                        ValidThruYear = c.Short(nullable: false),
                        CVC = c.Short(nullable: false),
                        Owner = c.String(nullable: false),
                        BankSystem_Id = c.Long(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.BankSystems", t => t.BankSystem_Id, cascadeDelete: true)
                .ForeignKey("public.Users", t => t.Customer_Id)
                .Index(t => t.BankSystem_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "public.BankSystems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.CartItems",
                c => new
                    {
                        CartId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Cart_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CartId, t.ItemId })
                .ForeignKey("public.Carts", t => t.Cart_CustomerId, cascadeDelete: true)
                .ForeignKey("public.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.Cart_CustomerId);
            
            CreateTable(
                "public.Carts",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("public.Users", t => t.CustomerId)
                .ForeignKey("public.Items", t => t.Item_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "public.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        OrderStatus_Id = c.Long(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.OrderStatus", t => t.OrderStatus_Id, cascadeDelete: true)
                .ForeignKey("public.Users", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.OrderStatus_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "public.OrderItems",
                c => new
                    {
                        OrderId = c.Long(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        BoughtFor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ItemId })
                .ForeignKey("public.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("public.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "public.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        ImageBase64 = c.String(),
                        Description = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        TDP = c.Double(),
                        Discriminator = c.String(maxLength: 128),
                        ActiveDiscount_Id = c.Int(),
                        ItemType_Id = c.Int(nullable: false),
                        Vendor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.ActiveDiscounts", t => t.ActiveDiscount_Id)
                .ForeignKey("public.ItemTypes", t => t.ItemType_Id, cascadeDelete: true)
                .ForeignKey("public.Vendors", t => t.Vendor_Id, cascadeDelete: true)
                .Index(t => t.ActiveDiscount_Id)
                .Index(t => t.ItemType_Id)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "public.ItemTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.ComputerCaseTypesizes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.MotherboardFormFactors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.CPUCores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Vendor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Vendors", t => t.Vendor_Id, cascadeDelete: true)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "public.CPUSocket",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.PCIEVersions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.RAMTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.VideoPorts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.GPUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Vendor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Vendors", t => t.Vendor_Id, cascadeDelete: true)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "public.CoolerMaterials",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "public.MatrixTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Underlights",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.VesaSizes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.KeyboardType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.KeyboardTypesizes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                "public.Certificates80Plus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.OrderStatus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                "public.PreparedAssemblyDiskDrives",
                c => new
                    {
                        PreparedAssembly_Id = c.Int(nullable: false),
                        DiskDrive_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PreparedAssembly_Id, t.DiskDrive_Id })
                .ForeignKey("public.PreparedAssemblies", t => t.PreparedAssembly_Id)
                .ForeignKey("public.DiskDrives", t => t.DiskDrive_Id)
                .Index(t => t.PreparedAssembly_Id)
                .Index(t => t.DiskDrive_Id);
            
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
            
            CreateTable(
                "public.PreparedAssemblyRAMs",
                c => new
                    {
                        PreparedAssembly_Id = c.Int(nullable: false),
                        RAM_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PreparedAssembly_Id, t.RAM_Id })
                .ForeignKey("public.PreparedAssemblies", t => t.PreparedAssembly_Id)
                .ForeignKey("public.RAMs", t => t.RAM_Id)
                .Index(t => t.PreparedAssembly_Id)
                .Index(t => t.RAM_Id);
            
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
                "public.AudioChipsets",
                c => new
                    {
                        Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.SimpleComputerComponents", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.ComputerCases",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ComputerCaseTypesize_Id = c.Long(nullable: false),
                        Length = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                        HasARGBLighting = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.ComputerCaseTypesizes", t => t.ComputerCaseTypesize_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.ComputerCaseTypesize_Id);
            
            CreateTable(
                "public.CPUCoolers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FoundationMaterial_Id = c.Long(nullable: false),
                        RadiatorMaterial_Id = c.Long(nullable: false),
                        MaxFanRPM = c.Long(nullable: false),
                        TubesCount = c.Short(nullable: false),
                        TubesDiameter = c.Single(nullable: false),
                        FanCount = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.CoolerMaterials", t => t.FoundationMaterial_Id, cascadeDelete: true)
                .ForeignKey("public.CoolerMaterials", t => t.RadiatorMaterial_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.FoundationMaterial_Id)
                .Index(t => t.RadiatorMaterial_Id);
            
            CreateTable(
                "public.CPUs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CPUCore_Id = c.Int(nullable: false),
                        CPUSocket_Id = c.Long(nullable: false),
                        CoresCount = c.Int(nullable: false),
                        ThreadsCount = c.Int(nullable: false),
                        L2CahceSize = c.Single(nullable: false),
                        L3CacheSize = c.Single(nullable: false),
                        TechnicalProcess = c.Single(nullable: false),
                        BaseFrequency = c.Single(nullable: false),
                        SupportedRAMSize = c.Int(nullable: false),
                        HasIntegratedGraphics = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.CPUCores", t => t.CPUCore_Id, cascadeDelete: true)
                .ForeignKey("public.CPUSocket", t => t.CPUSocket_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.CPUCore_Id)
                .Index(t => t.CPUSocket_Id);
            
            CreateTable(
                "public.Displays",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Definition_Id = c.Int(nullable: false),
                        MatrixType_Id = c.Long(nullable: false),
                        Underlight_Id = c.Long(nullable: false),
                        VesaSize_Id = c.Long(nullable: false),
                        MaxUpdateFrequency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.Definitions", t => t.Definition_Id, cascadeDelete: true)
                .ForeignKey("public.MatrixTypes", t => t.MatrixType_Id, cascadeDelete: true)
                .ForeignKey("public.Underlights", t => t.Underlight_Id, cascadeDelete: true)
                .ForeignKey("public.VesaSizes", t => t.VesaSize_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Definition_Id)
                .Index(t => t.MatrixType_Id)
                .Index(t => t.Underlight_Id)
                .Index(t => t.VesaSize_Id);
            
            CreateTable(
                "public.GraphicsCards",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        GPU_Id = c.Int(nullable: false),
                        VideoRAM = c.Int(nullable: false),
                        MaxDisplaysSupported = c.Short(nullable: false),
                        UsedSlots = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.GPUs", t => t.GPU_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.GPU_Id);
            
            CreateTable(
                "public.DiskDrives",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Capacity = c.Long(nullable: false),
                        ReadSpeed = c.Long(nullable: false),
                        WriteSpeed = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.HDDs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RPM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.DiskDrives", t => t.Id)
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
                        KeyboardType_Id = c.Long(nullable: false),
                        Typesize_Id = c.Long(nullable: false),
                        HasRGBLighting = c.Boolean(nullable: false),
                        IsWireless = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.KeyboardType", t => t.KeyboardType_Id, cascadeDelete: true)
                .ForeignKey("public.KeyboardTypesizes", t => t.Typesize_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.KeyboardType_Id)
                .Index(t => t.Typesize_Id);
            
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
                "public.MotherboardChipsets",
                c => new
                    {
                        Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.SimpleComputerComponents", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.Motherboards",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AudioChipset_Id = c.Long(nullable: false),
                        CPUSocket_Id = c.Long(nullable: false),
                        FormFactor_Id = c.Long(nullable: false),
                        MotherboardChipset_Id = c.Long(nullable: false),
                        NetworkAdapter_Id = c.Long(nullable: false),
                        PCIEVersion_Id = c.Long(nullable: false),
                        RAMSlots = c.Short(nullable: false),
                        RAMChannels = c.Short(nullable: false),
                        MaxRAMFrequency = c.Int(nullable: false),
                        PCIESlotsCount = c.Short(nullable: false),
                        PCIEVersionId = c.Int(nullable: false),
                        HasNVMeSupport = c.Boolean(nullable: false),
                        M2SlotsCount = c.Short(nullable: false),
                        SataPortsCount = c.Short(nullable: false),
                        USBPortsCount = c.Short(nullable: false),
                        RJ45PortsCount = c.Short(nullable: false),
                        DigiralAudioPortsCount = c.Short(nullable: false),
                        NetworkAdapterSpeed = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.AudioChipsets", t => t.AudioChipset_Id)
                .ForeignKey("public.CPUSocket", t => t.CPUSocket_Id, cascadeDelete: true)
                .ForeignKey("public.MotherboardFormFactors", t => t.FormFactor_Id, cascadeDelete: true)
                .ForeignKey("public.MotherboardChipsets", t => t.MotherboardChipset_Id)
                .ForeignKey("public.NetworkAdapters", t => t.NetworkAdapter_Id)
                .ForeignKey("public.PCIEVersions", t => t.PCIEVersion_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.AudioChipset_Id)
                .Index(t => t.CPUSocket_Id)
                .Index(t => t.FormFactor_Id)
                .Index(t => t.MotherboardChipset_Id)
                .Index(t => t.NetworkAdapter_Id)
                .Index(t => t.PCIEVersion_Id);
            
            CreateTable(
                "public.Mouses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ButtonsCount = c.Short(nullable: false),
                        HasProgrammableButtons = c.Boolean(nullable: false),
                        IsWireless = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.NetworkAdapters",
                c => new
                    {
                        Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.SimpleComputerComponents", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.SSDs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SSDController_Id = c.Long(nullable: false),
                        TBW = c.Int(nullable: false),
                        DWPD = c.Single(nullable: false),
                        BitsForCell = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.DiskDrives", t => t.Id)
                .ForeignKey("public.SSDControllers", t => t.SSDController_Id)
                .Index(t => t.Id)
                .Index(t => t.SSDController_Id);
            
            CreateTable(
                "public.NVMeSSDs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.SSDs", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.PowerSupplies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Certificate80Plus_Id = c.Long(nullable: false),
                        SataPorts = c.Short(nullable: false),
                        MolexPorts = c.Short(nullable: false),
                        PowerOutput = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.Certificates80Plus", t => t.Certificate80Plus_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Certificate80Plus_Id);
            
            CreateTable(
                "public.PreparedAssemblies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ComputerCase_Id = c.Int(nullable: false),
                        CPU_Id = c.Int(nullable: false),
                        CPUCooler_Id = c.Int(nullable: false),
                        Display_Id = c.Int(),
                        GraphicsCard_Id = c.Int(nullable: false),
                        Keyboard_Id = c.Int(),
                        Motherboard_Id = c.Int(nullable: false),
                        Mouse_Id = c.Int(),
                        PowerSupply_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Items", t => t.Id)
                .ForeignKey("public.ComputerCases", t => t.ComputerCase_Id)
                .ForeignKey("public.CPUs", t => t.CPU_Id)
                .ForeignKey("public.CPUCoolers", t => t.CPUCooler_Id)
                .ForeignKey("public.Displays", t => t.Display_Id)
                .ForeignKey("public.GraphicsCards", t => t.GraphicsCard_Id)
                .ForeignKey("public.Keyboards", t => t.Keyboard_Id)
                .ForeignKey("public.Motherboards", t => t.Motherboard_Id)
                .ForeignKey("public.Mouses", t => t.Mouse_Id)
                .ForeignKey("public.PowerSupplies", t => t.PowerSupply_Id)
                .Index(t => t.Id)
                .Index(t => t.ComputerCase_Id)
                .Index(t => t.CPU_Id)
                .Index(t => t.CPUCooler_Id)
                .Index(t => t.Display_Id)
                .Index(t => t.GraphicsCard_Id)
                .Index(t => t.Keyboard_Id)
                .Index(t => t.Motherboard_Id)
                .Index(t => t.Mouse_Id)
                .Index(t => t.PowerSupply_Id);
            
            CreateTable(
                "public.RAMs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RAMType_Id = c.Long(nullable: false),
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
                .ForeignKey("public.RAMTypes", t => t.RAMType_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.RAMType_Id);
            
            CreateTable(
                "public.SataSSDs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.SSDs", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "public.SSDControllers",
                c => new
                    {
                        Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.SimpleComputerComponents", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.SSDControllers", "Id", "public.SimpleComputerComponents");
            DropForeignKey("public.SataSSDs", "Id", "public.SSDs");
            DropForeignKey("public.RAMs", "RAMType_Id", "public.RAMTypes");
            DropForeignKey("public.RAMs", "Id", "public.Items");
            DropForeignKey("public.PreparedAssemblies", "PowerSupply_Id", "public.PowerSupplies");
            DropForeignKey("public.PreparedAssemblies", "Mouse_Id", "public.Mouses");
            DropForeignKey("public.PreparedAssemblies", "Motherboard_Id", "public.Motherboards");
            DropForeignKey("public.PreparedAssemblies", "Keyboard_Id", "public.Keyboards");
            DropForeignKey("public.PreparedAssemblies", "GraphicsCard_Id", "public.GraphicsCards");
            DropForeignKey("public.PreparedAssemblies", "Display_Id", "public.Displays");
            DropForeignKey("public.PreparedAssemblies", "CPUCooler_Id", "public.CPUCoolers");
            DropForeignKey("public.PreparedAssemblies", "CPU_Id", "public.CPUs");
            DropForeignKey("public.PreparedAssemblies", "ComputerCase_Id", "public.ComputerCases");
            DropForeignKey("public.PreparedAssemblies", "Id", "public.Items");
            DropForeignKey("public.PowerSupplies", "Certificate80Plus_Id", "public.Certificates80Plus");
            DropForeignKey("public.PowerSupplies", "Id", "public.Items");
            DropForeignKey("public.NVMeSSDs", "Id", "public.SSDs");
            DropForeignKey("public.SSDs", "SSDController_Id", "public.SSDControllers");
            DropForeignKey("public.SSDs", "Id", "public.DiskDrives");
            DropForeignKey("public.NetworkAdapters", "Id", "public.SimpleComputerComponents");
            DropForeignKey("public.Mouses", "Id", "public.Items");
            DropForeignKey("public.Motherboards", "PCIEVersion_Id", "public.PCIEVersions");
            DropForeignKey("public.Motherboards", "NetworkAdapter_Id", "public.NetworkAdapters");
            DropForeignKey("public.Motherboards", "MotherboardChipset_Id", "public.MotherboardChipsets");
            DropForeignKey("public.Motherboards", "FormFactor_Id", "public.MotherboardFormFactors");
            DropForeignKey("public.Motherboards", "CPUSocket_Id", "public.CPUSocket");
            DropForeignKey("public.Motherboards", "AudioChipset_Id", "public.AudioChipsets");
            DropForeignKey("public.Motherboards", "Id", "public.Items");
            DropForeignKey("public.MotherboardChipsets", "Id", "public.SimpleComputerComponents");
            DropForeignKey("public.LegalEntities", "Id", "public.Users");
            DropForeignKey("public.Keyboards", "Typesize_Id", "public.KeyboardTypesizes");
            DropForeignKey("public.Keyboards", "KeyboardType_Id", "public.KeyboardType");
            DropForeignKey("public.Keyboards", "Id", "public.Items");
            DropForeignKey("public.IndividualEntities", "Id", "public.Users");
            DropForeignKey("public.HDDs", "Id", "public.DiskDrives");
            DropForeignKey("public.DiskDrives", "Id", "public.Items");
            DropForeignKey("public.GraphicsCards", "GPU_Id", "public.GPUs");
            DropForeignKey("public.GraphicsCards", "Id", "public.Items");
            DropForeignKey("public.Displays", "VesaSize_Id", "public.VesaSizes");
            DropForeignKey("public.Displays", "Underlight_Id", "public.Underlights");
            DropForeignKey("public.Displays", "MatrixType_Id", "public.MatrixTypes");
            DropForeignKey("public.Displays", "Definition_Id", "public.Definitions");
            DropForeignKey("public.Displays", "Id", "public.Items");
            DropForeignKey("public.CPUs", "CPUSocket_Id", "public.CPUSocket");
            DropForeignKey("public.CPUs", "CPUCore_Id", "public.CPUCores");
            DropForeignKey("public.CPUs", "Id", "public.Items");
            DropForeignKey("public.CPUCoolers", "RadiatorMaterial_Id", "public.CoolerMaterials");
            DropForeignKey("public.CPUCoolers", "FoundationMaterial_Id", "public.CoolerMaterials");
            DropForeignKey("public.CPUCoolers", "Id", "public.Items");
            DropForeignKey("public.ComputerCases", "ComputerCaseTypesize_Id", "public.ComputerCaseTypesizes");
            DropForeignKey("public.ComputerCases", "Id", "public.Items");
            DropForeignKey("public.AudioChipsets", "Id", "public.SimpleComputerComponents");
            DropForeignKey("public.Administrators", "Id", "public.Users");
            DropForeignKey("public.SimpleComputerComponents", "Type_Id", "public.SimpleComputerComponentTypes");
            DropForeignKey("public.CartItems", "ItemId", "public.Items");
            DropForeignKey("public.CartItems", "Cart_CustomerId", "public.Carts");
            DropForeignKey("public.Orders", "Customer_Id", "public.Users");
            DropForeignKey("public.Orders", "OrderStatus_Id", "public.OrderStatus");
            DropForeignKey("public.OrderItems", "OrderId", "public.Orders");
            DropForeignKey("public.OrderItems", "ItemId", "public.Items");
            DropForeignKey("public.PreparedAssemblyRAMs", "RAM_Id", "public.RAMs");
            DropForeignKey("public.PreparedAssemblyRAMs", "PreparedAssembly_Id", "public.PreparedAssemblies");
            DropForeignKey("public.MouseDPIModes", "DPIMode_Id", "public.DPIModes");
            DropForeignKey("public.MouseDPIModes", "Mouse_Id", "public.Mouses");
            DropForeignKey("public.PreparedAssemblyDiskDrives", "DiskDrive_Id", "public.DiskDrives");
            DropForeignKey("public.PreparedAssemblyDiskDrives", "PreparedAssembly_Id", "public.PreparedAssemblies");
            DropForeignKey("public.CPURAMTypes", "RAMType_Id", "public.RAMTypes");
            DropForeignKey("public.CPURAMTypes", "CPU_Id", "public.CPUs");
            DropForeignKey("public.CPUCores", "Vendor_Id", "public.Vendors");
            DropForeignKey("public.MotherboardVideoPorts", "VideoPort_Id", "public.VideoPorts");
            DropForeignKey("public.MotherboardVideoPorts", "Motherboard_Id", "public.Motherboards");
            DropForeignKey("public.GraphicsCardVideoPorts", "VideoPort_Id", "public.VideoPorts");
            DropForeignKey("public.GraphicsCardVideoPorts", "GraphicsCard_Id", "public.GraphicsCards");
            DropForeignKey("public.GPUs", "Vendor_Id", "public.Vendors");
            DropForeignKey("public.MotherboardRAMTypes", "RAMType_Id", "public.RAMTypes");
            DropForeignKey("public.MotherboardRAMTypes", "Motherboard_Id", "public.Motherboards");
            DropForeignKey("public.MotherboardCPUCores", "CPUCore_Id", "public.CPUCores");
            DropForeignKey("public.MotherboardCPUCores", "Motherboard_Id", "public.Motherboards");
            DropForeignKey("public.ComputerCaseMotherboardFormFactors", "MotherboardFormFactor_Id", "public.MotherboardFormFactors");
            DropForeignKey("public.ComputerCaseMotherboardFormFactors", "ComputerCase_Id", "public.ComputerCases");
            DropForeignKey("public.Items", "Vendor_Id", "public.Vendors");
            DropForeignKey("public.Items", "ItemType_Id", "public.ItemTypes");
            DropForeignKey("public.Carts", "Item_Id", "public.Items");
            DropForeignKey("public.Items", "ActiveDiscount_Id", "public.ActiveDiscounts");
            DropForeignKey("public.Carts", "CustomerId", "public.Users");
            DropForeignKey("public.BankCards", "Customer_Id", "public.Users");
            DropForeignKey("public.BankCards", "BankSystem_Id", "public.BankSystems");
            DropIndex("public.SSDControllers", new[] { "Id" });
            DropIndex("public.SataSSDs", new[] { "Id" });
            DropIndex("public.RAMs", new[] { "RAMType_Id" });
            DropIndex("public.RAMs", new[] { "Id" });
            DropIndex("public.PreparedAssemblies", new[] { "PowerSupply_Id" });
            DropIndex("public.PreparedAssemblies", new[] { "Mouse_Id" });
            DropIndex("public.PreparedAssemblies", new[] { "Motherboard_Id" });
            DropIndex("public.PreparedAssemblies", new[] { "Keyboard_Id" });
            DropIndex("public.PreparedAssemblies", new[] { "GraphicsCard_Id" });
            DropIndex("public.PreparedAssemblies", new[] { "Display_Id" });
            DropIndex("public.PreparedAssemblies", new[] { "CPUCooler_Id" });
            DropIndex("public.PreparedAssemblies", new[] { "CPU_Id" });
            DropIndex("public.PreparedAssemblies", new[] { "ComputerCase_Id" });
            DropIndex("public.PreparedAssemblies", new[] { "Id" });
            DropIndex("public.PowerSupplies", new[] { "Certificate80Plus_Id" });
            DropIndex("public.PowerSupplies", new[] { "Id" });
            DropIndex("public.NVMeSSDs", new[] { "Id" });
            DropIndex("public.SSDs", new[] { "SSDController_Id" });
            DropIndex("public.SSDs", new[] { "Id" });
            DropIndex("public.NetworkAdapters", new[] { "Id" });
            DropIndex("public.Mouses", new[] { "Id" });
            DropIndex("public.Motherboards", new[] { "PCIEVersion_Id" });
            DropIndex("public.Motherboards", new[] { "NetworkAdapter_Id" });
            DropIndex("public.Motherboards", new[] { "MotherboardChipset_Id" });
            DropIndex("public.Motherboards", new[] { "FormFactor_Id" });
            DropIndex("public.Motherboards", new[] { "CPUSocket_Id" });
            DropIndex("public.Motherboards", new[] { "AudioChipset_Id" });
            DropIndex("public.Motherboards", new[] { "Id" });
            DropIndex("public.MotherboardChipsets", new[] { "Id" });
            DropIndex("public.LegalEntities", new[] { "Id" });
            DropIndex("public.Keyboards", new[] { "Typesize_Id" });
            DropIndex("public.Keyboards", new[] { "KeyboardType_Id" });
            DropIndex("public.Keyboards", new[] { "Id" });
            DropIndex("public.IndividualEntities", new[] { "Id" });
            DropIndex("public.HDDs", new[] { "Id" });
            DropIndex("public.DiskDrives", new[] { "Id" });
            DropIndex("public.GraphicsCards", new[] { "GPU_Id" });
            DropIndex("public.GraphicsCards", new[] { "Id" });
            DropIndex("public.Displays", new[] { "VesaSize_Id" });
            DropIndex("public.Displays", new[] { "Underlight_Id" });
            DropIndex("public.Displays", new[] { "MatrixType_Id" });
            DropIndex("public.Displays", new[] { "Definition_Id" });
            DropIndex("public.Displays", new[] { "Id" });
            DropIndex("public.CPUs", new[] { "CPUSocket_Id" });
            DropIndex("public.CPUs", new[] { "CPUCore_Id" });
            DropIndex("public.CPUs", new[] { "Id" });
            DropIndex("public.CPUCoolers", new[] { "RadiatorMaterial_Id" });
            DropIndex("public.CPUCoolers", new[] { "FoundationMaterial_Id" });
            DropIndex("public.CPUCoolers", new[] { "Id" });
            DropIndex("public.ComputerCases", new[] { "ComputerCaseTypesize_Id" });
            DropIndex("public.ComputerCases", new[] { "Id" });
            DropIndex("public.AudioChipsets", new[] { "Id" });
            DropIndex("public.Administrators", new[] { "Id" });
            DropIndex("public.PreparedAssemblyRAMs", new[] { "RAM_Id" });
            DropIndex("public.PreparedAssemblyRAMs", new[] { "PreparedAssembly_Id" });
            DropIndex("public.MouseDPIModes", new[] { "DPIMode_Id" });
            DropIndex("public.MouseDPIModes", new[] { "Mouse_Id" });
            DropIndex("public.PreparedAssemblyDiskDrives", new[] { "DiskDrive_Id" });
            DropIndex("public.PreparedAssemblyDiskDrives", new[] { "PreparedAssembly_Id" });
            DropIndex("public.CPURAMTypes", new[] { "RAMType_Id" });
            DropIndex("public.CPURAMTypes", new[] { "CPU_Id" });
            DropIndex("public.MotherboardVideoPorts", new[] { "VideoPort_Id" });
            DropIndex("public.MotherboardVideoPorts", new[] { "Motherboard_Id" });
            DropIndex("public.GraphicsCardVideoPorts", new[] { "VideoPort_Id" });
            DropIndex("public.GraphicsCardVideoPorts", new[] { "GraphicsCard_Id" });
            DropIndex("public.MotherboardRAMTypes", new[] { "RAMType_Id" });
            DropIndex("public.MotherboardRAMTypes", new[] { "Motherboard_Id" });
            DropIndex("public.MotherboardCPUCores", new[] { "CPUCore_Id" });
            DropIndex("public.MotherboardCPUCores", new[] { "Motherboard_Id" });
            DropIndex("public.ComputerCaseMotherboardFormFactors", new[] { "MotherboardFormFactor_Id" });
            DropIndex("public.ComputerCaseMotherboardFormFactors", new[] { "ComputerCase_Id" });
            DropIndex("public.GPUs", new[] { "Vendor_Id" });
            DropIndex("public.CPUCores", new[] { "Vendor_Id" });
            DropIndex("public.Items", new[] { "Vendor_Id" });
            DropIndex("public.Items", new[] { "ItemType_Id" });
            DropIndex("public.Items", new[] { "ActiveDiscount_Id" });
            DropIndex("public.OrderItems", new[] { "ItemId" });
            DropIndex("public.OrderItems", new[] { "OrderId" });
            DropIndex("public.Orders", new[] { "Customer_Id" });
            DropIndex("public.Orders", new[] { "OrderStatus_Id" });
            DropIndex("public.Carts", new[] { "Item_Id" });
            DropIndex("public.Carts", new[] { "CustomerId" });
            DropIndex("public.CartItems", new[] { "Cart_CustomerId" });
            DropIndex("public.CartItems", new[] { "ItemId" });
            DropIndex("public.BankCards", new[] { "Customer_Id" });
            DropIndex("public.BankCards", new[] { "BankSystem_Id" });
            DropIndex("public.SimpleComputerComponents", new[] { "Type_Id" });
            DropTable("public.SSDControllers");
            DropTable("public.SataSSDs");
            DropTable("public.RAMs");
            DropTable("public.PreparedAssemblies");
            DropTable("public.PowerSupplies");
            DropTable("public.NVMeSSDs");
            DropTable("public.SSDs");
            DropTable("public.NetworkAdapters");
            DropTable("public.Mouses");
            DropTable("public.Motherboards");
            DropTable("public.MotherboardChipsets");
            DropTable("public.LegalEntities");
            DropTable("public.Keyboards");
            DropTable("public.IndividualEntities");
            DropTable("public.HDDs");
            DropTable("public.DiskDrives");
            DropTable("public.GraphicsCards");
            DropTable("public.Displays");
            DropTable("public.CPUs");
            DropTable("public.CPUCoolers");
            DropTable("public.ComputerCases");
            DropTable("public.AudioChipsets");
            DropTable("public.Administrators");
            DropTable("public.PreparedAssemblyRAMs");
            DropTable("public.MouseDPIModes");
            DropTable("public.PreparedAssemblyDiskDrives");
            DropTable("public.CPURAMTypes");
            DropTable("public.MotherboardVideoPorts");
            DropTable("public.GraphicsCardVideoPorts");
            DropTable("public.MotherboardRAMTypes");
            DropTable("public.MotherboardCPUCores");
            DropTable("public.ComputerCaseMotherboardFormFactors");
            DropTable("public.OrderStatus");
            DropTable("public.Certificates80Plus");
            DropTable("public.DPIModes");
            DropTable("public.KeyboardTypesizes");
            DropTable("public.KeyboardType");
            DropTable("public.VesaSizes");
            DropTable("public.Underlights");
            DropTable("public.MatrixTypes");
            DropTable("public.Definitions");
            DropTable("public.CoolerMaterials");
            DropTable("public.GPUs");
            DropTable("public.VideoPorts");
            DropTable("public.RAMTypes");
            DropTable("public.PCIEVersions");
            DropTable("public.CPUSocket");
            DropTable("public.CPUCores");
            DropTable("public.MotherboardFormFactors");
            DropTable("public.ComputerCaseTypesizes");
            DropTable("public.Vendors");
            DropTable("public.ItemTypes");
            DropTable("public.Items");
            DropTable("public.OrderItems");
            DropTable("public.Orders");
            DropTable("public.Carts");
            DropTable("public.CartItems");
            DropTable("public.BankSystems");
            DropTable("public.BankCards");
            DropTable("public.SimpleComputerComponentTypes");
            DropTable("public.SimpleComputerComponents");
            DropTable("public.Users");
            DropTable("public.ActiveDiscounts");
        }
    }
}
