using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GenosStore.Utility.AbstractViewModels;


namespace GenosStore.View.AuthRegister {
	/// <summary>
	/// Логика взаимодействия для RegisterLegalPage.xaml
	/// </summary>
	public partial class RegisterLegalPage : Page {
		public RegisterLegalPage() {
			InitializeComponent();
		}
		
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

		private void PasswordInput_OnPasswordChanged(object sender, RoutedEventArgs e) {
			var context = DataContext as INeedsPasswordViewModel;
			if (context != null) {
				context.Password = PasswordInput.Password;
			}
		}

		private void RepeatPasswordInput_OnPasswordChanged(object sender, RoutedEventArgs e) {
			var context = DataContext as INeedsPasswordConfirmationViewModel;
			if (context != null) {
				context.ConfirmPassword = RepeatPasswordInput.Password;
			}
		}
	}
}
