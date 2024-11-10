using System.ComponentModel;
using System.Windows.Navigation;
using GenosStore.Utility;

namespace GenosStore.ViewModel.AuthRegister
{
    public class RegisterIndividualPageModel: AbstractViewModel
    {
        private RelayCommand _registerCommand;
        private RelayCommand _backToAuthCommand;
        private RelayCommand _registerLegalCommand;

        public RelayCommand RegisterCommand {
            get {return _registerCommand; }
        }

        public RelayCommand BackToAuthCommand
        {
            get { return _backToAuthCommand; }
        }
        
        public RelayCommand RegisterLegalCommand {
            get { return _registerLegalCommand; }
        }

        private void Register(object parameter) {
            Navigate("View/AuthRegister/AuthorizationPage.xaml", "Authorize", new AuthorizationPageModel());
        }
        
        private void BackToAuth(object parameter) {
            Navigate("View/AuthRegister/AuthorizationPage.xaml", "Authorize", new AuthorizationPageModel());
        }

        private void RegisterLegal(object parameter) {
			Navigate("View/AuthRegister/RegisterLegalPage.xaml", "RegisterLegal", new RegisterLegalPageModel());
		}
        

        private bool CanRegister(object parameter) {
            return true;
        }
        
        private bool CanBackToAuth(object parameter) {
            return true;
        }

        private bool CanRegisterLegal(object parameter) {
            return true;
        }
        
        public RegisterIndividualPageModel() {
            _registerCommand = new RelayCommand(Register, CanRegister);
            _backToAuthCommand = new RelayCommand(BackToAuth, CanBackToAuth);
            _registerLegalCommand = new RelayCommand(RegisterLegal, CanRegisterLegal);
        }
    }
}