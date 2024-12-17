using System.Collections.ObjectModel;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types;
using GenosStore.Utility.Types.Enum;
using GenosStore.ViewModel.Order;

namespace GenosStore.ViewModel.Admin {
    public class SingleOrderManagementPageModel: RequiresUserViewModel {
        
        private Model.Entity.Orders.Order _order;
        private ObservableCollection<OrderItemDetails> _orderItems;

        private string _promoteOrderButtonText;

        public string PromoteOrderButtonText {
            get { return _promoteOrderButtonText; }
            set {
                _promoteOrderButtonText = value;
                NotifyPropertyChanged("PromoteOrderButtonText");
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

        #region PromoteOrderCommand

        private readonly RelayCommand _promoteOrderCommand;

        public RelayCommand PromoteOrderCommand {
            get { return _promoteOrderCommand; }
        }

        private void PromoteOrder(object parameter) {
            switch (_order.OrderStatus.Id) {
                case (int)OrderStatusDescriptor.Created: {
                    _order.OrderStatus = _services.Entity.Orders.OrderStatuses.Get((int) OrderStatusDescriptor.Confirmed);
                    break;
                }
                case (int)OrderStatusDescriptor.Confirmed: {
                    _order.OrderStatus = _services.Entity.Orders.OrderStatuses.Get((int) OrderStatusDescriptor.AwaitsPayment);
                    break;
                }
                case (int)OrderStatusDescriptor.Paid: {
                    _order.OrderStatus = _services.Entity.Orders.OrderStatuses.Get((int) OrderStatusDescriptor.Processing);
                    break;
                }
                case (int)OrderStatusDescriptor.Processing: {
                    _order.OrderStatus = _services.Entity.Orders.OrderStatuses.Get((int) OrderStatusDescriptor.Delivering);
                    break;
                }
                default: {
                    return;
                }

            }
            
            _services.Entity.Orders.Orders.Update(_order);
            _services.Entity.Orders.Orders.Save();
            OrderStatus = _order.OrderStatus.Name;
            
            SetPromoteOrderButtonText();
        }

        private bool CanPromoteOrder(object parameter) {
            return 
                    _order.OrderStatus.Id == (int) OrderStatusDescriptor.Created
                ||  _order.OrderStatus.Id == (int) OrderStatusDescriptor.Confirmed
                ||  _order.OrderStatus.Id == (int) OrderStatusDescriptor.Paid
                ||  _order.OrderStatus.Id == (int) OrderStatusDescriptor.Processing;
        }

        #endregion

        private void SetPromoteOrderButtonText() {
            switch (_order.OrderStatus.Id) {
                case (int)OrderStatusDescriptor.Created: {
                    PromoteOrderButtonText = "Подтвердить заказ";
                    break;
                }
                case (int)OrderStatusDescriptor.Confirmed: {
                    PromoteOrderButtonText = "Перейти в ожидание оплаты";
                    break;
                }
                case (int)OrderStatusDescriptor.AwaitsPayment: {
                    PromoteOrderButtonText = "Ожидает оплаты";
                    break;
                }
                case (int)OrderStatusDescriptor.Paid: {
                    PromoteOrderButtonText = "Начать обработку";
                    break;
                }
                case (int)OrderStatusDescriptor.Processing: {
                    PromoteOrderButtonText = "Начать доставку";
                    break;
                }
                case (int)OrderStatusDescriptor.Delivering: {
                    PromoteOrderButtonText = "Доставляется";
                    break;
                }
                case (int)OrderStatusDescriptor.Cancelled: {
                    PromoteOrderButtonText = "Отменён";
                    break;
                }
                default: {
                    PromoteOrderButtonText = "Некорректный статус";
                    break;
                }

            }
        }
        
        public SingleOrderManagementPageModel(IServices services, User user, int orderId) : base(services, user) {
            
            _promoteOrderCommand = new RelayCommand(PromoteOrder, CanPromoteOrder);
            
            _order = _services.Entity.Orders.Orders.Get(orderId);
            
            OrderItems = Utilities.ConvertOrderItemsToDetails(_order.Items);
            OrderCreatedAt = _order.CreatedAt.ToString("dd/MM/yyyy HH:mm");
            OrderStatus = _order.OrderStatus.Name;
            OrderTitle = $"Заказ №{orderId}";
            Total = _services.Entity.Orders.Orders.CalculateTotal(_order);

            SetPromoteOrderButtonText();
            
            Title = OrderTitle;
            
        }
    }
}