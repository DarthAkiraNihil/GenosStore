using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class ComputerComponentServices: IComputerComponentServices {
        
        private IMotherboardService _motherboardService;

        public IMotherboardService Motherboards {
            get {
                return _motherboardService;
            }
        }

        public ComputerComponentServices(IMotherboardService motherboardService) {
            _motherboardService = motherboardService;
        }
    }
}