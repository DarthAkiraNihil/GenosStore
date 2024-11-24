using System.Collections.Generic;
using System.Collections.ObjectModel;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.Main {
    public class CartPageModel: RequiresUserViewModel {

        private Cart _cart;
        private ObservableCollection<CartItem> _cartItems;

        public ObservableCollection<CartItem> CartItems {
            get { return _cartItems; }
            set {
                _cartItems = value;
                NotifyPropertyChanged("CurrentCart");
            }
        }
        
        public CartPageModel(IServices services, User user) : base(services, user) {
            _cart = (_user as Customer)?.Cart;
            CartItems = new ObservableCollection<CartItem>(_cart.Items);
        }
    }
}