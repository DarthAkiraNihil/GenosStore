﻿using System.Collections.Generic;
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
    public class OrderPageModel: RequiresUserViewModel {
        
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
            if (_order.OrderStatus.Id == (int) OrderStatusDescriptor.AwaitsPayment) {
                Navigate(
                    _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.Payment, _services, _user, _order)
                );
            } else if (_order.OrderStatus.Id == (int) OrderStatusDescriptor.Delivering) {
                _services.Entity.Orders.Orders.ReceiveOrder(_order);
                OrderStatus = _order.OrderStatus.Name;
                NextOrderActionButtonText = "Получен";
                MessageBox.Show("REVEICED");
            }

        }

        private bool CanNextOrderAction(object parameter) {
            return _order.OrderStatus.Id == (int)OrderStatusDescriptor.AwaitsPayment || _order.OrderStatus.Id == (int) OrderStatusDescriptor.Delivering;
        }

        #endregion

        #region CreateReceiptCommand

        private readonly RelayCommand _createReceiptCommand;

        public RelayCommand CreateReceiptCommand {
            get { return _createReceiptCommand; }
        }

        private void CreateReceipt(object parameter) {
            string path = _services.Common.Saving.SpawnSaveDialog();
            if (path != null) {
                if (_user is IndividualEntity) {
                    _services.Common.Reports.CreateOrderReceipt(_user as Customer, _order, path);
                } else if (_user is LegalEntity) {
                    _services.Common.Reports.CreateOrderInvoice(_user as Customer, _order, path);
                }
                
                MessageBox.Show("Чек был успешно создан");
            }
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
            return _order.OrderStatus.Id != (int)OrderStatusDescriptor.Cancelled && _order.OrderStatus.Id != (int)OrderStatusDescriptor.Received;
        }

        #endregion
        
        // private ObservableCollection<OrderItemDetails> ConvertOrderItemsToDetails(List<OrderItems> orderItems) {
        //     var converted = new ObservableCollection<OrderItemDetails>();
        //
        //     foreach (var orderItem in orderItems) {
        //         var item = new OrderItemDetails {
        //             Item = orderItem,
        //             Subtotal = orderItem.Quantity * orderItem.BoughtFor
        //         };
        //         converted.Add(item);
        //     }
        //     
        //     return converted;
        // }
        public OrderPageModel(IServices services, User user, long? orderId) : base(services, user) {
            
            _nextOrderActionCommand = new RelayCommand(NextOrderAction, CanNextOrderAction);
            _cancelOrderCommand = new RelayCommand(CancelOrder, CanCancelOrder);
            _createReceiptCommand = new RelayCommand(CreateReceipt, CanCreateReceipt);

            if (orderId == null) {
                orderId = (int)_services.Entity.Orders.Orders.CreateOrderFromCart(user as Customer);
            }
            
            _order = _services.Entity.Orders.Orders.Get((int) orderId);
            
            OrderItems = Utilities.ConvertOrderItemsToDetails(_order.Items);
            OrderCreatedAt = _order.CreatedAt.ToString("dd/MM/yyyy HH:mm");
            OrderStatus = _order.OrderStatus.Name;
            OrderTitle = $"Заказ №{orderId}";
            Total = _services.Entity.Orders.Orders.CalculateTotal(_order);

            if (_order.OrderStatus.Id == (int) OrderStatusDescriptor.Delivering) {
                NextOrderActionButtonText = "Получить заказ";
            } else if (_order.OrderStatus.Id == (int) OrderStatusDescriptor.AwaitsPayment) {
                NextOrderActionButtonText = "Оплатить";
            } else if (_order.OrderStatus.Id == (int) OrderStatusDescriptor.Paid) {
                NextOrderActionButtonText = "Оплачен";
            }else if (_order.OrderStatus.Id == (int) OrderStatusDescriptor.Received) {
                NextOrderActionButtonText = "Получен";
            } else if (_order.OrderStatus.Id == (int) OrderStatusDescriptor.Cancelled) {
                NextOrderActionButtonText = "Отменён";
            }
            
            Title = OrderTitle;
        }
    }
}