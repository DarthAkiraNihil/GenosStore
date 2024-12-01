using System.Collections.Generic;
using System.Collections.ObjectModel;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.Order {
    public class OrderHistoryPageModel: RequiresUserViewModel {
        public class OrderHistoryDetails {
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
        
        private ObservableCollection<OrderHistoryDetails> ConvertOrdersToHistoryDetails(List<Model.Entity.Orders.Order> orders) {
            var converted = new ObservableCollection<OrderHistoryDetails>();

            foreach (var order in orders) {
                var item = new OrderHistoryDetails {
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
            
            Orders = ConvertOrdersToHistoryDetails(
                _services.Entity.Orders.Orders.ListOfSpecificCustomer(_user as Customer)
            );
            
        }
    }
}