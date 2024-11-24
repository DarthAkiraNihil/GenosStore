using System;
using System.Collections.Generic;
using System.Windows.Controls;
using GenosStore.Utility.Navigation;
using GenosStore.View.AuthRegister;
using GenosStore.View.ItemList;
using GenosStore.View.ItemPage;
using GenosStore.View.Main;
using GenosStore.View.Other;

namespace GenosStore.Services {
	public class PageResolver {

		private static readonly Dictionary<string, Func<NavigationArgs, Page>> _resolveDict = new Dictionary<string, Func<NavigationArgs, Page>> {
			{"View/AuthRegister/AuthorizationPage.xaml",  a => new AuthorizationPage { DataContext = a.ViewModel } },
			{"View/AuthRegister/RegisterIndividualPage.xaml",  a => new RegisterIndividualPage { DataContext = a.ViewModel } },
			{"View/AuthRegister/RegisterLegalPage.xaml",  a => new RegisterLegalPage { DataContext = a.ViewModel } },
			{"View/Main/ItemCataloguePage.xaml",  a => new ItemCatalogue { DataContext = a.ViewModel } },
			{"View/ItemList/MotherboardsPage.xaml",  a => new MotherboardsPage { DataContext = a.ViewModel } },
			{"View/ItemPage/MotherboardPage.xaml", a => new MotherboardPage { DataContext = a.ViewModel } },
			{"View/Main/MainPage.xaml", a => new MainPage { DataContext = a.ViewModel } },
			{"View/Main/CartPage.xaml", a => new CartPage { DataContext = a.ViewModel } }
		};

		public static Page Resolve(NavigationArgs args) {
			if (_resolveDict.ContainsKey(args.URL)) {
				return _resolveDict[args.URL](args);
			}

			return new PageNotFound();
		}

	}
}
