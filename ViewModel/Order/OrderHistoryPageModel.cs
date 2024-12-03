using System.Collections.Generic;
using System.Collections.ObjectModel;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;

namespace GenosStore.ViewModel.Order {
    public class OrderHistoryPageModel: RequiresUserViewModel {
        public class OrderHistoryDetails {
            public long Id { get; set; }
            public string OrderTitle { get; set; }
            public string OrderCreatedAt { get; set; }
            public string OrderStatus { get; set; }
            public double Total { get; set; }
        }

        private ObservableCollection<OrderHistoryDetails> _orders;

        public ObservableCollection<OrderHistoryDetails> Orders {
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
            
            var args = new NavigationArgsBuilder()
                       .WithURL("View/Order/OrderPage.xaml")
                       .WithTitle("Оформление заказа")
                       .WithViewModel(new OrderPageModel(_services, _user, id))
                       .Build();
            Navigate(args);
            
        }

        private bool CanToOrderPage(object parameter) {
            return true;
        }

        #endregion
        
        private ObservableCollection<OrderHistoryDetails> ConvertOrdersToHistoryDetails(List<Model.Entity.Orders.Order> orders) {
            var converted = new ObservableCollection<OrderHistoryDetails>();

            foreach (var order in orders) {
                var item = new OrderHistoryDetails {
                    Id = order.Id,
                    OrderTitle = $"Заказ №{order.Id}",
                    OrderCreatedAt = order.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                    OrderStatus = order.OrderStatus.Name,
                    Total = _services.Entity.Orders.Orders.CalculateTotal(order)
                };
                converted.Add(item);
            }
            
            return converted;
        }
        public OrderHistoryPageModel(IServices services, User user) : base(services, user) {
            var orders = _services.Entity.Orders.Orders.ListOfSpecificCustomer(_user as Customer);
            orders.Sort((x, y) => x.Id < y.Id ? -1 : 1);
            Orders = ConvertOrdersToHistoryDetails(
                orders
            );
            
            _toOrderPage = new RelayCommand(ToOrderPage, CanToOrderPage);
        }
    }
}