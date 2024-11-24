using GenosStore.Services.Interface.Entity.Orders;

namespace GenosStore.Services.Implementation.Entity.Orders {
    public class OrderEntitiesService: IOrderEntitiesService {
        private ICartService _cartService;

        public ICartService Carts {
            get { return _cartService; }
        }

        public OrderEntitiesService(ICartService cartService) {
            _cartService = cartService;
        }
    }
}