using GenosStore.Model.Context;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class CharacteristicRepositoryPostgreSQL: ICharacteristicRepository {
        
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

        public CharacteristicRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
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
    }
}