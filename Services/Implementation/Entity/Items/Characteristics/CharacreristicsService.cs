using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class CharacreristicsService: ICharacteristicsService {
        private readonly ICPUSocketService _cpusocketService;
        private readonly IMotherboardFormFactorService _motherboardFormFactorService;
        private readonly IRAMTypeService _ramTypeService;
        private readonly IVendorService _vendorService;

        public CharacreristicsService(ICPUSocketService cpusocketService, IMotherboardFormFactorService motherboardFormFactorService, IRAMTypeService ramTypeService, IVendorService vendorService) {
            _cpusocketService = cpusocketService;
            _motherboardFormFactorService = motherboardFormFactorService;
            _ramTypeService = ramTypeService;
            _vendorService = vendorService;
        }

        public ICPUSocketService CPUSockets {
            get {
                return _cpusocketService;
            }
        }

        public IMotherboardFormFactorService MotherboardFormFactors {
            get {
                return _motherboardFormFactorService;
            }
        }

        public IRAMTypeService RAMTypes {
            get {
                return _ramTypeService;
            }
        }

        public IVendorService Vendors {
            get {
                return _vendorService;
            }
        }
    }
}