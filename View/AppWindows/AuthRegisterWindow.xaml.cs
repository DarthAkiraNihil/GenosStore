using GalaSoft.MvvmLight.Messaging;
using System;
using System.Reflection;
using System.Windows;
using GenosStore.View.AuthRegister;

using static GenosStore.Utility.AbstractViewModel;
using GenosStore.ViewModel.AuthRegister;
using System.Windows.Controls;
using System.Windows.Input;
using GenosStore.Services;
using GenosStore.Services.Interface;

namespace GenosStore.View.AppWindows
{
    public partial class AuthRegisterWindow : Window
    {
        public AuthRegisterWindow(IServices services)
        {
	        InitializeComponent();
	        
	        MessageBox.Show(services.ToString());

            AuthorizationPageModel.Close += this.Close;

			Messenger.Default.Register<NavigateArgs>(this, (x) => {

				MainFrame.Content = PageResolver.Resolve(x.URL, x.ViewModel);

				//MainFrame.Navigate(new Uri(x.URL, UriKind.Relative));

				//((Page)MainFrame.Content).DataContext = x.ViewModel;
				//MessageBox.Show(((Page)MainFrame.Content).DataContext.ToString());

				WindowTitle.Content = x.Title;
				
			});

			MainFrame.Content = new AuthorizationPage() { DataContext = new AuthorizationPageModel()};

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