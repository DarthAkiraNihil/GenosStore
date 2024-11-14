using GenosStore.Utility;
using System.ComponentModel;
using GenosStore.Services.Interface;
using GenosStore.Utility.Navigation;

namespace GenosStore.ViewModel.AuthRegister {
    public class RegisterLegalPageModel: AbstractViewModel {
		private RelayCommand _registerCommand;
		private RelayCommand _backToAuthCommand;
		private RelayCommand _registerIndividualCommand;

		public RelayCommand RegisterCommand {
			get { return _registerCommand; }
		}

		public RelayCommand BackToAuthCommand {
			get { return _backToAuthCommand; }
		}

		public RelayCommand RegisterIndividualCommand {
			get { return _registerIndividualCommand; }
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

		private void RegisterIndividual(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/AuthRegister/RegisterIndividualPage.xaml")
			           .WithTitle("Authorize")
			           .WithViewModel(new RegisterIndividualPageModel(_services))
			           .Build();
            
			Navigate(args);

		}


		private bool CanRegister(object parameter) {
			return true;
		}

		private bool CanBackToAuth(object parameter) {
			return true;
		}

		private bool CanRegisterIndividual(object parameter) {
			return true;
		}

		public RegisterLegalPageModel(IServices services): base(services) {
			_registerCommand = new RelayCommand(Register, CanRegister);
			_backToAuthCommand = new RelayCommand(BackToAuth, CanBackToAuth);
			_registerIndividualCommand = new RelayCommand(RegisterIndividual, CanRegisterIndividual);
		}
	}
}