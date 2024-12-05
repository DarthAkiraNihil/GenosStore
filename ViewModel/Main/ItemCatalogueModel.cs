using GenosStore.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Navigation;
using GenosStore.ViewModel.ItemList;
using GenosStore.ViewModel.ItemPage;

namespace GenosStore.ViewModel.Main {
	public class ItemCatalogueModel: RequiresUserViewModel {

		private class ToItemListCommandParameters {
			public AbstractViewModel ViewModel { get; set; }
			public string Title { get; set; }
			public string URL { get; set; }
		}

		private readonly Dictionary<string, Func<IServices, User, ToItemListCommandParameters>> _toItemListCommandsParameters  = new Dictionary<string, Func<IServices, User, ToItemListCommandParameters>> {
			{"Motherboards", (s, u) => new ToItemListCommandParameters {
				ViewModel = new MotherboardsListModel(s, u),
				Title = "Материнские платы",
				URL = "View/ItemList/MotherboardsPage.xaml"
			}}
		};

		#region ToItemListCommand

		private readonly RelayCommand _toItemListCommand;

		public RelayCommand ToItemListCommand {
			get { return _toItemListCommand; }
		}

		private void ToItemList(object parameter) {
			
			string type = parameter as string;

			if (type == null) {
				return;
			}
			
			var itemListParameters = _toItemListCommandsParameters[type](_services, _user);
			
			var args = new NavigationArgsBuilder()
			           .WithURL(itemListParameters.URL)
			           .WithTitle(itemListParameters.Title)
			           .WithViewModel(itemListParameters.ViewModel)
			           .Build();
			Navigate(args);
		}

		private bool CanToItemList(object parameter) {
			return true;
		}

		#endregion
		private RelayCommand _toMotherboardsCommand;
		public RelayCommand ToMotherboardsCommand {
			get { return _toMotherboardsCommand; }
		}

		private void ToMotherboards(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/ItemList/MotherboardsPage.xaml")
			           .WithTitle("Материнские платы")
			           .WithViewModel(new MotherboardsListModel(_services, _user))
			           .Build();
			Navigate(args);
		}

		private bool CanToMotherboards(object parameter) {
			return true;
		}
		
		
		
		public ItemCatalogueModel(IServices services, User user): base(services, user) {
			_toItemListCommand = new RelayCommand(ToItemList, CanToItemList);
			_toMotherboardsCommand = new RelayCommand(ToMotherboards, CanToMotherboards);
		}

	}
}
