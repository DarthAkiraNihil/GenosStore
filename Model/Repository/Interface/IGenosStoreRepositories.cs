using GenosStore.Model.Repository.Interface.Item;
using GenosStore.Model.Repository.Interface.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Orders;
using GenosStore.Model.Repository.Interface.User;

namespace GenosStore.Model.Repository.Interface {
    public interface IGenosStoreRepositories {
        
        IItemRepository Items { get; }
        IOrderEntitiesRepository Orders { get; }
        IUserEntitiesRepository Users { get; }
        
        // // Characteristic
        // ICertificate80PlusRepository Certificates80Plus { get; }
        // IComputerCaseTypesizeRepository ComputerCaseTypesizes { get; }
        // ICoolerMaterialRepository CoolerMaterials { get; }
        // ICPUSocketRepository CPUSockets { get; }
        // IDefinitionRepository Definitions { get; }
        // IDPIModeRepository DPIModes { get; }
        // IKeyboardTypeRepository KeyboardTypes { get; }
        // IKeyboardTypesizeRepository KeyboardTypesizes { get; }
        // IMatrixTypeRepository MatrixTypes { get; }
        // IMotherboardFormFactorRepository MotherboardFormFactors { get; }
        // IPCIEVersionRepository PCIEVersions { get; }
        // IRAMTypeRepository RAMTypes { get; }
        // IUnderlightRepository Underlights { get; }
        // IVendorRepository Vendors { get; }
        // IVesaSizeRepository VesaSizes { get; }
        // IVideoPortRepository VideoPorts { get; }
        //
        // // ComputerComponent
        // IComputerCaseRepository ComputerCases { get; }
        // //IComputerComponentRepository ComputerComponents { get; }
        // ICPUCoolerRepository CPUCoolers { get; }
        // ICPURepository CPUs { get; }
        // //IDiskDriveRepository DiskDrives { get; }
        // IDisplayRepository Displays { get; }
        // IGraphicsCardRepository GraphicsCards { get; }
        // IHDDRepository HDDs { get; }
        // IKeyboardRepository Keyboards { get; }
        // IMotherboardRepository Motherboards { get; }
        // IMouseRepository Mouses { get; }
        // INVMeSSDRepository NVMeSSDs { get; }
        // IPowerSupplyRepository PowerSupplies { get; }
        // IRAMRepository RAMs { get; }
        // ISataSSDRepository SataSSDs { get; }
        // //ISSDRepository SSDs { get; }
        //     
        // // SimpleComputerComponent
        // IAudioChipsetRepository AudioChipsets { get; }
        // ICPUCoreRepository CPUCores { get; }
        // IGPURepository GPUs { get; }
        // IMotherboardChipsetRepository MotherboardChipsets { get; }
        // INetworkAdapterRepository NetworkAdapters { get; }
        // //ISimpleComputerComponentRepository SimpleComputerComponents { get; }
        // ISimpleComputerComponentTypeRepository SimpleComputerComponentTypes { get; }
        // ISSDControllerRepository SSDControllers { get; }
        // //IItemRepository Items { get; }
        // IItemTypeRepository ItemTypes { get; }
        // IPreparedAssemblyRepository PreparedAssemblies { get; }
        //     
        // // Orders
        // IActiveDiscountRepository ActiveDiscounts { get; }
        // IBankCardRepository BankCards { get; }
        // IBankSystemRepository BankSystems { get; }
        // ICartRepository Carts { get; }
        // IOrderItemsRepository OrderItems { get; }
        // IOrderRepository Orders { get; }
        // IOrderStatusRepository OrderStatuses { get; }
        //     
        // // User
        // IAdministratorRepository Administrators { get; }
        // //ICustomerRepository Customers { get; }
        // IIndividualEntityRepository IndividualEntities { get; }
        // ILegalEntityRepository LegalEntities { get; }
        // IUserRepository Users { get; }
    }
}