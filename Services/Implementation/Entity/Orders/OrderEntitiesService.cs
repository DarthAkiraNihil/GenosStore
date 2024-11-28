using GenosStore.Services.Interface.Entity.Orders;

namespace GenosStore.Services.Implementation.Entity.Orders {
    public class OrderEntitiesService: IOrderEntitiesService {
        private ICartService _cartService;
        private IOrderService _orderService;
        private IOrderStatusService _orderStatusService;
        private IActiveDiscountService _activeDiscountService;

        public ICartService Carts {
            get { return _cartService; }
        }

        public IOrderService Orders {
            get { return _orderService; }
        }

        public IOrderStatusService OrderStatuses {
            get { return _orderStatusService; }
        }

        public IActiveDiscountService ActiveDiscounts {
            get { return _activeDiscountService; }
        }

        public OrderEntitiesService(ICartService cartService, IOrderService orderService, IOrderStatusService orderStatusService, IActiveDiscountService activeDiscountService) {
            _cartService = cartService;
            _orderService = orderService;
            _orderStatusService = orderStatusService;
            _activeDiscountService = activeDiscountService;
        }
    }
}