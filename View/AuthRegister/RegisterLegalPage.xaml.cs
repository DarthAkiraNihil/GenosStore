using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;


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
	}
}
