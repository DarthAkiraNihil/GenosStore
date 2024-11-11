using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface.Orders;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Orders {
    public class OrderItemsRepositoryPostgreSQL: IOrderItemsRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public OrderItemsRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<OrderItems> List() {
            return _context.OrderedItems.ToList();
        }

        public OrderItems Get(int id) {
            return _context.OrderedItems.Find(id);
        }

        public void Create(OrderItems orderItems) {
            _context.OrderedItems.Add(orderItems);
        }

        public void Update(OrderItems orderItems) {
            _context.Entry(orderItems).State = EntityState.Modified;
        }

        public void Delete(int id) {
            OrderItems orderItems = _context.OrderedItems.Find(id);
            if (orderItems != null)
                _context.OrderedItems.Remove(orderItems);
        }
        
    }
}