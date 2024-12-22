using System;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types.Enum;
using GenosStore.View.AppWindows;

namespace GenosStore.ViewModel.AppWindows {
    public class AdminMainWindowModel: RequiresUserViewModel {

        public static Action CloseAdmin;

        #region ViewDashboardCommand

        private readonly RelayCommand _viewDashboardCommand;

        public RelayCommand ViewDashboardCommand {
            get { return _viewDashboardCommand; }
        }

        private void ViewDashboard(object parameter) {
            Navigate(
                _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.Dashboard, _services, _user)
            );
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
            Navigate(
                _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.LegalEntityVerification, _services, _user)
            );
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
            Navigate(
                _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.SalesAnalysisReport, _services, _user)
            );
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
            Navigate(
                _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.OrderManagement, _services, _user)
            );
        }

        private bool CanViewOrderManagement(object parameter) {
            return true;
        }

        #endregion

        #region ViewDiscountManagementCommand

        private readonly RelayCommand _viewDiscountManagementCommand;

        public RelayCommand ViewDiscountManagementCommand {
            get { return _viewDiscountManagementCommand; }
        }

        private void ViewDiscountManagement(object parameter) {
            Navigate(
                _services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.DiscountManagement, _services, _user)
            );
        }

        private bool CanViewDiscountManagement(object parameter) {
            return true;
        }

        #endregion

        #region LogoutCommand

        private readonly RelayCommand _logout;

        public RelayCommand LogoutCommand {
            get { return _logout; }
        }

        private void Logout(object parameter) {
            bool answer = Utilities.SpawnQuestionMessageBox("Выход", "Вы уверены, что хотите выйти?");
            if (answer) {
                var mainView = new AuthRegisterWindow(_services);
                mainView.Show();
                CloseAdmin?.Invoke();
            }
        }

        private bool CanLogout(object parameter) {
            return true;
        }

        #endregion
        
        public AdminMainWindowModel(IServices services, User user) : base(services, user) {
            _viewDashboardCommand = new RelayCommand(ViewDashboard, CanViewDashboard);
            _viewLegalEntitiesVerificationCommand = new RelayCommand(ViewLegalEntitiesVerification, CanViewLegalEntitiesVerification);
            _viewSalesReportCommand = new RelayCommand(ViewSalesReport, CanViewSalesReport);
            _viewOrderManagementCommand = new RelayCommand(ViewOrderManagement, CanViewOrderManagement);
            _viewDiscountManagementCommand = new RelayCommand(ViewDiscountManagement, CanViewDiscountManagement);
            _logout = new RelayCommand(Logout, CanLogout);
        }
    }
}