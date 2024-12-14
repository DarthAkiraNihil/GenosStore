using System.Windows;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;
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
            var args = new NavigationArgsBuilder()
                       .WithURL("View/Order/OrderPage.xaml")
                       .WithTitle("Оформление заказа")
                       .WithViewModel(new OrderPageModel(_services, _user, _order.Id))
                       .Build();
            Navigate(args);
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
            var args = new NavigationArgsBuilder()
                       .WithURL("View/Main/MainPage.xaml")
                       .WithTitle("Главная страница")
                       .WithViewModel(new MainPageModel(_services, _user))
                       .Build();
            Navigate(args);
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
            MessageBox.Show("MOCK");
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