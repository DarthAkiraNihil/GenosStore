using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;
using GenosStore.ViewModel.Order;

namespace GenosStore.ViewModel.Main {
    public class CartPageModel: RequiresUserViewModel {

        private Cart _cart;
        private ObservableCollection<CartItem> _cartItems;

        public ObservableCollection<CartItem> CartItems {
            get { return _cartItems; }
            set {
                _cartItems = value;
                NotifyPropertyChanged("CartItems");
            }
        }

        #region IncrementCartItemQuantityCommand

        private readonly RelayCommand _incrementCartItemQuantityCommand;

        public RelayCommand IncrementCartItemQuantityCommand {
            get { return _incrementCartItemQuantityCommand; }
        }

        private void IncrementCartItemQuantity(object parameter) {
            int id = (int) parameter;
            _services.Entity.Orders.Carts.IncrementCartItemQuantity(
                _cart.Items.Where(i => i.Item.Id == id).Select(i => i.Item).First(),
                _user as Customer
                );
            CartItems = new ObservableCollection<CartItem>(_cart.Items);
            MessageBox.Show("WERKED");
        }

        private bool CanIncrement(object parameter) {
            return true;
        }

        #endregion

        #region DecrementCartItemQuantityCommand

        private readonly RelayCommand _decrementCartItemQuantityCommand;

        public RelayCommand DecrementCartItemQuantityCommand {
            get { return _decrementCartItemQuantityCommand; }
        }

        private void DecrementCartItemQuantity(object parameter) {
            int id = (int) parameter;
            _services.Entity.Orders.Carts.DecrementCartItemQuantity(
                _cart.Items.Where(i => i.Item.Id == id).Select(i => i.Item).First(),
                _user as Customer
            );
            CartItems = new ObservableCollection<CartItem>(_cart.Items);
            MessageBox.Show("WERKED");
        }

        private bool CanDecrement(object parameter) {
            return true;
        }

        #endregion

        #region CreateOrderCommand

        private readonly RelayCommand _createOrderCommand;

        public RelayCommand CreateOrderCommand {
            get { return _createOrderCommand; }
        }

        private void CreateOrder(object parameter) {
            var args = new NavigationArgsBuilder()
                       .WithURL("View/Order/OrderPage.xaml")
                       .WithTitle("Order")
                       .WithViewModel(new OrderPageModel(_services, _user, null))
                       .Build();
            Navigate(args);
        }

        private bool CanCreateOrder(object parameter) {
            return true;
        }

        #endregion
        
        public CartPageModel(IServices services, User user) : base(services, user) {
            _cart = (_user as Customer)?.Cart;
            CartItems = new ObservableCollection<CartItem>(_cart.Items);
            
            _incrementCartItemQuantityCommand = new RelayCommand(IncrementCartItemQuantity, CanIncrement);
            _decrementCartItemQuantityCommand = new RelayCommand(DecrementCartItemQuantity, CanDecrement);
            _createOrderCommand = new RelayCommand(CreateOrder, CanCreateOrder);
            
        }
    }
}