using System;
using System.Windows.Media;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.Utility.AbstractViewModels {
    public abstract class ItemPageViewModel<T>: RequiresUserViewModel where T: Item {
        
        public T Item { get; set; }
        public double? Price { get; set; }
        public double? DiscountedPrice { get; set; }
        public double? OldPrice { get; set; }
        public string DiscountLabel { get; set; }

        private string _buttonText;
        protected bool _itemIsInCart;
        
        public string ButtonText {
            get { return _buttonText; }
            set {
                _buttonText = value;
                NotifyPropertyChanged("ButtonText");
            }
        }

        protected void FillPrices(Item item) {
            
            var discount = item.ActiveDiscount;
            
            if (discount != null) {
                var now = DateTime.Now;
                if (discount.EndsAt < now) {
                    item.ActiveDiscount = null;
                    Price = item.Price;
                } else {
                    DiscountedPrice = item.Price * discount.Value;
                    OldPrice = item.Price;
                }
                DiscountLabel = $"-{(1 - discount.Value) * 100}% (до {discount.EndsAt.ToString("dd/MM/yyyy")})";
            } else {
                Price = item.Price;
            }
            
        }

        #region AddToRemoveFromCartCommand

        private readonly RelayCommand _addToRemoveFromCartCommand;

        public RelayCommand AddToRemoveFromCartCommand {
            get { return _addToRemoveFromCartCommand; }
        }

        protected void AddToRemoveFromCart(object parameter) {
            if (_itemIsInCart) {
                _services.Entity.Orders.Carts.RemoveFromCart(Item, _user as Customer);
            } else {
                _services.Entity.Orders.Carts.AddToCart(Item, _user as Customer);
            }
            
            _itemIsInCart = !_itemIsInCart;
            ButtonText = _itemIsInCart ? "В корзине" : "Купить!";
        }

        private bool CanAddToRemoveFromCart(object parameter) {
            return true;
        }

        #endregion

        protected abstract ItemTypeDescriptor _itemType { get; }

        #region ToItemListCommand

        private readonly RelayCommand _toItemList;

        public RelayCommand ToItemListCommand {
            get { return _toItemList; }
        }

        private void ToItemList(object parameter) {
            Navigate(
                _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.ItemList, _services, _user, _itemType)
            );
        }

        private bool CanToItemList(object parameter) {
            return true;
        }

        #endregion  

        public ItemPageViewModel(IServices services, User user) : base(services, user) {
            ButtonText = "Купить!";
            _itemIsInCart = false;
            
            _addToRemoveFromCartCommand = new RelayCommand(AddToRemoveFromCart, CanAddToRemoveFromCart);
            _toItemList = new RelayCommand(ToItemList, CanToItemList);
        }
    }
}