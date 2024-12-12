using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.ViewModel.AuthRegister;

namespace GenosStore.View.AuthRegister {
	/// <summary>
	/// Логика взаимодействия для AuthorizationPage.xaml
	/// </summary>
	public partial class AuthorizationPage : Page {
		public AuthorizationPage() {
			InitializeComponent();
			//DataContext = new AuthorizationPageModel();
		}

		private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e) {
			var context = DataContext as INeedsPasswordViewModel;
			if (context != null) {
				context.Password = Password.Password;
			}
		}
	}
}
