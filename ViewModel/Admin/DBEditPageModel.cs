using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.ViewModel.ItemList;

namespace GenosStore.ViewModel.Admin {
	internal class DBEditPageModel: AbstractViewModel {
		private readonly RelayCommand _toItemPageCommand;
		private readonly RelayCommand _applyFiltersCommand;

		public ObservableCollection<Vendor> Vendors { get; set; }
		public ObservableCollection<CheckableItem<MotherboardFormFactor>> MotherboardFormFactors { get; set; }
		public ObservableCollection<CheckableItem<CPUSocket>> CPUSockets { get; set; }
		public ObservableCollection<CheckableItem<CPUCore>> CPUCores { get; set; }
		public ObservableCollection<CheckableItem<RAMType>> RAMTypes { get; set; }

		public ObservableCollection<Motherboard> Motherboards { get; set; }

		public RelayCommand ToItemPageCommand {
			get { return _toItemPageCommand; }
		}

		public RelayCommand ApplyFiltersCommand {
			get { return _applyFiltersCommand; }
		}

		private void ToItemPage(object parameter) {
			Navigate("View/ItemPage/MotherboardPage.xaml", "", new MotherboardsListModel());
		}

		private bool CanToItemPage(object parameter) {
			return true;
		}

		private void ApplyFilters(object parameter) {
			MessageBox.Show("A");
		}

		private bool CanApplyFilters(object parameter) {
			return true;
		}
		
		public DBEditPageModel() {
			_toItemPageCommand = new RelayCommand(ToItemPage, CanToItemPage);
			_applyFiltersCommand = new RelayCommand(ApplyFilters, CanApplyFilters);

			var context = new GenosStoreDatabaseContext();

			var m = new Motherboard();



			Vendors = new ObservableCollection<Vendor>(context.Vendors.ToList());
			MotherboardFormFactors = Utilities.ConvertToCheckableCollection(context.MotherboardFormFactors.ToList());
			CPUSockets = Utilities.ConvertToCheckableCollection(context.CPUSockets.ToList());
			CPUCores = Utilities.ConvertToCheckableCollection(context.CPUCores.ToList());
			RAMTypes = Utilities.ConvertToCheckableCollection(context.RAMTypes.ToList());
			MotherboardFormFactors = Utilities.ConvertToCheckableCollection(context.MotherboardFormFactors.ToList());


		}
	}
}
