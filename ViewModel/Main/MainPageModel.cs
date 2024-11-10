using GenosStore.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GenosStore.ViewModel.Main {
	public class MainPageModel: AbstractViewModel {

		private RelayCommand _toCatalogueCommand;
		public RelayCommand ToCatalogueCommand {
			get { return _toCatalogueCommand; }
		}

		private void ToCatalogue(object parameter) {
			Navigate("View/Main/ItemCataloguePage.xaml", "",
				new ItemCatalogueModel());
		}

		private bool CanToCatalogue(object parameter) {
			return true;
		}

		public MainPageModel() {
			_toCatalogueCommand = new RelayCommand(ToCatalogue, CanToCatalogue);
		}
	}
}
