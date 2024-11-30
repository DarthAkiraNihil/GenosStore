using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents {
    public class SimpleComputerComponentsService: ISimpleComputerComponentService {
        private readonly ICPUCoreService _cpuCoreService;

        public SimpleComputerComponentsService(ICPUCoreService cpuCoreService) {
            _cpuCoreService = cpuCoreService;
        }

        public ICPUCoreService CPUCores {
            get {
                return _cpuCoreService;
            }
        }
    }
}