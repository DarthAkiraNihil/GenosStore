using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Utility;

namespace GenosStore.ViewModel.ItemList {
	public class MotherboardsListModel: AbstractViewModel, INotifyPropertyChanged {
		
		private RelayCommand _toItemPageCommand;
		private RelayCommand _applyFiltersCommand;
		
		public ObservableCollection<CheckableItem<MotherboardFormFactor>> MotherboardFormFactors { get; set; }
		public RelayCommand ToItemPageCommand {
			get { return _toItemPageCommand; }
		}

		public RelayCommand ApplyFiltersCommand {
			get { return _applyFiltersCommand; }
		}

		private void ToItemPage(object parameter) {
			Navigate("View/ItemPage/MotherboardPage.xaml", "");
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

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string propertyName) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public MotherboardsListModel() {
			_toItemPageCommand = new RelayCommand(ToItemPage, CanToItemPage);
			_applyFiltersCommand = new RelayCommand(ApplyFilters, CanApplyFilters);
			var context = new GenosStoreDatabaseContext();
			var l = context.MotherboardFormFactors.ToList();
			MotherboardFormFactors = new ObservableCollection<CheckableItem<MotherboardFormFactor>>();
			foreach (var v in l) {
				MotherboardFormFactors.Add(
					new CheckableItem<MotherboardFormFactor>() {Item = v, IsChecked = false}
				);
			}
		}
		
	}
}
