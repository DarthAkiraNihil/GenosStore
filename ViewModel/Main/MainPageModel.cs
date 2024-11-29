using GenosStore.Model.Entity.User;
using GenosStore.Utility;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;

namespace GenosStore.ViewModel.Main {
	public class MainPageModel: RequiresUserViewModel {
		
		private RelayCommand _toCatalogueCommand;
		public RelayCommand ToCatalogueCommand {
			get { return _toCatalogueCommand; }
		}

		private void ToCatalogue(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/Main/ItemCataloguePage.xaml")
			           .WithTitle("Каталог товаров")
			           .WithViewModel(new ItemCatalogueModel(_services, _user))
			           .Build();
			
			Navigate(args);
		}

		private bool CanToCatalogue(object parameter) {
			return true;
		}

		public MainPageModel(IServices services, User currentUser): base(services, currentUser) {
			_toCatalogueCommand = new RelayCommand(ToCatalogue, CanToCatalogue);
		}
	}
}
