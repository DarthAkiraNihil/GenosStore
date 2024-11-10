using GenosStore.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GenosStore.ViewModel {
	public class AuthorizationViewModel: AbstractViewModel, INotifyPropertyChanged {

		private RelayCommand _authorizeCommand;
		public RelayCommand AuthorizeCommand {
			get { return _authorizeCommand; }
		}

		private void Login(object parameter) {
			MessageBox.Show("PENIS");
			Navigate("View/RegisterPageView.xaml", "", null);
		}

		private bool CanLogin(object parameter) {
			return true;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string propertyName) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public AuthorizationViewModel() {
			_authorizeCommand = new RelayCommand(Login, CanLogin);
		}

	}
}
