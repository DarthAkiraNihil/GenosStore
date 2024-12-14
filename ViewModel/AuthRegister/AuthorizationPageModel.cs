using System.ComponentModel;
using GenosStore.Model.Entity.User;
using System.Windows.Media.Animation;
using GenosStore.View.AppWindows;
using GenosStore.Utility;
using System;
using System.Windows;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Common;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types.AuthRegister;
using GenosStore.Utility.Types.Enum;
using GenosStore.ViewModel.AppWindows;

namespace GenosStore.ViewModel.AuthRegister
{
    public class AuthorizationPageModel: AbstractViewModel, INeedsPasswordViewModel {
        
        private readonly RelayCommand _authorizeCommand;
        private readonly RelayCommand _registerCommand;
        
        private string _errorLogin;
        private string _errorPassword;

        private string _login;
        private string _password;

		public static Action Close;
        
        #region Properties

        public String AuthImage => "";

        public string ErrorLogin {
            get { return _errorLogin; }
            set {
                _errorLogin = value;
                NotifyPropertyChanged("ErrorLogin");
            }
        }

        public string ErrorPassword {
            get { return _errorPassword; }
            set {
                _errorPassword = value;
                NotifyPropertyChanged("ErrorPassword");
            }
        }

        public string Login {
            get { return _login; }
            set {
                _login = value;
                NotifyPropertyChanged("Login");
            }
        }

        public string Password {
            get { return _password; }
            set {
                _password = value;
                NotifyPropertyChanged("Password");
            }
        }
        
        #endregion

        #region AuthorizeCommand
		public RelayCommand AuthorizeCommand {
            get { return _authorizeCommand; }
        }
        
        private void Authorize(object parameter) {
            
            var authInfo = _services.Common.Authorization.Authorize(Login, Password);
            var status = authInfo.Item1;
            switch (status) {
                case AuthorizationStatus.Success: {
                    if (authInfo.Item2 is Administrator) {
                        MessageBox.Show("ACCESS GRANTED");
                        var adminMainView = new AdminMainWindow(_services, authInfo.Item2) {
                            DataContext = new AdminMainWindowModel(_services, authInfo.Item2)
                        };
                        adminMainView.Show();
                        Close?.Invoke();
                        break;
                    }
                    var mainView = new MainWindow(_services, authInfo.Item2) { DataContext = new MainWindowModel(_services, authInfo.Item2) };
                    mainView.Show();
                    Close?.Invoke();
                    break;
                }
                case AuthorizationStatus.IncorrectPassword: {
                    ErrorPassword = "Неверный пароль";
                    break;
                }
                case AuthorizationStatus.DoesNotExist: {
                    ErrorLogin = "Такого пользователя не существует";
                    break;
                }
                case AuthorizationStatus.LegalEntityNotVerified: {
                    ErrorLogin = "Юр. лицо не подтверждено";
                    break;
                }
            }
        }
        
        private bool CanAuthorize(object parameter) {
            return true;
        }
        
        #endregion
        #region RegisterCommand
        public RelayCommand RegisterCommand
        {
            get { return _registerCommand; }
		}

        private void Register(object parameter) {
            // var args = new NavigationArgsBuilder()
            //     .WithURL("View/AuthRegister/RegisterIndividualPage.xaml")
            //     .WithTitle("Регистрация физического лица")
            //     .WithViewModel(new RegisterIndividualPageModel(_services))
            //     .Build();
            
            Navigate(_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.RegisterIndividual, _services));
        }
        
        private bool CanRegister(object parameter) {
            return true;
        }
        
        #endregion
        
        public AuthorizationPageModel(IServices services): base(services) {
            _authorizeCommand = new RelayCommand(Authorize, CanAuthorize);
            _registerCommand = new RelayCommand(Register, CanRegister);

            Title = "Авторизация";
        }

    }
}