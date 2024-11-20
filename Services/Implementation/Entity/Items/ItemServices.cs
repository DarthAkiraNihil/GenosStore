using GenosStore.Services.Interface.Entity.Items;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items {
    public class ItemServices: IItemServices {
        private IComputerComponentServices _computerComponentServices;

        public IComputerComponentServices ComputerComponents {
            get {
                return _computerComponentServices;
            }
        }

        public ItemServices(IComputerComponentServices computerComponentServices) {
            _computerComponentServices = computerComponentServices;
        }
        
    }
}