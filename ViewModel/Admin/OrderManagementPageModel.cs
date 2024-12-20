using System.Collections.ObjectModel;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.ViewModel.Admin {
    public class OrderManagementPageModel: RequiresUserViewModel {
        
        private ObservableCollection<OrderDetails> _orders;

        public ObservableCollection<OrderDetails> Orders {
            get { return _orders; }
            set {
                _orders = value;
                NotifyPropertyChanged("Orders");
            }
        }

        #region ToOrderPageCommand

        private readonly RelayCommand _toOrderPageCommand;

        public RelayCommand ToOrderPageCommand {
            get { return _toOrderPageCommand; }
        }

        private void ToOrderPage(object parameter) {
            var id = (long) parameter;
            Navigate(
                _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.SingleOrderManagement, _services, _user, itemId: (int) id)
            );
        }

        private bool CanToOrderPage(object parameter) {
            return true;
        }

        #endregion

        public OrderManagementPageModel(IServices services, User user) : base(services, user) {
            
            _toOrderPageCommand = new RelayCommand(ToOrderPage, CanToOrderPage);
            
            var orders = _services.Entity.Orders.Orders.GetActiveOrders();
            orders.Sort((x, y) => x.Id < y.Id ? 1 : -1);
            Orders = Utilities.ConvertOrdersToHistoryDetails(
                orders,
                _services.Entity.Orders.Orders
            );
            
            Title = "Управление активными заказами";
        }
    }
}