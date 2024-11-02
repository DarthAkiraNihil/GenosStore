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
using GenosStore.ViewModel.AuthRegister;

namespace GenosStore.View.AuthRegister {
	/// <summary>
	/// Логика взаимодействия для RegisterIndividualPage.xaml
	/// </summary>
	public partial class RegisterIndividualPage : Page {
		public RegisterIndividualPage() {
			InitializeComponent();
			MessageBox.Show("EGGOG");
			DataContext = new RegisterIndividualPageModel();
		}
	}
}
