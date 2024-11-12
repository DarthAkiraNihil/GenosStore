using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class ComputerComponentRepositoryPostgreSQL: IComputerComponentRepository {

        private GenosStoreDatabaseContext _context;
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

        public ComputerComponentRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }
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
        
    }
}