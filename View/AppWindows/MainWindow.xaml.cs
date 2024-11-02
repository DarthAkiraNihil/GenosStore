using System.Windows;

namespace GenosStore.View.AppWindows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

		private void closeButton_Click(object sender, RoutedEventArgs e) {
			Application.Current.Shutdown();
		}

		private void minimizeButton_Click(object sender, RoutedEventArgs e) {
			WindowState = WindowState.Minimized;
		}
	}
}