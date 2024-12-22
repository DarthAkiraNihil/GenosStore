using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface.Orders;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Orders {
    public class CartRepositoryPostgreSQL: ICartRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public CartRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Cart> List() {
            return _context.Carts.ToList();
        }

        public Cart Get(int id) {
            return _context.Carts.Find(id);
        }

        public void Create(Cart cart) {
            _context.Carts.Add(cart);
        }

        public void Update(Cart cart) {
            _context.Entry(cart).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Cart cart = _context.Carts.Find(id);
            if (cart != null)
                _context.Carts.Remove(cart);
        }

        public void DeleteRaw(Cart item) {
            _context.Carts.Remove(item);
        }
    }
}