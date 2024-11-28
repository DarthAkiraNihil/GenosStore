using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Base;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types.Filtering;

namespace GenosStore.Utility.AbstractViewModels {
    public abstract class ItemListViewModel<T>: RequiresUserViewModel where T: Item {
        private readonly RelayCommand _toItemPageCommand;
		private readonly RelayCommand _applyFiltersCommand;

		private ObservableCollection<ItemListElement> _items;

		public class ItemListElement {
			public T Item { get; set; }
			public double? Price { get; set; }
			public double? DiscountedPrice { get; set; }
			public double? OldPrice { get; set; }
			
		}

		public ObservableCollection<ItemListElement> Items {
			get { return _items; }
			set {
				_items = value;
				NotifyPropertyChanged("Items");
			}
		}
		
		public RelayCommand ToItemPageCommand {
			get { return _toItemPageCommand; }
		}
		
		private void ToItemPage(object parameter) {
			int id = (int) parameter;
			
			var args = new NavigationArgsBuilder()
			           .WithURL(_itemPageURL)
			           .WithViewModel(_itemPageViewModel(id))
			           .WithId(id)
			           .Build();
            
			Navigate(args);
		}
		
		protected abstract string _itemPageURL { get; }

		protected abstract AbstractViewModel _itemPageViewModel(int id);
		protected abstract List<T> _getItems();
		
		private bool CanToItemPage(object parameter) {
			return true;
		}

		public RelayCommand ApplyFiltersCommand {
			get { return _applyFiltersCommand; }
		}

		protected abstract void ApplyFilters(object parameter);

		private bool CanApplyFilters(object parameter) {
			return true;
		}

		#region Properties

		public RangeItem Price { get; set; }
		
		private string _searchString;

		public string SearchString {
			get { return _searchString; }
			set {
				_searchString = value;
				NotifyPropertyChanged("SearchString");
			}
		}
		
		#endregion
		
		#region SearchCommand

		private readonly RelayCommand _search;

		public RelayCommand SearchCommand {
			get { return _search; }
		}

		private void Search(object parameter) {
            
		}

		private bool CanSearch(object parameter) {
			return SearchString != "";
		}

		#endregion

		protected ObservableCollection<ItemListElement> GetItemsAndCheckDiscounts(List<T> items, IStandardService<T> service) {
			var converted = new ObservableCollection<ItemListElement>();

			foreach (var item in items) {
				var discount = item.ActiveDiscount;
				var listItem = new ItemListElement();
				listItem.Item = item;
				if (discount != null) {
					var now = DateTime.Now;
					if (discount.EndsAt < now) {
						item.ActiveDiscount = null;
						listItem.Price = item.Price;
						service.Update(item);
					} else {
						listItem.DiscountedPrice = item.Price * discount.Value;
						listItem.OldPrice = item.Price;
					}
				} else {
					listItem.Price = item.Price;
				}
				
				converted.Add(listItem);
			}

			service.Save();

			return converted;
		}

		public ItemListViewModel(IServices services, User user): base(services, user) {
			_toItemPageCommand = new RelayCommand(ToItemPage, CanToItemPage);
			_applyFiltersCommand = new RelayCommand(ApplyFilters, CanApplyFilters);
			_search = new RelayCommand(Search, CanSearch);

			Price = new RangeItem();
			
			

			//var dbAccessor = new GenosStoreRepositoriesPostgreSQL();


			//Vendors = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.Vendors.List());
			//MotherboardFormFactors = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.MotherboardFormFactors.List());
			//CPUSockets = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.CPUSockets.List());
			//CPUCores = Utilities.ConvertToCheckableCollection(dbAccessor.Items.SimpleComputerComponents.CPUCores.List());
			//RAMTypes = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.RAMTypes.List());
			//MotherboardFormFactors = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.MotherboardFormFactors.List());

			//Motherboards = new ObservableCollection<Motherboard>(dbAccessor.Items.ComputerComponents.Motherboards.List());

		}
    }
}