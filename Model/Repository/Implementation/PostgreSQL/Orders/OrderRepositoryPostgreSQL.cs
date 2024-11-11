using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface.Orders;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Orders {
    public class OrderRepositoryPostgreSQL: IOrderRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public OrderRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Order> List() {
            return _context.Orders.ToList();
        }

        public Order Get(int id) {
            return _context.Orders.Find(id);
        }

        public void Create(Order order) {
            _context.Orders.Add(order);
        }

        public void Update(Order order) {
            _context.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Order order = _context.Orders.Find(id);
            if (order != null)
                _context.Orders.Remove(order);
        }
        
    }
}