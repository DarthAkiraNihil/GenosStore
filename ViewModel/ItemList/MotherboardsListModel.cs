using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Utility;

namespace GenosStore.ViewModel.ItemList {
	public class MotherboardsListModel: AbstractViewModel, INotifyPropertyChanged {
		
		private RelayCommand _toItemPageCommand;
		public RelayCommand ToItemPageCommand {
			get { return _toItemPageCommand; }
		}

		private void ToItemPage(object parameter) {
			Navigate("View/ItemPage/MotherboardPage.xaml", "");
		}

		private bool CanToItemPage(object parameter) {
			return true;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string propertyName) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public MotherboardsListModel() {
			_toItemPageCommand = new RelayCommand(ToItemPage, CanToItemPage);
		}
		
	}
}
