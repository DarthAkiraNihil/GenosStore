using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents {
    public class SimpleComputerComponentsService: ISimpleComputerComponentService {
        private readonly ICPUCoreService _cpuCoreService;
        private readonly IGPUService _gpusService;

        public SimpleComputerComponentsService(
            ICPUCoreService cpuCoreService,
            IGPUService gpusService) {
            _cpuCoreService = cpuCoreService;
            _gpusService = gpusService;
        }

        public ICPUCoreService CPUCores {
            get {
                return _cpuCoreService;
            }
        }

        public IGPUService GPUs {
            get {
                return _gpusService;
            }
        }
    }
}