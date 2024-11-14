using GenosStore.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GenosStore.Services.Interface;
using GenosStore.Utility.Navigation;

namespace GenosStore.ViewModel.Main {
	public class MainPageModel: AbstractViewModel {

		private RelayCommand _toCatalogueCommand;
		public RelayCommand ToCatalogueCommand {
			get { return _toCatalogueCommand; }
		}

		private void ToCatalogue(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/Main/ItemCataloguePage.xaml")
			           .WithViewModel(new ItemCatalogueModel(_services))
			           .Build();
			
			Navigate(args);
		}

		private bool CanToCatalogue(object parameter) {
			return true;
		}

		public MainPageModel(IServices services): base(services) {
			_toCatalogueCommand = new RelayCommand(ToCatalogue, CanToCatalogue);
		}
	}
}
