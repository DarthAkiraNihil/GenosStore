﻿using System.Collections.ObjectModel;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types.Filtering;

namespace GenosStore.Utility.AbstractViewModels {
    public abstract class ItemListViewModel<T>: RequiresUserViewModel{
        private readonly RelayCommand _toItemPageCommand;
		private readonly RelayCommand _applyFiltersCommand;

		private ObservableCollection<T> _items;

		public ObservableCollection<T> Items {
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
		
		#endregion

		public ItemListViewModel(IServices services, User user): base(services, user) {
			_toItemPageCommand = new RelayCommand(ToItemPage, CanToItemPage);
			_applyFiltersCommand = new RelayCommand(ApplyFilters, CanApplyFilters);

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