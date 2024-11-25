using System.Linq;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Orders;

namespace GenosStore.Services.Implementation.Entity.Orders {
    public class OrderStatusService: IOrderStatusService {
        
        private IGenosStoreRepositories _repositories;

        public OrderStatusService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public OrderStatus GetFromString(string value) {
            return _repositories.Orders.OrderStatuses.List().FirstOrDefault(i => i.Name == value);
        }
    }
}