using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types.Enum;
using GenosStore.View.AppWindows;
using GenosStore.ViewModel.AuthRegister;
using GenosStore.ViewModel.Main;
using GenosStore.ViewModel.Order;

namespace GenosStore.ViewModel.AppWindows {
	public class MainWindowModel: RequiresUserViewModel {
		
		public static Action CloseMain;
		
		#region Commands

		#region ToMainPageCommand

		private readonly RelayCommand _toMainPageCommand;

		public RelayCommand ToMainPageCommand {
			get {
				return _toMainPageCommand;
			}
		}

		private void ToMainPage(object parameter) {
			Navigate(
				_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.Main, _services, _user)
			);
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
			Navigate(
				_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.ItemCatalogue, _services, _user)
			);
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
			Navigate(
				_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.BankCards, _services, _user)
			);
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
			Navigate(
				_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.Cart, _services, _user)
			);
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
			Navigate(
				_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.OrderHistory, _services, _user)
			);
		}

		private bool CanToOrderHistory(object parameter) {
			return true;
		}

		#endregion

		#region LogoutCommand

		private readonly RelayCommand _logout;

		public RelayCommand LogoutCommand {
			get { return _logout; }
		}

		private void Logout(object parameter) {
			bool answer = Utilities.SpawnQuestionMessageBox("Выход", "Вы уверены, что хотите выйти?");
			if (answer) {
				var mainView = new AuthRegisterWindow(_services);
				mainView.Show();
				CloseMain?.Invoke();
			}
		}

		private bool CanLogout(object parameter) {
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
			_logout = new RelayCommand(Logout, CanLogout);
			
		}
	}
}
