using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types;
using GenosStore.Utility.Types.Enum;
using GenosStore.Utility.Types.Filtering;

namespace GenosStore.Utility.AbstractViewModels {
    public abstract class ItemListViewModel<T>: RequiresUserViewModel where T: Item {
        private readonly RelayCommand _toItemPageCommand;
		private readonly RelayCommand _applyFiltersCommand;

		private ObservableCollection<ItemListElement<T>> _items;
		
		public ObservableCollection<ItemListElement<T>> Items {
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
			
			Navigate(_services.Navigation.NavigationArgsFactory.GetNavigationArgs(PageTypeDescriptor.ItemPage, _services, _user, _itemType, id));
		}
		
		protected abstract ItemTypeDescriptor _itemType { get; }
		protected abstract string _itemPageURL { get; }

		protected abstract AbstractViewModel _itemPageViewModel(int id);
		protected abstract List<T> _getItems();
		
		protected abstract string _getItemName(int id);
		
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
			if (SearchString != null || SearchString != "") {
				Items = GetItemsAndCheckDiscounts(
					_getItems().Where(i => i.Name.ToLower().Contains(SearchString.ToLower())).ToList()
				);
			}
		}

		private bool CanSearch(object parameter) {
			return SearchString != "";
		}

		#endregion
		
		protected ObservableCollection<ItemListElement<T>> GetItemsAndCheckDiscounts(List<T> items) {
			var converted = new ObservableCollection<ItemListElement<T>>();

			foreach (var item in items) {
				var discount = item.ActiveDiscount;
				var listItem = new ItemListElement<T>();
				listItem.Item = item;
				if (discount != null) {
					if (!_services.Entity.Orders.ActiveDiscounts.IsActive(discount)) {
						_services.Entity.Orders.ActiveDiscounts.Deactivate(discount);
						discount = null;
					}
				}

				if (discount != null) {
					listItem.DiscountedPrice = item.Price * discount.Value;
					listItem.OldPrice = item.Price;
					listItem.DiscountLabel = $"-{(1 - discount.Value) * 100}% (до {discount.EndsAt.ToString("dd/MM/yyyy")})";
				} else {
					listItem.Price = item.Price;
				}
				
				converted.Add(listItem);
			}
			
			return converted;
		}

		#region ResetFiltersCommand

		private readonly RelayCommand _resetFilters;

		public RelayCommand ResetFiltersCommand {
			get { return _resetFilters; }
		}

		private void ResetFilters(object parameter) {
			Items = GetItemsAndCheckDiscounts(_getItems());
		}

		private bool CanResetFilters(object parameter) {
			return true;
		}

		#endregion
		
		public ItemListViewModel(IServices services, User user): base(services, user) {
			_toItemPageCommand = new RelayCommand(ToItemPage, CanToItemPage);
			_applyFiltersCommand = new RelayCommand(ApplyFilters, CanApplyFilters);
			_resetFilters = new RelayCommand(ResetFilters, CanResetFilters);
			_search = new RelayCommand(Search, CanSearch);

			Price = new RangeItem();
			
		}
    }
}