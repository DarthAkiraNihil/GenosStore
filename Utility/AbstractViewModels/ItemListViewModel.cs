using GenosStore.Services.Interface;
using GenosStore.Utility.Navigation;

namespace GenosStore.Utility.AbstractViewModels {
    public abstract class ItemListViewModel: AbstractViewModel {
        protected readonly RelayCommand _toItemPageCommand;
		protected readonly RelayCommand _applyFiltersCommand;
		
		public RelayCommand ToItemPageCommand {
			get { return _toItemPageCommand; }
		}
		
		private void ToItemPage(object parameter) {
			int id = (int) parameter;
			
			var args = new NavigationArgsBuilder()
			           .WithURL(_itemPageURL)
			           .WithId(id)
			           .Build();
            
			Navigate(args);
		}
		
		protected abstract string _itemPageURL { get; }
		
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

		public ItemListViewModel(IServices services): base(services) {
			_toItemPageCommand = new RelayCommand(ToItemPage, CanToItemPage);
			_applyFiltersCommand = new RelayCommand(ApplyFilters, CanApplyFilters);
			
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