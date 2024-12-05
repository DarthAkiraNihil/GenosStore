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
	public class MotherboardsListModel: ComputerComponentListViewModel<Motherboard> {
		
		
		public CheckableCollection<MotherboardFormFactor> MotherboardFormFactors { get; set; }
		public CheckableCollection<CPUSocket> CPUSockets { get; set; }
		public CheckableCollection<CPUCore> CPUCores { get; set; }
		public CheckableCollection<RAMType> RAMTypes { get; set; }

		public RangeItem RAMSlotsCount { get; set; }
		public RangeItem PCIESlotsCount { get; set; }

		public bool HasNVMeSupport {
			get {
				return _hasNVMeSupport;
			}
			set {
				_hasNVMeSupport = value;
				_nvmeOnceSelected = true;
				NotifyPropertyChanged("HasNVMeSupport");
			}
		}
		public RangeItem SataPortsCount { get; set; }
		public RangeItem USBPortsCount { get; set; }

		private bool _nvmeOnceSelected;
		private bool _hasNVMeSupport;
		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/MotherboardPage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new MotherboardPageModel(_services, _user, id);
		}
		
		

		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<Motherboard, bool>>();

			if (MotherboardFormFactors.IsValid()) {
				filters.Add(
					i => MotherboardFormFactors.CreateFilterClosure(n => n.Contains(i.FormFactor.Name))
				);
			}

			if (CPUSockets.IsValid()) {
				filters.Add(
					i => CPUSockets.CreateFilterClosure(n => n.Contains(i.CPUSocket.Name))
				);
			}
			if (CPUCores.IsValid()) {
				filters.Add(
					i => CPUCores
						.CreateFilterClosure(
							n => {
								foreach (var core in i.SupportedCPUCores) {
									if (core.Name == n) {
										return true;
									}
								}
								return false;
							})
				);
			}
			if (RAMTypes.IsValid()) {
				filters.Add(
					i => RAMTypes
						.CreateFilterClosure(
							n => {
								foreach (var type in i.SupportedRAMTypes) {
									if (type.Name == n) {
										return true;
									}
								}
								return false;
							})
				);
			}
			
			if (RAMSlotsCount.IsValid()) {
				filters.Add(
					i => RAMSlotsCount.From <= i.RAMSlots && i.RAMSlots <= RAMSlotsCount.To
				);
			}
			if (PCIESlotsCount.IsValid()) {
				filters.Add(
					i => PCIESlotsCount.From <= i.PCIESlotsCount && i.PCIESlotsCount <= PCIESlotsCount.To
				);
			}
			if (_nvmeOnceSelected) {
				filters.Add(
					i => i.HasNVMeSupport == HasNVMeSupport
				);
			}
			if (SataPortsCount.IsValid()) {
				filters.Add(
					i => SataPortsCount.From <= i.SataPortsCount && i.SataPortsCount <= SataPortsCount.To
				);
			}
			if (USBPortsCount.IsValid()) {
				filters.Add(
					i => USBPortsCount.From <= i.USBPortsCount && i.USBPortsCount <= USBPortsCount.To
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
				_services.Entity.Items.ComputerComponents.Motherboards.Filter(filters),
				_services.Entity.Items.ComputerComponents.Motherboards
			);

			// Items = new ObservableCollection<ItemListElement>(
			// 	_services.Entity.Items.ComputerComponents.Motherboards.Filter(filters)
			// );
		}

		protected override List<Motherboard> _getItems() {
			return _services.Entity.Items.ComputerComponents.Motherboards.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.Motherboards
				.Get(id)
				.Name;
		}

		public MotherboardsListModel(IServices services, User user): base(services, user) {

			_nvmeOnceSelected = false;
			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			MotherboardFormFactors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.MotherboardFormFactors.List()
			);
			CPUSockets = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.CPUSockets.List()
			);
			CPUCores = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.SimpleComputerComponents.CPUCores.List()
			);
			RAMTypes = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.RAMTypes.List()
			);
			MotherboardFormFactors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.MotherboardFormFactors.List()
			);
			
			RAMSlotsCount = new RangeItem();
			PCIESlotsCount = new RangeItem();
			SataPortsCount = new RangeItem();
			USBPortsCount = new RangeItem();
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.Motherboards.List()
			);
			
		}
	}
}
