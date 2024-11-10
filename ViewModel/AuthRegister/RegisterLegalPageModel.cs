using GenosStore.Utility;
using System.ComponentModel;

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
			Navigate("View/AuthRegister/AuthorizationPage.xaml", "Authorize", new AuthorizationPageModel());
		}

		private void BackToAuth(object parameter) {
			Navigate("View/AuthRegister/AuthorizationPage.xaml", "Authorize", new AuthorizationPageModel());
		}

		private void RegisterIndividual(object parameter) {
			Navigate("View/AuthRegister/RegisterIndividualPage.xaml", "RegisterIndividual", new RegisterIndividualPageModel());
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

		public RegisterLegalPageModel() {
			_registerCommand = new RelayCommand(Register, CanRegister);
			_backToAuthCommand = new RelayCommand(BackToAuth, CanBackToAuth);
			_registerIndividualCommand = new RelayCommand(RegisterIndividual, CanRegisterIndividual);
		}
	}
}