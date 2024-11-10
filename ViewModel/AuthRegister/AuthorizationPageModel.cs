using System.ComponentModel;
using GenosStore.Model.Entity.User;
using System.Windows.Media.Animation;
using GenosStore.View.AppWindows;
using GenosStore.Utility;
using System;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;

namespace GenosStore.ViewModel.AuthRegister
{
    public class AuthorizationPageModel: AbstractViewModel {
        
        private RelayCommand _authorizeCommand;
        private RelayCommand _registerCommand;

		public static Action Close;

		public RelayCommand AuthorizeCommand {
            get { return _authorizeCommand; }
        }

        public RelayCommand RegisterCommand
        {
            get { return _registerCommand; }
		}

        private void Authorize(object parameter) {
            var c = new GenosStoreDatabaseContext();
            var mb = new Motherboard();

            
            var mainView = new MainWindow();// { DataContext = new MainViewModel(user) };
			mainView.Show();
            Close?.Invoke();
			//RequestClose(this, new EventArgs());
		}

        private void Register(object parameter) {
            Navigate("View/AuthRegister/RegisterIndividualPage.xaml", "Authorize", new RegisterIndividualPageModel());
        }

        private bool CanAuthorize(object parameter) {
            return true;
        }

        private bool CanRegister(object parameter) {
            return true;
        }

        public AuthorizationPageModel() {
            _authorizeCommand = new RelayCommand(Authorize, CanAuthorize);
            _registerCommand = new RelayCommand(Register, CanRegister);
        }

    }
}