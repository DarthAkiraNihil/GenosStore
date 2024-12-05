using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Base;
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
	public class MousesListModel: ComputerComponentListViewModel<Mouse> {

		public sealed class DPIModeFilter: Named {
			
		}
		
		public CheckableCollection<DPIModeFilter> DPIModes { get; set; }
		
		private bool _hasProgrammableButtons;
		private bool _programmableButtonsOnceSelected;
		public bool HasProgrammableButtons {
			get {
				return _hasProgrammableButtons;
			}
			set {
				_hasProgrammableButtons = value;
				_programmableButtonsOnceSelected = true;
				NotifyPropertyChanged("HasProgrammableButtons");
			}
		}
		
		private bool _isWirelessOnceSelected;
		private bool _isWireless;
		
		public bool IsWireless {
			get {
				return _isWireless;
			}
			set {
				_isWireless = value;
				_isWirelessOnceSelected = true;
				NotifyPropertyChanged("IsWireless");
			}
		}
		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/MousePage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new MousePageModel(_services, _user, id);
		}
		
		

		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<Mouse, bool>>();

			if (DPIModes.IsValid()) {
				filters.Add(
					i => DPIModes
						.CreateFilterClosure(
							n => {
								foreach (var type in i.DPIModes) {
									if (type.DPI.ToString() == n) {
										return true;
									}
								}

								return false;
							}
						)
				);
			}

			if (_isWirelessOnceSelected) {
				filters.Add(
					i => i.IsWireless == IsWireless
				);
			}

			if (_programmableButtonsOnceSelected) {
				filters.Add(
					i => i.HasProgrammableButtons == HasProgrammableButtons
				);
			}

			if (Price.IsValid()) {
				filters.Add(
					i => Price.From <= i.Price && i.Price <= Price.To
				);
			}

			if (TDP.IsValid()) {
				filters.Add(
					i => TDP.From <= i.TDP && i.TDP <= TDP.To
				);
			}

			if (Vendors.IsValid()) {
				filters.Add(
					i => Vendors.CreateFilterClosure(n => n.Contains(i.Vendor.Name))
				);
			}

			Items = Utilities.ConvertAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.Mouses.Filter(filters),
				_services.Entity.Items.ComputerComponents.Mouses
			);

			// Items = new ObservableCollection<ItemListElement>(
			// 	_services.Entity.Items.ComputerComponents.Mouses.Filter(filters)
			// );
		}

		protected override List<Mouse> _getItems() {
			return _services.Entity.Items.ComputerComponents.Mouses.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.Mouses
				.Get(id)
				.Name;
		}

		public MousesListModel(IServices services, User user): base(services, user) {

			_programmableButtonsOnceSelected = false;
			_isWirelessOnceSelected = false;
			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			
			DPIModes = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.DPIModes.List()
				         .Select(i => new DPIModeFilter { Name = i.DPI.ToString() })
				         .ToList()
			);
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.Mouses.List()
			);
			
		}
	}
}
