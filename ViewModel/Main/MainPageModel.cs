using System.Windows;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Implementation.Navigation;
using GenosStore.Utility;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types.Enum;
using GenosStore.ViewModel.Order;

namespace GenosStore.ViewModel.Main {
	public class MainPageModel: RequiresUserViewModel {

		public string WelcomeMessage { get; set; }
		private RelayCommand _toCatalogueCommand;
		public RelayCommand ToCatalogueCommand {
			get { return _toCatalogueCommand; }
		}

		private void ToCatalogue(object parameter) {
			Navigate(_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.ItemCatalogue, _services, _user));
		}

		#region ToCartCommand

		private readonly RelayCommand _toCart;

		public RelayCommand ToCartCommand {
			get { return _toCart; }
		}

		private void ToCart(object parameter) {
			Navigate(
				_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.Cart, _services, _user)
			);
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
			Navigate(_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.OrderHistory, _services, _user));
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
			Navigate(_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.BankCards, _services, _user));
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
			_toBankCardsPage = new RelayCommand(ToBankCardsPage, CanToBankCardsPage);

			string userIdentifier;
			if (_user is IndividualEntity) {
				var individualEntity = _user as IndividualEntity;
				userIdentifier = $"{individualEntity.Name} {individualEntity.Surname}";
			} else {
				userIdentifier = _user.Email;
			}
			WelcomeMessage = $"Добро пожаловать, {userIdentifier}";
			Title = "Главная страница";
			
		}
	}
}
