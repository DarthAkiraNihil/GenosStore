using System.ComponentModel;
using GenosStore.Model.Entity.User;
using System.Windows.Media.Animation;
using GenosStore.View.AppWindows;
using GenosStore.Utility;
using System;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Services.Interface;
using GenosStore.Utility.Navigation;

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

            
            var mainView = new MainWindow(_services);// { DataContext = new MainViewModel(user) };
			mainView.Show();
            Close?.Invoke();
			//RequestClose(this, new EventArgs());
		}

        private void Register(object parameter) {
            var args = new NavigationArgsBuilder()
                .WithURL("View/AuthRegister/RegisterIndividualPage.xaml")
                .WithTitle("Authorize")
                .WithViewModel(new RegisterIndividualPageModel(_services))
                .Build();
            
            Navigate(args);
        }

        private bool CanAuthorize(object parameter) {
            return true;
        }

        private bool CanRegister(object parameter) {
            return true;
        }

        public AuthorizationPageModel(IServices services): base(services) {
            _authorizeCommand = new RelayCommand(Authorize, CanAuthorize);
            _registerCommand = new RelayCommand(Register, CanRegister);
        }

    }
}