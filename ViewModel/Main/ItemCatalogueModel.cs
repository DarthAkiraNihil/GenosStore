using GenosStore.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.ViewModel.ItemList;

namespace GenosStore.ViewModel.Main {
	public class ItemCatalogueModel: AbstractViewModel, INotifyPropertyChanged {

		private RelayCommand _toMotherboardsCommand;
		public RelayCommand ToMotherboardsCommand {
			get { return _toMotherboardsCommand; }
		}

		private void ToMotherboards(object parameter) {
			Navigate("View/ItemList/MotherboardsPage.xaml", "",
				new MotherboardsListModel());
		}

		private bool CanToMotherboards(object parameter) {
			return true;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string propertyName) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public ItemCatalogueModel() {
			_toMotherboardsCommand = new RelayCommand(ToMotherboards, CanToMotherboards);
		}

	}
}
