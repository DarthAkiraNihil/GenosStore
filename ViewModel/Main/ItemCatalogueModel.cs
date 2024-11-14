using GenosStore.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Services.Interface;
using GenosStore.Utility.Navigation;
using GenosStore.ViewModel.ItemList;

namespace GenosStore.ViewModel.Main {
	public class ItemCatalogueModel: AbstractViewModel, INotifyPropertyChanged {

		private RelayCommand _toMotherboardsCommand;
		public RelayCommand ToMotherboardsCommand {
			get { return _toMotherboardsCommand; }
		}

		private void ToMotherboards(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/ItemList/MotherboardsPage.xaml")
			           .WithViewModel(new MotherboardsListModel(_services))
			           .Build();
			Navigate(args);
		}

		private bool CanToMotherboards(object parameter) {
			return true;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string propertyName) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public ItemCatalogueModel(IServices services): base(services) {
			_toMotherboardsCommand = new RelayCommand(ToMotherboards, CanToMotherboards);
		}

	}
}
