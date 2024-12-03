using GenosStore.Utility.AbstractViewModels;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.Navigation;
using GenosStore.ViewModel.AuthRegister;
using GenosStore.ViewModel.Main;
using GenosStore.ViewModel.Order;

namespace GenosStore.ViewModel.AppWindows {
	public class MainWindowModel: RequiresUserViewModel {
		
		#region Commands

		#region ToMainPageCommand

		private readonly RelayCommand _toMainPageCommand;

		public RelayCommand ToMainPageCommand {
			get {
				return _toMainPageCommand;
			}
		}

		private void ToMainPage(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/Main/MainPage.xaml")
			           .WithTitle("Главная страница")
			           .WithViewModel(new MainPageModel(_services, _user))
			           .Build();
			Navigate(args);
		}

		private bool CanToMainPage(object parameter) {
			return true;
		}

		#endregion

		#region ToCataloguePage

		private readonly RelayCommand _toCatalogueCommand;

		public RelayCommand ToCataloguePage {
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

		#endregion

		#region BankCardsCommand

		private readonly RelayCommand _bankCardsCommand;

		public RelayCommand BankCardsCommand {
			get { return _bankCardsCommand; }
		}

		private void BankCards(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/Main/BankCardsPage.xaml")
			           .WithTitle("Банковские карты")
			           .WithViewModel(new BankCardsModel(_services, _user))
			           .Build();
			
			Navigate(args);
		}

		private bool CanToBankCards(object parameter) {
			return true;
		}

		#endregion

		#region ToCartPageCommand

		private readonly RelayCommand _toCartPageCommand;

		public RelayCommand ToCartPageCommand {
			get { return _toCartPageCommand; }
		}

		private void ToCartPage(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/Main/CartPage.xaml")
			           .WithTitle("Корзина")
			           .WithViewModel(new CartPageModel(_services, _user))
			           .Build();
			Navigate(args);
		}

		private bool CanToCartPage(object parameter) {
			return true;
		}

		#endregion

		#region ToOrderHistoryCommand

		private readonly RelayCommand _toOrderHistoryCommand;

		public RelayCommand ToOrderHistoryCommand {
			get { return _toOrderHistoryCommand; }
		}

		private void ToOrderHistory(object parameter) {
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
		
		#endregion
		
		public MainWindowModel(IServices services, User user) : base(services, user) {
			_toMainPageCommand = new RelayCommand(ToMainPage, CanToMainPage);
			_toCatalogueCommand = new RelayCommand(ToCatalogue, CanToCatalogue);
			_bankCardsCommand = new RelayCommand(BankCards, CanToBankCards);
			_toCartPageCommand = new RelayCommand(ToCartPage, CanToCartPage);
			_toOrderHistoryCommand = new RelayCommand(ToOrderHistory, CanToOrderHistory);
		}
	}
}
