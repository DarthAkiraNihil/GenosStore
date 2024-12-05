using System;
using System.Collections.Generic;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types.Filtering;
using GenosStore.ViewModel.ItemPage;

namespace GenosStore.ViewModel.ItemList {
	public class PreparedAssembliesListModel: ItemListViewModel<PreparedAssembly> {
		
		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/PreparedAssemblyPage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new PreparedAssemblyPageModel(_services, _user, id);
		}
		
		
		protected override void ApplyFilters(object parameter) {
			throw new NotImplementedException();
		}

		protected override List<PreparedAssembly> _getItems() {
			return _services.Entity.Items.PreparedAssemblies.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.PreparedAssemblies
				.Get(id)
				.Name;
		}

		public PreparedAssembliesListModel(IServices services, User user): base(services, user) {
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.PreparedAssemblies.List()
			);
			
		}
	}
}
