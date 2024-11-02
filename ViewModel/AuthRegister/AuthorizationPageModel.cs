using System.ComponentModel;
using GenosStore.Utility;

namespace GenosStore.ViewModel.AuthRegister
{
    public class AuthorizationPageModel: AbstractViewModel, INotifyPropertyChanged {
        
        private RelayCommand _authorizeCommand;
        private RelayCommand _registerCommand;
        
        public RelayCommand AuthorizeCommand {
            get { return _authorizeCommand; }
        }

        public RelayCommand RegisterCommand
        {
            get { return _registerCommand; }
        }

        private void Authorize(object parameter) {
            Navigate("View/AuthRegister/RegisterPageView.xaml");
        }

        private void Register(object parameter) {
            Navigate("View/AuthRegister/RegisterIndividualPage.xaml");
        }

        private bool CanAuthorize(object parameter) {
            return true;
        }

        private bool CanRegister(object parameter) {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public AuthorizationPageModel() {
            _authorizeCommand = new RelayCommand(Authorize, CanAuthorize);
            _registerCommand = new RelayCommand(Register, CanRegister);
        }
    }
}