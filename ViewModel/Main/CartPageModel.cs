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
using GenosStore.Utility.Types;
using GenosStore.Utility.Types.Enum;
using GenosStore.ViewModel.Order;

namespace GenosStore.ViewModel.Main {
    public class CartPageModel: RequiresUserViewModel {

        private Cart _cart;
        private ObservableCollection<CartItemElement> _cartItems;

        public class CartItemElement {
            public CartItem Item { get; set; }
            public double? Price { get; set; }
            public double? DiscountedPrice { get; set; }
            public double? OldPrice { get; set; }
            public double Subtotal { get; set; }
            public string DiscountLabel { get; set; }
        }

        private double _total;

        public double Total {
            get { return _total; }
            set {
                _total = value;
                NotifyPropertyChanged("Total");
            }
        }
        

        public ObservableCollection<CartItemElement> CartItems {
            get { return _cartItems; }
            set {
                _cartItems = value;
                NotifyPropertyChanged("CartItems");
            }
        }
        
        protected ObservableCollection<CartItemElement> GetItemsAndCheckDiscounts(List<CartItem> items) {
            var converted = new ObservableCollection<CartItemElement>();

            var countedTotal = 0.0;

            foreach (var item in items) {
                var discount = item.Item.ActiveDiscount;
                var cartItem = new CartItemElement {Item = item};
                if (discount != null) {
                    if (!_services.Entity.Orders.ActiveDiscounts.IsActive(discount)) {
                        _services.Entity.Orders.ActiveDiscounts.Deactivate(discount);
                        discount = null;
                    }
                }

                if (discount != null) {
                    cartItem.DiscountedPrice = item.Item.Price * discount.Value;
                    cartItem.OldPrice = item.Item.Price;
                    cartItem.Subtotal = item.Item.Price * discount.Value * item.Quantity;
                    cartItem.DiscountLabel = $"-{(1 - discount.Value) * 100}% (до {discount.EndsAt.ToString("dd/MM/yyyy")})";
                } else {
                    cartItem.Price = item.Item.Price;
                    cartItem.Subtotal = item.Item.Price * item.Quantity;
                }
				
                countedTotal += cartItem.Subtotal;
                converted.Add(cartItem);
            }
            
            Total = countedTotal;
			
            return converted;
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
            CartItems = GetItemsAndCheckDiscounts(_cart.Items);
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
            CartItems = GetItemsAndCheckDiscounts(_cart.Items);
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
            Navigate(
                _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.Order, _services, _user, null, null)
            );
        }

        private bool CanCreateOrder(object parameter) {
            return _cart.Items.Count > 0;
        }

        #endregion
        
        public CartPageModel(IServices services, User user) : base(services, user) {
            _cart = (_user as Customer)?.Cart;
            CartItems = GetItemsAndCheckDiscounts(_cart.Items);
            //CartItems = new ObservableCollection<CartItem>(_cart.Items);
            
            _incrementCartItemQuantityCommand = new RelayCommand(IncrementCartItemQuantity, CanIncrement);
            _decrementCartItemQuantityCommand = new RelayCommand(DecrementCartItemQuantity, CanDecrement);
            _createOrderCommand = new RelayCommand(CreateOrder, CanCreateOrder);
            
            Title = "Корзина";
        }
    }
}