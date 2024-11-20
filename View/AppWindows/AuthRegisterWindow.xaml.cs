using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using GenosStore.View.AuthRegister;
using GenosStore.ViewModel.AuthRegister;
using System.Windows.Input;
using GenosStore.Services;
using GenosStore.Services.Interface;
using GenosStore.Utility.Navigation;

namespace GenosStore.View.AppWindows
{
    public partial class AuthRegisterWindow : Window
    {
	    //private IServices _services;
	    
        public AuthRegisterWindow(IServices services)
        {
	        InitializeComponent();
	        
	        //_services = services;

            AuthorizationPageModel.Close += Close;

			Messenger.Default.Register<NavigationArgs>(this, (x) => {

				MainFrame.Content = PageResolver.Resolve(x);
				
				WindowTitle.Content = x.Title;
				
			});

			MainFrame.Content = new AuthorizationPage() { DataContext = new AuthorizationPageModel(services)};

        }
        
        private void closeButton_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }

		private void OnMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
			if (e.LeftButton == MouseButtonState.Pressed) {
				DragMove();
			}
		}
	}
}