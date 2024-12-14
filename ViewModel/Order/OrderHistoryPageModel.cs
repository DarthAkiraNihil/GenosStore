using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.ViewModel.Order {
    public class OrderHistoryPageModel: RequiresUserViewModel {

        private ObservableCollection<OrderDetails> _orders;

        public ObservableCollection<OrderDetails> Orders {
            get { return _orders; }
            set {
                _orders = value;
                NotifyPropertyChanged("Orders");
            }
        }

        #region ToOrderPageCommand

        private readonly RelayCommand _toOrderPage;

        public RelayCommand ToOrderPageCommand {
            get { return _toOrderPage; }
        }

        private void ToOrderPage(object parameter) {
            
            long id = (long) parameter;
            
            Navigate(
                _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.Order, _services, _user, null, (int?) id)
            );
            
            // var args = new NavigationArgsBuilder()
            //            .WithURL("View/Order/OrderPage.xaml")
            //            .WithTitle("Оформление заказа")
            //            .WithViewModel(new OrderPageModel(_services, _user, id))
            //            .Build();
            // Navigate(args);
            
        }

        private bool CanToOrderPage(object parameter) {
            return true;
        }

        #endregion

        #region ExportOrderHistoryCommand

        private readonly RelayCommand _exportOrderHistoryCommand;

        public RelayCommand ExportOrderHistoryCommand {
            get { return _exportOrderHistoryCommand; }
        }

        private void ExportOrderHistory(object parameter) {
            string path = _services.Common.Saving.SpawnSaveDialog();
            if (path != null) {
                _services.Common.Reports.CreateOrderHistoryReport(_user as Customer, path);
                MessageBox.Show("CREATE ORDER HISTORY");
            }
        }

        private bool CanExportOrderHistory(object parameter) {
            return Orders.Count > 0;
        }

        #endregion
        
        public OrderHistoryPageModel(IServices services, User user) : base(services, user) {
            var orders = _services.Entity.Orders.Orders.ListOfSpecificCustomer(_user as Customer);
            orders.Sort((x, y) => x.Id < y.Id ? -1 : 1);
            Orders = Utilities.ConvertOrdersToHistoryDetails(
                orders,
                _services.Entity.Orders.Orders
            );
            
            _toOrderPage = new RelayCommand(ToOrderPage, CanToOrderPage);
            _exportOrderHistoryCommand = new RelayCommand(ExportOrderHistory, CanExportOrderHistory);
            
            Title = "История заказов";
        }
    }
}