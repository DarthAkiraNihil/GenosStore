using System.ComponentModel;
using GenosStore.Services.Interface.Entity;
using GenosStore.Services.Interface.Entity.Items;

namespace GenosStore.Services.Implementation.Entity {
    public class EntityServices: IEntityServices {
        
        private IItemServices _itemServices;

        public IItemServices Items {
            get {
                return _itemServices;
            }
        }

        public EntityServices(IItemServices itemServices) {
            _itemServices = itemServices;
        }
    }
}