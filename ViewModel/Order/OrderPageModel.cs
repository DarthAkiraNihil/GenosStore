using System.Collections.Generic;
using System.Collections.ObjectModel;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.Order {
    public class OrderPageModel: RequiresUserViewModel {

        public class OrderItemDetails {
            public OrderItems Item { get; set; }
            public double Subtotal { get; set; }
        }

        private ObservableCollection<OrderItemDetails> _orderItems;

        public ObservableCollection<OrderItemDetails> OrderItems {
            get { return _orderItems; }
            set {
                _orderItems = value;
                NotifyPropertyChanged("OrderItems");
            }
        }

        private double _total;

        public double Total {
            get { return _total; }
            set {
                _total = value;
                NotifyPropertyChanged("Total");
            }
        }

        private string _orderTitle;

        public string OrderTitle {
            get { return _orderTitle; }
            set {
                _orderTitle = value;
                NotifyPropertyChanged("OrderTitle");
            }
        }

        private string _orderStatus;

        public string OrderStatus {
            get { return _orderStatus; }
            set {
                _orderStatus = value;
                NotifyPropertyChanged("OrderStatus");
            }
        }

        private string _orderCreatedAt;

        public string OrderCreatedAt {
            get { return _orderCreatedAt; }
            set {
                _orderCreatedAt = value;
                NotifyPropertyChanged("OrderCreatedAt");
            }
        }

        private ObservableCollection<OrderItemDetails> ConvertOrderItemsToDetails(List<OrderItems> orderItems) {
            var converted = new ObservableCollection<OrderItemDetails>();
            var total = 0.0;

            foreach (var orderItem in orderItems) {
                var item = new OrderItemDetails {
                    Item = orderItem,
                    Subtotal = orderItem.Quantity * orderItem.BoughtFor
                };
                converted.Add(item);
                total += item.Subtotal;
            }
            
            Total = total;
            return converted;
        }
        public OrderPageModel(IServices services, User user, int? orderId) : base(services, user) {

            if (orderId == null) {
                orderId = (int) _services.Entity.Orders.Orders.CreateOrderFromCart(user as Customer);
            }
            
            var order = _services.Entity.Orders.Orders.Get((int) orderId);
            OrderItems = ConvertOrderItemsToDetails(order.Items);
            OrderCreatedAt = order.CreatedAt.ToString("dd/MM/yyyy HH:mm");
            OrderStatus = order.OrderStatus.Name;
            OrderTitle = $"Заказ №{orderId}";
        }
    }
}