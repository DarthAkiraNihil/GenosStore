using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;

namespace GenosStore.ViewModel.Order {
    public class OrderPageModel: RequiresUserViewModel {

        public class OrderItemDetails {
            public OrderItems Item { get; set; }
            public double Subtotal { get; set; }
        }
        
        private Model.Entity.Orders.Order _order;
        private ObservableCollection<OrderItemDetails> _orderItems;

        private string _nextOrderActionButtonText;

        public string NextOrderActionButtonText {
            get { return _nextOrderActionButtonText; }
            set {
                _nextOrderActionButtonText = value;
                NotifyPropertyChanged("NextOrderActionButtonText");
            }
        }

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

        #region NextOrderActionCommand

        private readonly RelayCommand _nextOrderActionCommand;

        public RelayCommand NextOrderActionCommand {
            get { return _nextOrderActionCommand; }
        }

        private void NextOrderAction(object parameter) {
            if (_order.OrderStatus.Name == "Created") {
                var args = new NavigationArgsBuilder()
                           .WithURL("View/Order/PaymentPage.xaml")
                           .WithViewModel(new PaymentPageModel(_services, _user, _order))
                           .WithTitle("Оплата заказа")
                           .Build();
            
                Navigate(args);
            } else if (_order.OrderStatus.Name == "Paid") {
                _services.Entity.Orders.Orders.ReceiveOrder(_order);
                OrderStatus = _order.OrderStatus.Name;
                NextOrderActionButtonText = "Получен";
                MessageBox.Show("REVEICED");
            }

        }

        private bool CanNextOrderAction(object parameter) {
            return OrderStatus != "Cancelled" && OrderStatus != "Received";
        }

        #endregion

        #region CreateReceiptCommand

        private readonly RelayCommand _createReceiptCommand;

        public RelayCommand CreateReceiptCommand {
            get { return _createReceiptCommand; }
        }

        private void CreateReceipt(object parameter) {
            MessageBox.Show("CREATE RECEIPT");
        }

        private bool CanCreateReceipt(object parameter) {
            return true;
        }

        #endregion

        #region CancelOrderCommand

        private readonly RelayCommand _cancelOrderCommand;

        public RelayCommand CancelOrderCommand {
            get { return _cancelOrderCommand; }
        }

        private void CancelOrder(object parameter) {
            _services.Entity.Orders.Orders.CancelOrder(_order);
            OrderStatus = _order.OrderStatus.Name;
            NextOrderActionButtonText = "Отменён";
            MessageBox.Show("CANCEL ORDER");
        }

        private bool CanCancelOrder(object parameter) {
            return OrderStatus != "Cancelled" && OrderStatus != "Received";
        }

        #endregion
        
        private ObservableCollection<OrderItemDetails> ConvertOrderItemsToDetails(List<OrderItems> orderItems) {
            var converted = new ObservableCollection<OrderItemDetails>();

            foreach (var orderItem in orderItems) {
                var item = new OrderItemDetails {
                    Item = orderItem,
                    Subtotal = orderItem.Quantity * orderItem.BoughtFor
                };
                converted.Add(item);
            }
            
            return converted;
        }
        public OrderPageModel(IServices services, User user, long? orderId) : base(services, user) {
            
            _nextOrderActionCommand = new RelayCommand(NextOrderAction, CanNextOrderAction);
            _cancelOrderCommand = new RelayCommand(CancelOrder, CanCancelOrder);
            _createReceiptCommand = new RelayCommand(CreateReceipt, CanCreateReceipt);

            if (orderId == null) {
                orderId = (int)_services.Entity.Orders.Orders.CreateOrderFromCart(user as Customer);
            }
            
            _order = _services.Entity.Orders.Orders.Get((int) orderId);
            
            OrderItems = ConvertOrderItemsToDetails(_order.Items);
            OrderCreatedAt = _order.CreatedAt.ToString("dd/MM/yyyy HH:mm");
            OrderStatus = _order.OrderStatus.Name;
            OrderTitle = $"Заказ №{orderId}";
            Total = _services.Entity.Orders.Orders.CalculateTotal(_order);

            if (OrderStatus == "Paid") {
                NextOrderActionButtonText = "Получить заказ";
            } else if (OrderStatus == "Created") {
                NextOrderActionButtonText = "Оплатить";
            } else if (OrderStatus == "Received") {
                NextOrderActionButtonText = "Получен";
            } else if (OrderStatus == "Cancelled") {
                NextOrderActionButtonText = "Отменён";
            }
        }
    }
}