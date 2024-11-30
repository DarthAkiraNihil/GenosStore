using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Orders;

namespace GenosStore.Services.Implementation.Entity.Orders {
    public class OrderStatusService: IOrderStatusService {
        
        private IGenosStoreRepositories _repositories;

        public void Create(OrderStatus item) {
            _repositories.Orders.OrderStatuses.Create(item);
        }

        public OrderStatus Get(int id) {
            return _repositories.Orders.OrderStatuses.Get(id);
        }

        public List<OrderStatus> List() {
            return _repositories.Orders.OrderStatuses.List();
        }

        public void Update(OrderStatus item) {
            _repositories.Orders.OrderStatuses.Update(item);
        }

        public void Delete(int id) {
            _repositories.Orders.OrderStatuses.Delete(id);
        }

        public OrderStatusService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public OrderStatus GetFromString(string value) {
            return _repositories.Orders.OrderStatuses.List().FirstOrDefault(i => i.Name == value);
        }
        
        public int Save() {
            return _repositories.Save();
        }

    }
}