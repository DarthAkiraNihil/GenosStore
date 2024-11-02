using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using GenosStore.View.AuthRegister;

using static GenosStore.Utility.AbstractViewModel;

namespace GenosStore.View.AppWindows
{
    public partial class AuthRegisterWindow : Window
    {
        public AuthRegisterWindow()
        {
            InitializeComponent();

			Messenger.Default.Register<NavigateArgs>(this, (x) => {
				MainFrame.Navigate(new Uri(x.Url, UriKind.Relative));
			});

            MainFrame.Content = new AuthorizationPage();
		}
        
        private void closeButton_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }
    }
}