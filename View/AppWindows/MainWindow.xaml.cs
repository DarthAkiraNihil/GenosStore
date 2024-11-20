using GalaSoft.MvvmLight.Messaging;
using GenosStore.View.Main;
using System.Windows;
using System.Windows.Input;
using GenosStore.Model.Entity.User;
using GenosStore.Services;
using GenosStore.Services.Interface;
using GenosStore.Utility.Navigation;
using GenosStore.ViewModel.Main;

namespace GenosStore.View.AppWindows
{
    public partial class MainWindow : Window {
        public MainWindow(IServices services, User currentUser)
        {
            InitializeComponent();

			Messenger.Default.Register<NavigationArgs>(this, (x) => {
				MainFrame.Content = PageResolver.Resolve(x);
			});
			//MainFrame.Content = new DBEditPage();
			MainFrame.Content = new MainPage() { DataContext = new MainPageModel(services, currentUser) };
        }

		private void closeButton_Click(object sender, RoutedEventArgs e) {
			Application.Current.Shutdown();
		}

		private void minimizeButton_Click(object sender, RoutedEventArgs e) {
			WindowState = WindowState.Minimized;
		}

		private void maximizeButton_Click(object sender, RoutedEventArgs e) {
			if (this.WindowState == WindowState.Normal)
				this.WindowState = WindowState.Maximized;
			else this.WindowState = WindowState.Normal;
		}

		private void OnMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
			if (e.LeftButton == MouseButtonState.Pressed) {
				DragMove();
			}
		}
	}
}