using System.Windows.Media;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;

namespace GenosStore.Utility.AbstractViewModels {
    public class ItemPageViewModel<T>: RequiresUserViewModel where T: Item {
        
        public T Item { get; set; }

        private string _buttonText;
        protected bool _itemIsInCart;
        
        public string ButtonText {
            get { return _buttonText; }
            set {
                _buttonText = value;
                NotifyPropertyChanged("ButtonText");
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

        public ItemPageViewModel(IServices services, User user) : base(services, user) {
            ButtonText = "Купить!";
            _itemIsInCart = false;
            _addToRemoveFromCartCommand = new RelayCommand(AddToRemoveFromCart, CanAddToRemoveFromCart);
        }
    }
}