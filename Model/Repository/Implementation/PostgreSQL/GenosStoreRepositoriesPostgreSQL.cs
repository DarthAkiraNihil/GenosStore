using GenosStore.Model.Context;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Item;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Orders;
using GenosStore.Model.Repository.Implementation.PostgreSQL.User;
using GenosStore.Model.Repository.Interface;
using GenosStore.Model.Repository.Interface.Item;
using GenosStore.Model.Repository.Interface.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Orders;
using GenosStore.Model.Repository.Interface.User;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL {
    public class GenosStoreRepositoriesPostgreSQL: IGenosStoreRepositories {
        
        private GenosStoreDatabaseContext _context;
        
        private ItemRepositoryPostgreSQL _items;
        private OrderEntitiesRepositoryPostgreSQL _orders;
        private UserEntitiesRepositoryPostgreSQL _users;
        

        public GenosStoreRepositoriesPostgreSQL() {
            _context = new GenosStoreDatabaseContext();
        }
        
        public IItemRepository Items {
            get {
                if (_items == null) {
                    _items = new ItemRepositoryPostgreSQL(_context);
                }
                return _items;
            }
        }
        
        public IOrderEntitiesRepository Orders {
            get {
                if (_orders == null) {
                    _orders = new OrderEntitiesRepositoryPostgreSQL(_context);
                }
                return _orders;
            }
        }
        public IUserEntitiesRepository Users {
            get {
                if (_users == null) {
                    _users = new UserEntitiesRepositoryPostgreSQL(_context);
                }
                return _users;
            }
        }

        public int Save() {
            return _context.SaveChanges();
        }
    }
}