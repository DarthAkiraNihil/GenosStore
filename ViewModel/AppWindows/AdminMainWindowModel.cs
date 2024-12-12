using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;
using GenosStore.ViewModel.Admin;
using GenosStore.ViewModel.AuthRegister;

namespace GenosStore.ViewModel.AppWindows {
    public class AdminMainWindowModel: RequiresUserViewModel {

        #region ViewDashboardCommand

        private readonly RelayCommand _viewDashboardCommand;

        public RelayCommand ViewDashboardCommand {
            get { return _viewDashboardCommand; }
        }

        private void ViewDashboard(object parameter) {
            var args = new NavigationArgsBuilder()
                       .WithURL("View/Admin/DashboardPage.xaml")
                       .WithTitle("Дэшборд")
                       .WithViewModel(new DashboardPageModel(_services, _user))
                       .Build();
            
            Navigate(args);
        }

        private bool CanViewDashboard(object parameter) {
            return true;
        }

        #endregion

        #region ViewLegalEntitiesVerificationCommand

        private readonly RelayCommand _viewLegalEntitiesVerificationCommand;

        public RelayCommand ViewLegalEntitiesVerificationCommand {
            get { return _viewLegalEntitiesVerificationCommand; }
        }

        private void ViewLegalEntitiesVerification(object parameter) {
            var args = new NavigationArgsBuilder()
                       .WithURL("View/Admin/LegalEntityVerificationPage.xaml")
                       .WithTitle("Управление верификацией юридических лиц")
                       .WithViewModel(new LegalEntityVerificationPageModel(_services, _user))
                       .Build();
            
            Navigate(args);
        }

        private bool CanViewLegalEntitiesVerification(object parameter) {
            return true;
        }

        #endregion

        #region ViewSalesReportCommand

        private readonly RelayCommand _viewSalesReportCommand;

        public RelayCommand ViewSalesReportCommand {
            get { return _viewSalesReportCommand; }
        }

        private void ViewSalesReport(object parameter) {
            var args = new NavigationArgsBuilder()
                       .WithURL("View/Admin/SalesAnalysisReportPage.xaml")
                       .WithTitle("Анализ продаж")
                       .WithViewModel(new SalesAnalysisReportPageModel(_services, _user))
                       .Build();
            
            Navigate(args);
        }

        private bool CanViewSalesReport(object parameter) {
            return true;
        }

        #endregion

        #region ViewOrderManagementCommand

        private readonly RelayCommand _viewOrderManagementCommand;

        public RelayCommand ViewOrderManagementCommand {
            get { return _viewOrderManagementCommand; }
        }

        private void ViewOrderManagement(object parameter) {
            var args = new NavigationArgsBuilder()
                       .WithURL("View/Admin/OrderManagementPage.xaml")
                       .WithTitle("Управление активными заказами")
                       .WithViewModel(new OrderManagementPageModel(_services, _user))
                       .Build();
            
            Navigate(args);
        }

        private bool CanViewOrderManagement(object parameter) {
            return true;
        }

        #endregion
        
        public AdminMainWindowModel(IServices services, User user) : base(services, user) {
            _viewDashboardCommand = new RelayCommand(ViewDashboard, CanViewDashboard);
            _viewLegalEntitiesVerificationCommand = new RelayCommand(ViewLegalEntitiesVerification, CanViewLegalEntitiesVerification);
            _viewSalesReportCommand = new RelayCommand(ViewSalesReport, CanViewSalesReport);
            _viewOrderManagementCommand = new RelayCommand(ViewOrderManagement, CanViewOrderManagement);
        }
    }
}