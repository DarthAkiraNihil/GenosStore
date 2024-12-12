using System.ComponentModel;
using GenosStore.Services.Interface.Entity;
using GenosStore.Services.Interface.Entity.Items;
using GenosStore.Services.Interface.Entity.Orders;
using GenosStore.Services.Interface.Entity.Users;

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
        
        private readonly IUserEntitiesService _userEntitiesService;
        
        public IUserEntitiesService Users => _userEntitiesService;

        public EntityServices(
            IItemServices itemServices,
            IOrderEntitiesService orderService,
            IUserEntitiesService userEntitiesService
            ) {
            _itemServices = itemServices;
            _orderService = orderService;
            _userEntitiesService = userEntitiesService;
        }
    }
}