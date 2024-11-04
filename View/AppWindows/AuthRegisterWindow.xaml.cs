using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using GenosStore.View.AuthRegister;

using static GenosStore.Utility.AbstractViewModel;
using GenosStore.ViewModel.AuthRegister;
using System.Windows.Controls;
using System.Windows.Input;

namespace GenosStore.View.AppWindows
{
    public partial class AuthRegisterWindow : Window
    {
        public AuthRegisterWindow()
        {
            InitializeComponent();

            AuthorizationPageModel.Close += this.Close;

			Messenger.Default.Register<NavigateArgs>(this, (x) => {
                MessageBox.Show("PASSO");
				MainFrame.Navigate(new Uri(x.URL, UriKind.Relative));

				WindowTitle.Content = x.Title;
					
                ((Page)MainFrame.Content).DataContext.ToString();
			});

            MainFrame.Content = new AuthorizationPage();
            
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