using System.Collections.Generic;
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

            // if (customer.Cart == null) {
            //     customer.Cart = new Cart();
            //     customer.Cart.Items = new List<Item>();
            // }
            var cart = customer.Cart;
            // var cartItem = new CartItem() {
            //     Cart = cart,
            //     Item = item,
            //     Quantity = 1
            // };
            // cart.Items.Add(cartItem);
            // //customer.Cart.Items.Add(item);
            // _repositories.Save();
            MessageBox.Show("WERKED");
        }

        public void RemoveFromCart(Item item, Customer customer) {
            if (customer.Cart == null) {
                return;
            }
            //customer.Cart.Items.Remove(item);
            //_repositories.Save();
            MessageBox.Show("WERKED");
        }
        
        public void AddToCart(Item item) {
            throw new System.NotImplementedException();
        }

        public void RemoveFromCart(Item item) {
            throw new System.NotImplementedException();
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