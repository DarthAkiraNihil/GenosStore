using System.ComponentModel;
using System.Windows.Navigation;
using GenosStore.Utility;

namespace GenosStore.ViewModel.AuthRegister
{
    public class RegisterIndividualPageModel: AbstractViewModel, INotifyPropertyChanged
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
            Navigate("View/AuthRegister/AuthorizationPage.xaml");
        }
        
        private void BackToAuth(object parameter) {
            Navigate("View/AuthRegister/AuthorizationPage.xaml");
        }

        private void RegisterLegal(object parameter)
        {
        }
        

        private bool CanRegister(object parameter) {
            return true;
        }
        
        private bool CanBackToAuth(object parameter) {
            return true;
        }

        private bool CanRegisterLegal(object parameter)
        {
            return true;
        }
        
        

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public RegisterIndividualPageModel() {
            _registerCommand = new RelayCommand(Register, CanRegister);
            _backToAuthCommand = new RelayCommand(BackToAuth, CanBackToAuth);
            _registerLegalCommand = new RelayCommand(RegisterLegal, CanRegisterLegal);
        }
    }
}