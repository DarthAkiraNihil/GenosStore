using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GenosStore.Utility;
using GenosStore.View.AuthRegister;
using GenosStore.View.ItemList;
using GenosStore.View.Main;
using GenosStore.ViewModel.AuthRegister;
using GenosStore.ViewModel.ItemList;
using GenosStore.ViewModel.Main;

namespace GenosStore.Services {
	public class PageResolverService {

		private static Dictionary<string, Func<AbstractViewModel, Page>> _resolveDict = new Dictionary<string, Func<AbstractViewModel, Page>>() {
			{"View/AuthRegister/AuthorizationPage.xaml",  v => new AuthorizationPage() { DataContext = v } },
			{"View/AuthRegister/RegisterIndividualPage.xaml",  v => new RegisterIndividualPage() { DataContext = v } },
			{"View/AuthRegister/RegisterLegalPage.xaml",  v => new RegisterLegalPage() { DataContext = v } },
			{"View/Main/ItemCataloguePage.xaml",  v => new itemCatalogue() { DataContext = v } },
			{"View/ItemList/MotherboardsPage.xaml",  v => new MotherboardsPage() { DataContext = v } },
		};

		public static Page Resolve(string url, AbstractViewModel viewModel) {
			return _resolveDict[url](viewModel);
		}

	}
}
