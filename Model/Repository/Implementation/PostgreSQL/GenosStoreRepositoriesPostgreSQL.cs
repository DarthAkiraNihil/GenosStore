using GenosStore.Model.Context;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Item;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Orders;
using GenosStore.Model.Repository.Implementation.PostgreSQL.User;
using GenosStore.Model.Repository.Interface;
using GenosStore.Model.Repository.Interface.Item;
using GenosStore.Model.Repository.Interface.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Orders;
using GenosStore.Model.Repository.Interface.User;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL {
    public class GenosStoreRepositoriesPostgreSQL: IGenosStoreRepositories {
        
        private GenosStoreDatabaseContext _context;
        
        // Characteristic
        private Certificate80PlusRepositoryPostgreSQL _certificates80Plus;
        private ComputerCaseTypesizeRepositoryPostgreSQL _computerCaseTypesizes;
        private CoolerMaterialRepositoryPostgreSQL _coolerMaterials;
        private CPUSocketRepositoryPostgreSQL _cpuSockets;
        private DefinitionRepositoryPostgreSQL _definitions;
        private DPIModeRepositoryPostgreSQL _dpiModes;
        private KeyboardTypeRepositoryPostgreSQL _keyboardTypes;
        private KeyboardTypesizeRepositoryPostgreSQL _keyboardTypesizes;
        private MatrixTypeRepositoryPostgreSQL _matrixTypes;
        private MotherboardFormFactorRepositoryPostgreSQL _motherboardFormFactors;
        private PCIEVersionRepositoryPostgreSQL _pCIEVersions;
        private RAMTypeRepositoryPostgreSQL _ramTypes;
        private UnderlightRepositoryPostgreSQL _underlights;
        private VendorRepositoryPostgreSQL _vendors;
        private VesaSizeRepositoryPostgreSQL _vesaSizes;
        private VideoPortRepositoryPostgreSQL _videoPorts;
        
        // ComputerComponent
        private ComputerCaseRepositoryPostgreSQL _computerCases;
        //private ComputerComponentRepositoryPostgreSQL _ComputerComponents;
        private CPUCoolerRepositoryPostgreSQL _cpuCoolers;
        private CPURepositoryPostgreSQL _cpus;
        //private DiskDriveRepositoryPostgreSQL _DiskDrives;
        private DisplayRepositoryPostgreSQL _displays;
        private GraphicsCardRepositoryPostgreSQL _graphicsCards;
        private HDDRepositoryPostgreSQL _hdds;
        private KeyboardRepositoryPostgreSQL _keyboards;
        private MotherboardRepositoryPostgreSQL _motherboards;
        private MouseRepositoryPostgreSQL _mouses;
        private NVMeSSDRepositoryPostgreSQL _nvmeSSDs;
        private PowerSupplyRepositoryPostgreSQL _powerSupplies;
        private RAMRepositoryPostgreSQL _rams;
        private SataSSDRepositoryPostgreSQL _sataSSDs;
        //private SSDRepositoryPostgreSQL _SSDs;
            
        // SimpleComputerComponent
        private AudioChipsetRepositoryPostgreSQL _audioChipsets;
        private CPUCoreRepositoryPostgreSQL _cpuCores;
        private GPURepositoryPostgreSQL _gpus;
        private MotherboardChipsetRepositoryPostgreSQL _motherboardChipsets;
        private NetworkAdapterRepositoryPostgreSQL _networkAdapters;
        //private SimpleComputerComponentRepositoryPostgreSQL _SimpleComputerComponents;
        private SimpleComputerComponentTypeRepositoryPostgreSQL _simpleComputerComponentTypes;
        private SSDControllerRepositoryPostgreSQL _ssdControllers;
        //private ItemRepositoryPostgreSQL _Items;
        private ItemTypeRepositoryPostgreSQL _itemTypes;
        private PreparedAssemblyRepositoryPostgreSQL _preparedAssemblies;
            
        // Orders
        private ActiveDiscountRepositoryPostgreSQL _activeDiscounts;
        private BankCardRepositoryPostgreSQL _bankCards;
        private BankSystemRepositoryPostgreSQL _bankSystems;
        private CartRepositoryPostgreSQL _carts;
        private OrderItemsRepositoryPostgreSQL _orderItems;
        private OrderRepositoryPostgreSQL _orders;
        private OrderStatusRepositoryPostgreSQL _orderStatuses;
            
        // User
        private AdministratorRepositoryPostgreSQL _administrators;
        //private CustomerRepositoryPostgreSQL _Customers;
        private IndividualEntityRepositoryPostgreSQL _individualEntities;
        private LegalEntityRepositoryPostgreSQL _legalEntities;
        private UserRepositoryPostgreSQL _users;

        public GenosStoreRepositoriesPostgreSQL() {
            _context = new GenosStoreDatabaseContext();
        }
        
        // Characteristic
        public ICertificate80PlusRepository Certificates80Plus {
            get {
                if (_certificates80Plus == null) {
                    _certificates80Plus = new Certificate80PlusRepositoryPostgreSQL(_context);
                }
                return _certificates80Plus;
            }
        }
        public IComputerCaseTypesizeRepository ComputerCaseTypesizes {
            get {
                if (_computerCaseTypesizes == null) {
                    _computerCaseTypesizes = new ComputerCaseTypesizeRepositoryPostgreSQL(_context);
                }
                return _computerCaseTypesizes;
            }
        }
        public ICoolerMaterialRepository CoolerMaterials {
            get {
                if (_coolerMaterials == null) {
                    _coolerMaterials = new CoolerMaterialRepositoryPostgreSQL(_context);
                }
                return _coolerMaterials;
            }
        }
        public ICPUSocketRepository CPUSockets {
            get {
                if (_cpuSockets == null) {
                    _cpuSockets = new CPUSocketRepositoryPostgreSQL(_context);
                }
                return _cpuSockets;
            }
        }
        public IDefinitionRepository Definitions {
            get {
                if (_definitions == null) {
                    _definitions = new DefinitionRepositoryPostgreSQL(_context);
                }
                return _definitions;
            }
        }
        public IDPIModeRepository DPIModes {
            get {
                if (_dpiModes == null) {
                    _dpiModes = new DPIModeRepositoryPostgreSQL(_context);
                }
                return _dpiModes;
            }
        }
        public IKeyboardTypeRepository KeyboardTypes {
            get {
                if (_keyboardTypes == null) {
                    _keyboardTypes = new KeyboardTypeRepositoryPostgreSQL(_context);
                }
                return _keyboardTypes;
            }
        }
        public IKeyboardTypesizeRepository KeyboardTypesizes {
            get {
                if (_keyboardTypesizes == null) {
                    _keyboardTypesizes = new KeyboardTypesizeRepositoryPostgreSQL(_context);
                }
                return _keyboardTypesizes;
            }
        }
        public IMatrixTypeRepository MatrixTypes {
            get {
                if (_matrixTypes == null) {
                    _matrixTypes = new MatrixTypeRepositoryPostgreSQL(_context);
                }
                return _matrixTypes;
            }
        }
        public IMotherboardFormFactorRepository MotherboardFormFactors {
            get {
                if (_motherboardFormFactors == null) {
                    _motherboardFormFactors = new MotherboardFormFactorRepositoryPostgreSQL(_context);
                }
                return _motherboardFormFactors;
            }
        }
        public IPCIEVersionRepository PCIEVersions {
            get {
                if (_pCIEVersions == null) {
                    _pCIEVersions = new PCIEVersionRepositoryPostgreSQL(_context);
                }
                return _pCIEVersions;
            }
        }
        public IRAMTypeRepository RAMTypes {
            get {
                if (_ramTypes == null) {
                    _ramTypes = new RAMTypeRepositoryPostgreSQL(_context);
                }
                return _ramTypes;
            }
        }
        public IUnderlightRepository Underlights {
            get {
                if (_underlights == null) {
                    _underlights = new UnderlightRepositoryPostgreSQL(_context);
                }
                return _underlights;
            }
        }
        public IVendorRepository Vendors {
            get {
                if (_vendors == null) {
                    _vendors = new VendorRepositoryPostgreSQL(_context);
                }
                return _vendors;
            }
        }
        public IVesaSizeRepository VesaSizes {
            get {
                if (_vesaSizes == null) {
                    _vesaSizes = new VesaSizeRepositoryPostgreSQL(_context);
                }
                return _vesaSizes;
            }
        }
        public IVideoPortRepository VideoPorts {
            get {
                if (_videoPorts == null) {
                    _videoPorts = new VideoPortRepositoryPostgreSQL(_context);
                }
                return _videoPorts;
            }
        }
        
        // ComputerComponent
        public IComputerCaseRepository ComputerCases {
            get {
                if (_computerCases == null) {
                    _computerCases = new ComputerCaseRepositoryPostgreSQL(_context);
                }
                return _computerCases;
            }
        }
        // public IComputerComponentRepository ComputerComponents {
        //     get {
        //         if (+comp == null) {
        //             _certificates80Plus = new Certificate80PlusRepositoryPostgreSQL(_context);
        //         }
        //         return _certificates80Plus;
        //     }
        // }
        public ICPUCoolerRepository CPUCoolers {
            get {
                if (_cpuCoolers == null) {
                    _cpuCoolers = new CPUCoolerRepositoryPostgreSQL(_context);
                }
                return _cpuCoolers;
            }
        }
        public ICPURepository CPUs {
            get {
                if (_cpus == null) {
                    _cpus = new CPURepositoryPostgreSQL(_context);
                }
                return _cpus;
            }
        }
        // public IDiskDriveRepository DiskDrives {
        //     get {
        //         
        //     }
        // }
        public IDisplayRepository Displays {
            get {
                if (_displays == null) {
                    _displays = new DisplayRepositoryPostgreSQL(_context);
                }
                return _displays;
            }
        }
        public IGraphicsCardRepository GraphicsCards {
            get {
                if (_graphicsCards == null) {
                    _graphicsCards = new GraphicsCardRepositoryPostgreSQL(_context);
                }
                return _graphicsCards;
            }
        }
        public IHDDRepository HDDs {
            get {
                if (_hdds == null) {
                    _hdds = new HDDRepositoryPostgreSQL(_context);
                }
                return _hdds;
            }
        }
        public IKeyboardRepository Keyboards {
            get {
                if (_keyboards == null) {
                    _keyboards = new KeyboardRepositoryPostgreSQL(_context);
                }
                return _keyboards;
            }
        }
        public IMotherboardRepository Motherboards {
            get {
                if (_motherboards == null) {
                    _motherboards = new MotherboardRepositoryPostgreSQL(_context);
                }
                return _motherboards;
            }
        }
        public IMouseRepository Mouses {
            get {
                if (_mouses == null) {
                    _mouses = new MouseRepositoryPostgreSQL(_context);
                }
                return _mouses;
            }
        }
        public INVMeSSDRepository NVMeSSDs {
            get {
                if (_nvmeSSDs == null) {
                    _nvmeSSDs = new NVMeSSDRepositoryPostgreSQL(_context);
                }
                return _nvmeSSDs;
            }
        }
        public IPowerSupplyRepository PowerSupplies {
            get {
                if (_powerSupplies == null) {
                    _powerSupplies = new PowerSupplyRepositoryPostgreSQL(_context);
                }
                return _powerSupplies;
            }
        }
        public IRAMRepository RAMs {
            get {
                if (_rams == null) {
                    _rams = new RAMRepositoryPostgreSQL(_context);
                }
                return _rams;
            }
        }
        public ISataSSDRepository SataSSDs {
            get {
                if (_sataSSDs == null) {
                    _sataSSDs = new SataSSDRepositoryPostgreSQL(_context);
                }
                return _sataSSDs;
            }
        }
        // public ISSDRepository SSDs {
        //     get {
        //         
        //     }
        // }
            
        // SimpleComputerComponent
        public IAudioChipsetRepository AudioChipsets {
            get {
                if (_audioChipsets == null) {
                    _audioChipsets = new AudioChipsetRepositoryPostgreSQL(_context);
                }
                return _audioChipsets;
            }
        }
        public ICPUCoreRepository CPUCores {
            get {
                if (_cpuCores == null) {
                    _cpuCores = new CPUCoreRepositoryPostgreSQL(_context);
                }
                return _cpuCores;
            }
        }
        public IGPURepository GPUs {
            get {
                if (_gpus == null) {
                    _gpus = new GPURepositoryPostgreSQL(_context);
                }
                return _gpus;
            }
        }
        public IMotherboardChipsetRepository MotherboardChipsets {
            get {
                if (_motherboardChipsets == null) {
                    _motherboardChipsets = new MotherboardChipsetRepositoryPostgreSQL(_context);
                }
                return _motherboardChipsets;
            }
        }
        public INetworkAdapterRepository NetworkAdapters {
            get {
                if (_networkAdapters == null) {
                    _networkAdapters = new NetworkAdapterRepositoryPostgreSQL(_context);
                }
                return _networkAdapters;
            }
        }
        // public ISimpleComputerComponentRepository SimpleComputerComponents {
        //     get {
        //         if (_simpleComputerComponentTypes == null) {
        //             _simpleComputerComponentTypes = new Certificate80PlusRepositoryPostgreSQL(_context);
        //         }
        //         return _simpleComputerComponentTypes;
        //     }
        // }
        public ISimpleComputerComponentTypeRepository SimpleComputerComponentTypes {
            get {
                if (_simpleComputerComponentTypes == null) {
                    _simpleComputerComponentTypes = new SimpleComputerComponentTypeRepositoryPostgreSQL(_context);
                }
                return _simpleComputerComponentTypes;
            }
        }
        public ISSDControllerRepository SSDControllers {
            get {
                if (_ssdControllers == null) {
                    _ssdControllers = new SSDControllerRepositoryPostgreSQL(_context);
                }
                return _ssdControllers;
            }
        }
        // public IItemRepository Items {
        //     get {
        //         if (_i == null) {
        //             _i = new Certificate80PlusRepositoryPostgreSQL(_context);
        //         }
        //         return _i;
        //     }
        // }
        public IItemTypeRepository ItemTypes {
            get {
                if (_itemTypes == null) {
                    _itemTypes = new ItemTypeRepositoryPostgreSQL(_context);
                }
                return _itemTypes;
            }
        }
        public IPreparedAssemblyRepository PreparedAssemblies {
            get {
                if (_preparedAssemblies == null) {
                    _preparedAssemblies = new PreparedAssemblyRepositoryPostgreSQL(_context);
                }
                return _preparedAssemblies;
            }
        }
            
        // Orders
        public IActiveDiscountRepository ActiveDiscounts {
            get {
                if (_activeDiscounts == null) {
                    _activeDiscounts = new ActiveDiscountRepositoryPostgreSQL(_context);
                }
                return _activeDiscounts;
            }
        }
        public IBankCardRepository BankCards {
            get {
                if (_bankCards == null) {
                    _bankCards = new BankCardRepositoryPostgreSQL(_context);
                }
                return _bankCards;
            }
        }
        public IBankSystemRepository BankSystems {
            get {
                if (_bankSystems == null) {
                    _bankSystems = new BankSystemRepositoryPostgreSQL(_context);
                }
                return _bankSystems;
            }
        }
        public ICartRepository Carts {
            get {
                if (_carts == null) {
                    _carts = new CartRepositoryPostgreSQL(_context);
                }
                return _carts;
            }
        }
        public IOrderItemsRepository OrderItems {
            get {
                if (_orderItems == null) {
                    _orderItems = new OrderItemsRepositoryPostgreSQL(_context);
                }
                return _orderItems;
            }
        }
        public IOrderRepository Orders {
            get {
                if (_orders == null) {
                    _orders = new OrderRepositoryPostgreSQL(_context);
                }
                return _orders;
            }
        }
        public IOrderStatusRepository OrderStatuses {
            get {
                if (_orderStatuses == null) {
                    _orderStatuses = new OrderStatusRepositoryPostgreSQL(_context);
                }
                return _orderStatuses;
            }
        }
            
        // User
        public IAdministratorRepository Administrators {
            get {
                if (_administrators == null) {
                    _administrators = new AdministratorRepositoryPostgreSQL(_context);
                }
                return _administrators;
            }
        }
        // public ICustomerRepository Customers {
        //     get {
        //         if (_certificates80Plus == null) {
        //             _certificates80Plus = new Certificate80PlusRepositoryPostgreSQL(_context);
        //         }
        //         return _certificates80Plus;
        //     }
        // }
        public IIndividualEntityRepository IndividualEntities {
            get {
                if (_individualEntities == null) {
                    _individualEntities = new IndividualEntityRepositoryPostgreSQL(_context);
                }
                return _individualEntities;
            }
        }
        public ILegalEntityRepository LegalEntities {
            get {
                if (_legalEntities == null) {
                    _legalEntities = new LegalEntityRepositoryPostgreSQL(_context);
                }
                return _legalEntities;
            }
        }
        public IUserRepository Users {
            get {
                if (_users == null) {
                    _users = new UserRepositoryPostgreSQL(_context);
                }
                return _users;
            }
        }
    }
}