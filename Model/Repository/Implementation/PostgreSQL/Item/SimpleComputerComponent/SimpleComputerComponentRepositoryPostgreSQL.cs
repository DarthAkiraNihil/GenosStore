using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent {
    public class SimpleComputerComponentRepositoryPostgreSQL: ISimpleComputerComponentRepository {

        private GenosStoreDatabaseContext _context;
        
        public SimpleComputerComponentRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        // SimpleComputerComponent
        private AudioChipsetRepositoryPostgreSQL _audioChipsets;
        private CPUCoreRepositoryPostgreSQL _cpuCores;
        private GPURepositoryPostgreSQL _gpus;
        private MotherboardChipsetRepositoryPostgreSQL _motherboardChipsets;
        private NetworkAdapterRepositoryPostgreSQL _networkAdapters;
        //private SimpleComputerComponentRepositoryPostgreSQL _SimpleComputerComponents;
        private SimpleComputerComponentTypeRepositoryPostgreSQL _simpleComputerComponentTypes;
        private SSDControllerRepositoryPostgreSQL _ssdControllers;
        
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
    }
}