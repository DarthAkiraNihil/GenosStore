using System.ComponentModel;
using System.Windows.Navigation;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.Navigation;

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
            var args = new NavigationArgsBuilder()
                       .WithURL("View/AuthRegister/AuthorizationPage.xaml")
                       .WithTitle("Authorize")
                       .WithViewModel(new AuthorizationPageModel(_services))
                       .Build();
            
            Navigate(args);
        }
        
        private void BackToAuth(object parameter) {
            var args = new NavigationArgsBuilder()
                       .WithURL("View/AuthRegister/AuthorizationPage.xaml")
                       .WithTitle("Authorize")
                       .WithViewModel(new AuthorizationPageModel(_services))
                       .Build();
            
            Navigate(args);
        }

        private void RegisterLegal(object parameter) {
            var args = new NavigationArgsBuilder()
                       .WithURL("View/AuthRegister/RegisterLegalPage.xaml")
                       .WithTitle("RegisterLegal")
                       .WithViewModel(new RegisterLegalPageModel(_services))
                       .Build();
            
            Navigate(args);
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
        
        public RegisterIndividualPageModel(IServices services): base(services) {
            _registerCommand = new RelayCommand(Register, CanRegister);
            _backToAuthCommand = new RelayCommand(BackToAuth, CanBackToAuth);
            _registerLegalCommand = new RelayCommand(RegisterLegal, CanRegisterLegal);
        }
    }
}