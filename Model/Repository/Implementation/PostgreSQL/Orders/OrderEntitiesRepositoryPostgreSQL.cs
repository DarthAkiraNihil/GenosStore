using GenosStore.Model.Context;
using GenosStore.Model.Repository.Interface.Orders;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Orders {
    public class OrderEntitiesRepositoryPostgreSQL: IOrderEntitiesRepository {
        // Orders
        private ActiveDiscountRepositoryPostgreSQL _activeDiscounts;
        private BankCardRepositoryPostgreSQL _bankCards;
        private BankSystemRepositoryPostgreSQL _bankSystems;
        private CartRepositoryPostgreSQL _carts;
        private CartItemsRepositoryPostgreSQL _cartItems;
        private OrderItemsRepositoryPostgreSQL _orderItems;
        private OrderRepositoryPostgreSQL _orders;
        private OrderStatusRepositoryPostgreSQL _orderStatuses;
        
        private GenosStoreDatabaseContext _context;

        public OrderEntitiesRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }
        
        // Orders
        public IActiveDiscountRepository ActiveDiscounts {
            get {
                if (_activeDiscounts == null) {
                    _activeDiscounts = new ActiveDiscountRepositoryPostgreSQL(_context);
                }
                return _activeDiscounts;
            }
        }
        public IBankCardRepository BankCards {
            get {
                if (_bankCards == null) {
                    _bankCards = new BankCardRepositoryPostgreSQL(_context);
                }
                return _bankCards;
            }
        }
        public IBankSystemRepository BankSystems {
            get {
                if (_bankSystems == null) {
                    _bankSystems = new BankSystemRepositoryPostgreSQL(_context);
                }
                return _bankSystems;
            }
        }
        public ICartRepository Carts {
            get {
                if (_carts == null) {
                    _carts = new CartRepositoryPostgreSQL(_context);
                }
                return _carts;
            }
        }
        public IOrderItemsRepository OrderItems {
            get {
                if (_orderItems == null) {
                    _orderItems = new OrderItemsRepositoryPostgreSQL(_context);
                }
                return _orderItems;
            }
        }
        public IOrderRepository Orders {
            get {
                if (_orders == null) {
                    _orders = new OrderRepositoryPostgreSQL(_context);
                }
                return _orders;
            }
        }
        public IOrderStatusRepository OrderStatuses {
            get {
                if (_orderStatuses == null) {
                    _orderStatuses = new OrderStatusRepositoryPostgreSQL(_context);
                }
                return _orderStatuses;
            }
        }

        public ICartItemsRepository CartItems {
            get {
                if (_cartItems == null) {
                    _cartItems = new CartItemsRepositoryPostgreSQL(_context);
                }
                return _cartItems;
            }
        }
    }
}