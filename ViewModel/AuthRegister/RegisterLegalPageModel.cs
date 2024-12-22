using GenosStore.Utility;
using System.ComponentModel;
using System.Windows;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types.AuthRegister;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.ViewModel.AuthRegister {
    public class RegisterLegalPageModel: AbstractViewModel, INeedsPasswordViewModel, INeedsPasswordConfirmationViewModel {
		private readonly RelayCommand _registerCommand;
		private readonly RelayCommand _backToAuthCommand;
		private readonly RelayCommand _registerIndividualCommand;

		#region Properties

		private string _email;

		public string Email {
			get { return _email; }
			set {
				_email = value;
				NotifyPropertyChanged("Email");
			}
		}

		private long _inn;

		public long INN {
			get { return _inn; }
			set {
				_inn = value;
				NotifyPropertyChanged("INN");
			}
		}

		private long _kpp;

		public long KPP {
			get { return _kpp; }
			set {
				_kpp = value;
				NotifyPropertyChanged("KPP");
			}
		}

		private string _physicalAddress;

		public string PhysicalAddress {
			get { return _physicalAddress; }
			set {
				_physicalAddress = value;
				NotifyPropertyChanged("PhysicalAddress");
			}
		}

		private string _legalAddress;

		public string LegalAddress {
			get { return _legalAddress; }
			set {
				_legalAddress = value;
				NotifyPropertyChanged("LegalAddress");
			}
		}

		private string _password;

		public string Password {
			get { return _password; }
			set {
				_password = value;
				NotifyPropertyChanged("Password");
			}
		}

		private string _confirmPassword;

		public string ConfirmPassword {
			get { return _confirmPassword; }
			set {
				_confirmPassword = value;
				NotifyPropertyChanged("ConfirmPassword");
			}
		}

		private string _emailError;

		public string EmailError {
			get { return _emailError; }
			set {
				_emailError = value;
				NotifyPropertyChanged("EmailError");
			}
		}

		private string _innError;

		public string INNError {
			get { return _innError; }
			set {
				_innError = value;
				NotifyPropertyChanged("INNError");
			}
		}

		private string _passwordError;

		public string PasswordError {
			get { return _passwordError; }
			set {
				_passwordError = value;
				NotifyPropertyChanged("PasswordError");
			}
		}

		#endregion

		#region RegisterCommand

		public RelayCommand RegisterCommand {
			get { return _registerCommand; }
		}
		
		private void Register(object parameter) {
			
			var registrationStatus = _services.Common.Authorization.RegisterLegal(
				new LegalEntityRegistrationData {
					Email = Email,
					INN = INN,
					KPP = KPP,
					PhysicalAddress = PhysicalAddress,
					LegalAddress = LegalAddress,
					Password = Password,
					ConfirmPassword = ConfirmPassword
				}
			);

			switch (registrationStatus) {
				case RegistrationStatus.Success: {
                    
					Utilities.SpawnInfoMessageBox("Успех!,","Регистрация прошла успешно. Ожидайте подтверждения юридического лица.");
					Navigate(_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.Authorization, _services));
                    
					break;
				}
				case RegistrationStatus.UserAlreadyExists: {
					EmailError = "Такой пользователь уже существует";
					break;
				}
				case RegistrationStatus.TooWeakPassword: {
					PasswordError = "Пароль слишком слабый";
					break;
				}
				case RegistrationStatus.PasswordsDoNotMatch: {
					PasswordError = "Пароли не совпадают";
					break;
				}
				case RegistrationStatus.InvalidEmail: {
					EmailError = "Некорректный адрес электронной почты";
					break;
				}
                
			}
		}
		
		private bool CanRegister(object parameter) {
			return 
			    Email?.Length > 0
			&&  PhysicalAddress?.Length > 0
			&&  LegalAddress?.Length > 0
			&&  Password?.Length > 0
			&&  ConfirmPassword?.Length > 0;
		}

		#endregion
		
		#region RegisterIndividualCommand
		
		public RelayCommand RegisterIndividualCommand {
			get { return _registerIndividualCommand; }
		}

		private void RegisterIndividual(object parameter) {
			// var args = new NavigationArgsBuilder()
			//            .WithURL("View/AuthRegister/RegisterIndividualPage.xaml")
			//            .WithTitle("Регистрация физического лица")
			//            .WithViewModel(new RegisterIndividualPageModel(_services))
			//            .Build();
            
			Navigate(_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.RegisterIndividual, _services));

		}
		
		private bool CanRegisterIndividual(object parameter) {
			return true;
		}
		
		#endregion
		
		#region RegisterBackToAuthCommand
		
		public RelayCommand BackToAuthCommand {
			get { return _backToAuthCommand; }
		}
		
		private void BackToAuth(object parameter) {
			Navigate(_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.Authorization, _services));
		}
		
		private bool CanBackToAuth(object parameter) {
			return true;
		}
		
		#endregion

		public RegisterLegalPageModel(IServices services): base(services) {
			_registerCommand = new RelayCommand(Register, CanRegister);
			_backToAuthCommand = new RelayCommand(BackToAuth, CanBackToAuth);
			_registerIndividualCommand = new RelayCommand(RegisterIndividual, CanRegisterIndividual);
			
			Title = "Регистрация юридического лица";
		}
	}
}