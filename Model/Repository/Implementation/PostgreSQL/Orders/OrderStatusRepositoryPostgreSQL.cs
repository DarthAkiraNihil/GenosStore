using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface.Orders;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Orders {
    public class OrderStatusRepositoryPostgreSQL: IOrderStatusRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public OrderStatusRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<OrderStatus> List() {
            return _context.OrderStatuses.ToList();
        }

        public OrderStatus Get(int id) {
            return _context.OrderStatuses.Find(id);
        }

        public void Create(OrderStatus orderStatus) {
            _context.OrderStatuses.Add(orderStatus);
        }

        public void Update(OrderStatus orderStatus) {
            _context.Entry(orderStatus).State = EntityState.Modified;
        }

        public void Delete(int id) {
            OrderStatus orderStatus = _context.OrderStatuses.Find(id);
            if (orderStatus != null)
                _context.OrderStatuses.Remove(orderStatus);
        }
        
    }
}