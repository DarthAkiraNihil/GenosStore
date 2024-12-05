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
			}},
			{"CPUs", (s, u) => new ToItemListCommandParameters {
				ViewModel = new CPUsListModel(s, u),
				Title = "Процессоры",
				URL = "View/ItemList/CPUsPage.xaml"
			}},
			{"RAMs", (s, u) => new ToItemListCommandParameters {
				ViewModel = new RAMsListModel(s, u),
				Title = "Оперативная память",
				URL = "View/ItemList/RAMsPage.xaml"
			}},
			{"GraphicsCards", (s, u) => new ToItemListCommandParameters {
				ViewModel = new GraphicsCardsListModel(s, u),
				Title = "Видеокарты",
				URL = "View/ItemList/GraphicsCardsPage.xaml"
			}},
			{"HDDs", (s, u) => new ToItemListCommandParameters {
				ViewModel = new HDDsListModel(s, u),
				Title = "Жёсткие диски",
				URL = "View/ItemList/HDDsPage.xaml"
			}},
			{"NVMeSSDs", (s, u) => new ToItemListCommandParameters {
				ViewModel = new NVMeSSDsListModel(s, u),
				Title = "Твердотельные накопители NVMe",
				URL = "View/ItemList/NVMeSSDsPage.xaml"
			}},
			{"SataSSDs", (s, u) => new ToItemListCommandParameters {
				ViewModel = new SataSSDsListModel(s, u),
				Title = "Твердотельные накопители Sata",
				URL = "View/ItemList/SataSSDsPage.xaml"
			}},
			{"CPUCoolers", (s, u) => new ToItemListCommandParameters {
				ViewModel = new CPUCoolersListModel(s, u),
				Title = "Кулеры для процессора",
				URL = "View/ItemList/CPUCoolersPage.xaml"
			}},
			{"PowerSupplies", (s, u) => new ToItemListCommandParameters {
				ViewModel = new PowerSuppliesListModel(s, u),
				Title = "Блоки питания",
				URL = "View/ItemList/PowerSuppliesPage.xaml"
			}},
			{"ComputerCases", (s, u) => new ToItemListCommandParameters {
				ViewModel = new ComputerCasesListModel(s, u),
				Title = "Корпуса",
				URL = "View/ItemList/ComputerCasesPage.xaml"
			}},
			{"Displays", (s, u) => new ToItemListCommandParameters {
				ViewModel = new DisplaysListModel(s, u),
				Title = "Мониторы",
				URL = "View/ItemList/DisplaysPage.xaml"
			}},
			{"Keyboards", (s, u) => new ToItemListCommandParameters {
				ViewModel = new KeyboardsListModel(s, u),
				Title = "Клавиатуры",
				URL = "View/ItemList/KeyboardsPage.xaml"
			}},
			{"Mouses", (s, u) => new ToItemListCommandParameters {
				ViewModel = new MousesListModel(s, u),
				Title = "Мыши",
				URL = "View/ItemList/MousesPage.xaml"
			}},
			{"PreparedAssemblies", (s, u) => new ToItemListCommandParameters {
				ViewModel = new PreparedAssembliesListModel(s, u),
				Title = "Готовые сборки",
				URL = "View/ItemList/PreparedAssembliesPage.xaml"
			}},
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
