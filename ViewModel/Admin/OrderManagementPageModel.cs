using System.Collections.ObjectModel;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types;

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

        public OrderManagementPageModel(IServices services, User user) : base(services, user) {
            var orders = _services.Entity.Orders.Orders.GetActiveOrders();
            orders.Sort((x, y) => x.Id < y.Id ? -1 : 1);
            Orders = Utilities.ConvertOrdersToHistoryDetails(
                orders,
                _services.Entity.Orders.Orders
            );
        }
    }
}