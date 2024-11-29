using System.ComponentModel;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Navigation;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Entity.Users;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types.AuthRegister;

namespace GenosStore.ViewModel.AuthRegister
{
    public class RegisterIndividualPageModel: AbstractViewModel
    {
        
        private readonly RelayCommand _registerCommand;
        private readonly RelayCommand _backToAuthCommand;
        private readonly RelayCommand _registerLegalCommand;

        private string _name;
        private string _surname;
        private string _email;
        private string _phoneNumber;
        private string _password;
        private string _confirmPassword;

        #region Properties

        public string Name {
            get { return _name; }
            set {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Surname {
            get { return _surname; }
            set {
                _surname = value;
                NotifyPropertyChanged("Surname");
            }
        }

        public string Email {
            get { return _email; }
            set {
                _email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public string PhoneNumber {
            get { return _phoneNumber; }
            set {
                _phoneNumber = value;
                NotifyPropertyChanged("PhoneNumber");
            }
        }

        public string Password {
            get { return _password; }
            set {
                _password = value;
                NotifyPropertyChanged("Password");
            }
        }

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

        private string _phoneError;

        public string PhoneError {
            get { return _phoneError; }
            set {
                _phoneError = value;
                NotifyPropertyChanged("PhoneError");
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
            get {return _registerCommand; }
        }
        
        private void Register(object parameter) {

            var registrationStatus = _services.Common.Authorization.RegisterIndividual(
                new IndividualEntityRegistrationData {
                    Name = Name,
                    Surname = Surname,
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    Password = Password,
                    ConfirmPassword = ConfirmPassword,
                }
            );

            switch (registrationStatus) {
                case RegistrationStatus.Success: {
                    
                    MessageBox.Show("REGISTERED");
            
                    var args = new NavigationArgsBuilder()
                               .WithURL("View/AuthRegister/AuthorizationPage.xaml")
                               .WithTitle("Авторизация")
                               .WithViewModel(new AuthorizationPageModel(_services))
                               .Build();
            
                    Navigate(args);
                    
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
                case RegistrationStatus.InvalidPhoneNumber: {
                    PhoneError = "Некорректный номер телефона";
                    break;
                }
                
            }
        }
        
        private bool CanRegister(object parameter) {
            return true;
        }
        #endregion
        
        #region BackToAuthCommand

        public RelayCommand BackToAuthCommand {
            get { return _backToAuthCommand; }
        }
        
        private void BackToAuth(object parameter) {
            var args = new NavigationArgsBuilder()
                       .WithURL("View/AuthRegister/AuthorizationPage.xaml")
                       .WithTitle("Авторизация")
                       .WithViewModel(new AuthorizationPageModel(_services))
                       .Build();
            
            Navigate(args);
        }
        
        private bool CanBackToAuth(object parameter) {
            return true;
        }
        
        #endregion
        
        #region RegisterLegalCommand
        
        public RelayCommand RegisterLegalCommand {
            get { return _registerLegalCommand; }
        }
        
        private void RegisterLegal(object parameter) {
            var args = new NavigationArgsBuilder()
                       .WithURL("View/AuthRegister/RegisterLegalPage.xaml")
                       .WithTitle("Регистрация юридического лица")
                       .WithViewModel(new RegisterLegalPageModel(_services))
                       .Build();
            
            Navigate(args);
        }

        private bool CanRegisterLegal(object parameter) {
            return true;
        }
        
        #endregion
        
        public RegisterIndividualPageModel(IServices services): base(services) {
            _registerCommand = new RelayCommand(Register, CanRegister);
            _backToAuthCommand = new RelayCommand(BackToAuth, CanBackToAuth);
            _registerLegalCommand = new RelayCommand(RegisterLegal, CanRegisterLegal);
        }
    }
}