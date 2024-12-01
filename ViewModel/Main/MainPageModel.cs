using GenosStore.Model.Entity.User;
using GenosStore.Utility;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;
using GenosStore.ViewModel.Order;

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

		#region ToCartCommand

		private readonly RelayCommand _toCart;

		public RelayCommand ToCartCommand {
			get { return _toCart; }
		}

		private void ToCart(object parameter) {

		}

		private bool CanToCart(object parameter) {
			return true;
		}

		#endregion

		#region ToOrderHistoryPageCommand

		private readonly RelayCommand _toOrderHistory;

		public RelayCommand ToOrderHistoryPageCommand {
			get { return _toOrderHistory; }
		}

		private void ToOrderHistoryPage(object parameter) {
			var args = new NavigationArgsBuilder()
				.WithURL("View/Order/OrderHistoryPage.xaml")
				.WithViewModel(new OrderHistoryPageModel(_services, _user))
				.WithTitle("История заказов")
				.Build();

			Navigate(args);
		}

		private bool CanToOrderHistory(object parameter) {
			return true;
		}

		#endregion

		#region ToBankCardsPageCommand

		private readonly RelayCommand _toBankCardsPage;

		public RelayCommand ToBankCardsPageCommand {
			get { return _toBankCardsPage; }
		}

		private void ToBankCardsPage(object parameter) {

		}

		private bool CanToBankCardsPage(object parameter) {
			return true;
		}

		#endregion

		private bool CanToCatalogue(object parameter) {
			return true;
		}

		public MainPageModel(IServices services, User currentUser): base(services, currentUser) {
			_toCatalogueCommand = new RelayCommand(ToCatalogue, CanToCatalogue);
			_toCart = new RelayCommand(ToCart, CanToCart);
			_toOrderHistory = new RelayCommand(ToOrderHistoryPage, CanToOrderHistory);
			_toBankCardsPage = new RelayCommand(ToBankCardsPage);
		}
	}
}
