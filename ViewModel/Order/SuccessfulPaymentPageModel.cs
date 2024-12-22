using System.Windows;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types.Enum;
using GenosStore.ViewModel.Main;

namespace GenosStore.ViewModel.Order {
    public class SuccessfulPaymentPageModel: RequiresUserViewModel {
        private readonly Model.Entity.Orders.Order _order;

        #region ToOrderPageCommand

        private readonly RelayCommand _toOrderPageCommand;

        public RelayCommand ToOrderPageCommand {
            get { return _toOrderPageCommand; }
        }

        private void ToOrderPage(object parameter) {
            Navigate(
                _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.Order, _services, _user, null, (int) _order.Id)
            );
        }

        private bool CanToOrderPage(object parameter) {
            return true;
        }

        #endregion

        #region ToMainPageCommand

        private readonly RelayCommand _toMainPageCommand;

        public RelayCommand ToMainPageCommand {
            get { return _toMainPageCommand; }
        }

        private void ToMainPage(object parameter) {
            Navigate(
                _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.Main, _services, _user)
            );
        }

        private bool CanToMainPage(object parameter) {
            return true;
        }

        #endregion

        #region CreateReceiptCommand

        private readonly RelayCommand _createReceiptCommand;

        public RelayCommand CreateReceiptCommand {
            get { return _createReceiptCommand; }
        }

        private void CreateReceipt(object parameter) {
            string path = _services.Common.Saving.SpawnSaveDialog($"Заказ №{_order.Id}");
            if (path != null) {
                if (_user is IndividualEntity) {
                    _services.Common.Reports.CreateOrderReceipt(_user as Customer, _order, path);
                    Utilities.SpawnInfoMessageBox("Успех!","Чек был успешно создан!");
                } else if (_user is LegalEntity) {
                    _services.Common.Reports.CreateOrderInvoice(_user as Customer, _order, path);
                    Utilities.SpawnInfoMessageBox("Успех!","Счёт-фактура была успешно создана!");
                }
            }
        }

        private bool CanCreateReceipt(object parameter) {
            return true;
        }

        #endregion
        
        
        
        public SuccessfulPaymentPageModel(IServices services, User user, Model.Entity.Orders.Order order) : base(services, user) {
            _order = order;
            
            _toOrderPageCommand = new RelayCommand(ToOrderPage, CanToOrderPage);
            _toMainPageCommand = new RelayCommand(ToMainPage, CanToMainPage);
            _createReceiptCommand = new RelayCommand(CreateReceipt, CanCreateReceipt);
            
            Title = "Оплата прошла успешно";
        }
    }
}