using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface.Orders;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Orders {
    public class CartItemsRepositoryPostgreSQL: ICartItemsRepository {
        private readonly GenosStoreDatabaseContext _context;
        
        public CartItemsRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<CartItem> List() {
            return _context.CartItems.ToList();
        }

        public CartItem Get(int id) {
            return _context.CartItems.Find(id);
        }

        public void Create(CartItem item) {
            _context.CartItems.Add(item);
        }

        public void Update(CartItem item) {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id) {
            CartItem item = _context.CartItems.Find(new {ItemID = id, CartId = 0});
            if (item != null)
                _context.CartItems.Remove(item);
        }

        public void DeleteRaw(CartItem item) {
            _context.CartItems.Remove(item);
        }
    }
}