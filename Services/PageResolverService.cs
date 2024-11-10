using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GenosStore.Utility;
using GenosStore.View.AuthRegister;
using GenosStore.ViewModel.AuthRegister;

namespace GenosStore.Services {
	public class PageResolverService {

		private static Dictionary<string, Func<AbstractViewModel, Page>> _resolveDict = new Dictionary<string, Func<AbstractViewModel, Page>>() {
			{"View/AuthRegister/AuthorizationPage.xaml",  v => new AuthorizationPage() { DataContext = v } },
			{"View/AuthRegister/RegisterIndividualPage.xaml",  v => new RegisterIndividualPage() { DataContext = v } },
			{"View/AuthRegister/RegisterLegalPage.xaml",  v => new RegisterLegalPage() { DataContext = v } },
		};

		public static Page Resolve(string url, AbstractViewModel viewModel) {
			return _resolveDict[url](viewModel);
		}

	}
}
