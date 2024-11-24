using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Orders;

namespace GenosStore.Services.Implementation.Entity.Orders {
    public class CartService: ICartService {
        private IGenosStoreRepositories _repositories;
        
        public void AddToCart(Item item, Customer customer) {
            
            var cart = customer.Cart;
            var cartItem = new CartItem {
                Cart = cart,
                Item = item,
                Quantity = 1
            };
            cart.Items.Add(cartItem);
            _repositories.Save();
        }

        public void RemoveFromCart(Item item, Customer customer) {
            var cart = customer.Cart;
            if (cart == null) {
                return;
            }

            var cartItem = cart.Items.First(i => i.Item == item);
            _repositories.Orders.CartItems.DeleteRaw(cartItem);
            cart.Items.Remove(cartItem);
            
            _repositories.Save();
        }

        public void IncrementCartItemQuantity(Item item, Customer customer) {
            var cart = customer.Cart;
            cart.Items.First(i => i.Item == item).Quantity++;
            _repositories.Save();
        }

        public void DecrementCartItemQuantity(Item item, Customer customer) {
            var cart = customer.Cart;
            var itemToRemove = cart.Items.First(i => i.Item == item);
            itemToRemove.Quantity--;
            if (itemToRemove.Quantity == 0) {
                RemoveFromCart(item, customer);
                return;
            }
            _repositories.Save();
        }

        public bool IsInCart(Item item, Customer customer) {
            var cart = customer.Cart;
            return cart.Items.Select(i => i.Item).Contains(item);
        }
        
        public void Create(Cart item) {
            _repositories.Orders.Carts.Create(item);
        }

        public Cart Get(int id) {
            return _repositories.Orders.Carts.Get(id);
        }

        public List<Cart> List() {
            return _repositories.Orders.Carts.List();
        }

        public void Update(Cart item) {
            _repositories.Orders.Carts.Update(item);
        }

        public void Delete(int id) {
            _repositories.Orders.Carts.Delete(id);
        }

        public CartService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }
    }
}