using System;
using System.Collections.Generic;
using GenosStore.Model.Context;
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
	public class KeyboardsListModel: ComputerComponentListViewModel<Keyboard> {
		
		public CheckableCollection<KeyboardTypesize> KeyboardTypesizes { get; set; }
		public CheckableCollection<KeyboardType> KeyboardTypes { get; set; }
		
		private bool _rgbLightingOnceSelected;
		private bool _hasRGBLighting;
		
		public bool HasRGBLigthing {
			get {
				return _hasRGBLighting;
			}
			set {
				_hasRGBLighting = value;
				_rgbLightingOnceSelected = true;
				NotifyPropertyChanged("HasRGBLigthing");
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
				return "View/ItemPage/KeyboardPage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new KeyboardPageModel(_services, _user, id);
		}
		
		
		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<Keyboard, bool>>();

			if (KeyboardTypesizes.IsValid()) {
				filters.Add(
					i => KeyboardTypesizes.CreateFilterClosure(n => n.Contains(i.Typesize.Name))
				);
			}

			if (KeyboardTypes.IsValid()) {
				filters.Add(
					i => KeyboardTypes.CreateFilterClosure(n => n.Contains(i.KeyboardType.Name))
				);
			}

			if (_rgbLightingOnceSelected) {
				filters.Add(
					i => i.HasRGBLighting == HasRGBLigthing
				);
			}

			if (_isWirelessOnceSelected) {
				filters.Add(
					i => i.IsWireless == IsWireless
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
				_services.Entity.Items.ComputerComponents.Keyboards.Filter(filters),
				_services.Entity.Items.ComputerComponents.Keyboards
			);

			// Items = new ObservableCollection<ItemListElement>(
			// 	_services.Entity.Items.ComputerComponents.Keyboards.Filter(filters)
			// );
		}

		protected override List<Keyboard> _getItems() {
			return _services.Entity.Items.ComputerComponents.Keyboards.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.Keyboards
				.Get(id)
				.Name;
		}

		public KeyboardsListModel(IServices services, User user): base(services, user) {

			_rgbLightingOnceSelected = false;
			_isWirelessOnceSelected = false;
			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			KeyboardTypesizes = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.KeyboardTypesizes.List()
			);
			KeyboardTypes = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.KeyboardTypes.List()
			);
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.Keyboards.List()
			);
			
		}
	}
}
