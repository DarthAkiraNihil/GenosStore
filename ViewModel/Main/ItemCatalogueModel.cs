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

namespace GenosStore.ViewModel.Main {
	public class ItemCatalogueModel: RequiresUserViewModel {

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
			_toMotherboardsCommand = new RelayCommand(ToMotherboards, CanToMotherboards);
		}

	}
}
