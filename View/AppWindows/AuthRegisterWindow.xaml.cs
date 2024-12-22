using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using GenosStore.View.AuthRegister;
using GenosStore.ViewModel.AuthRegister;
using System.Windows.Input;
using GenosStore.Services;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.Navigation;

namespace GenosStore.View.AppWindows
{
    public partial class AuthRegisterWindow : Window
    {
	    private IServices _services;
        public AuthRegisterWindow(IServices services)
        {
	        _services = services;
	        InitializeComponent();
	        
            AuthorizationPageModel.Close += Close;

			Messenger.Default.Register<NavigationArgs>(this, (x) => {

				MainFrame.Content = _services.Navigation.PageResolver.Resolve(x);
				
				WindowTitle.Content = x.Title;
				
			});

			MainFrame.Content = new AuthorizationPage() { DataContext = new AuthorizationPageModel(services)};
			WindowTitle.Content = "Авторизация";
        }
        
        private void closeButton_Click(object sender, RoutedEventArgs e) {
	        if (Utilities.SpawnQuestionMessageBox("Внимание! Вы покидаете приложение!", "Вы уверены, что хотите выйти из приложения?")) {
		        Application.Current.Shutdown();
	        }
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }

		private void OnMouseDown(object sender, MouseButtonEventArgs e) {
			if (e.LeftButton == MouseButtonState.Pressed) {
				DragMove();
			}
		}
	}
}