using System.ComponentModel;
using GenosStore.Services.Interface.Entity;
using GenosStore.Services.Interface.Entity.Items;
using GenosStore.Services.Interface.Entity.Orders;

namespace GenosStore.Services.Implementation.Entity {
    public class EntityServices: IEntityServices {
        
        private IItemServices _itemServices;

        public IItemServices Items {
            get {
                return _itemServices;
            }
        }
        
        private IOrderEntitiesService _orderService;

        public IOrderEntitiesService Orders {
            get
            {
                return _orderService;
            }
        }

        public EntityServices(IItemServices itemServices, IOrderEntitiesService orderService) {
            _itemServices = itemServices;
            _orderService = orderService;
        }
    }
}