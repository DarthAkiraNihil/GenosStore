using System.Collections.ObjectModel;
using System.Data.Common;
using System.Windows;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;

namespace GenosStore.ViewModel.Order {
    public class PaymentPageModel: RequiresUserViewModel {

        public class PaymentOrderDetails {
            public long Id { get; set; }
            public string CreatedAt { get; set; }
            public double Total { get; set; }
            public string Orderer { get; set; }
        }
        
        private Model.Entity.Orders.Order _orderObj;
        private ObservableCollection<BankCard> _customerBankCards;

        private PaymentOrderDetails _order;

        public PaymentOrderDetails Order {
            get { return _order; }
            set {
                _order = value;
                NotifyPropertyChanged("Order");
            }
        }

        public ObservableCollection<BankCard> CustomerBankCards {
            get { return _customerBankCards; }
            set {
                _customerBankCards = value;
                NotifyPropertyChanged("CustomerBankCards");
            }
        }

        private BankCard _selectedCard;

        public BankCard SelectedCard {
            get { return _selectedCard; }
            set {
                _selectedCard = value;
                NotifyPropertyChanged("SelectedCard");
            }
        }

        #region PayOrderCommand

        private readonly RelayCommand _payOrderCommand;

        public RelayCommand PayOrderCommand {
            get { return _payOrderCommand; }
        }

        private void PayOrder(object parameter) {
            if (_services.Common.Payment.ProcessPayment(_orderObj)) {
                MessageBox.Show("Payment successful");
                var args = new NavigationArgsBuilder()
                           .WithURL("View/Order/SuccessfulPaymentPage.xaml")
                           .WithTitle("Успешная оплата!")
                           .WithViewModel(new SuccessfulPaymentPageModel(_services, _user, _orderObj))
                           .Build();
                Navigate(args);
            } else {
                MessageBox.Show("Payment failed");
            }
            
        }

        private bool CanPayOrder(object parameter) {
            return SelectedCard != null;
        }

        #endregion
        
        public PaymentPageModel(IServices services, User user, Model.Entity.Orders.Order order) : base(services, user) {
            _orderObj = order;
            _payOrderCommand = new RelayCommand(PayOrder, CanPayOrder);
            
            CustomerBankCards = new ObservableCollection<BankCard>((user as Customer)?.BankCards);
            Order = new PaymentOrderDetails {
                Id = _orderObj.Id,
                CreatedAt = _orderObj.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                Total = _services.Entity.Orders.Orders.CalculateTotal(_orderObj),
                Orderer = _services.Common.Payment.GetOrdererInfo(_user as Customer)
            };
            
        }
    }
}