using System;
using System.Collections.Generic;
using System.Security.Policy;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types.Enum;
using GenosStore.Utility.Types.Filtering;
using GenosStore.ViewModel.ItemPage;

namespace GenosStore.ViewModel.ItemList {
	public class CPUsListModel: ComputerComponentListViewModel<CPU> {
		
		protected override ItemTypeDescriptor _itemType => ItemTypeDescriptor.CPU;
		
		public CheckableCollection<CPUSocket> CPUSockets { get; set; }
		public CheckableCollection<RAMType> SupportedRamTypes { get; set; }
		

		public bool HasIntegratedGraphics {
			get {
				return _hasIntegratedGraphics;
			}
			set {
				_hasIntegratedGraphics = value;
				_integratedGraphicsOnceSelected = true;
				NotifyPropertyChanged("HasNVMeSupport");
			}
		}
		public RangeItem CoresCount { get; set; }
		public RangeItem ThreadsCount { get; set; }
		public RangeItem TechnicalProcess { get; set; }
		public RangeItem BaseFrequency { get; set; }
		public RangeItem SupportedRAMSize { get; set; }

		private bool _integratedGraphicsOnceSelected;
		private bool _hasIntegratedGraphics;
		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/CPUPage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new CPUPageModel(_services, _user, id);
		}
		
		

		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<CPU, bool>>();

			if (CPUSockets.IsValid()) {
				filters.Add(
					i => CPUSockets.CreateFilterClosure(n => n.Contains(i.CPUSocket.Name))
				);
			}

			if (SupportedRamTypes.IsValid()) {
				filters.Add(
					i => SupportedRamTypes
						.CreateFilterClosure(
							n => {
								foreach (var type in i.SupportedRamType) {
									if (type.Name == n) {
										return true;
									}
								}

								return false;
							}
						)
				);	
			}

			if (_integratedGraphicsOnceSelected) {
				filters.Add(
					i => i.HasIntegratedGraphics == HasIntegratedGraphics
				);
			}

			if (CoresCount.IsValid()) {
				filters.Add(
					i => CoresCount.From <= i.CoresCount && i.CoresCount <= CoresCount.To
				);
			}

			if (TechnicalProcess.IsValid()) {
				filters.Add(
					i => TechnicalProcess.From <= i.TechnicalProcess && i.TechnicalProcess <= TechnicalProcess.To
				);
			}

			if (BaseFrequency.IsValid()) {
				filters.Add(
					i => BaseFrequency.From <= i.BaseFrequency && i.BaseFrequency <= BaseFrequency.To
				);
			}

			if (SupportedRAMSize.IsValid()) {
				filters.Add(
					i => SupportedRAMSize.From <= i.SupportedRAMSize && i.SupportedRAMSize <= SupportedRAMSize.To
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
				_services.Entity.Items.ComputerComponents.CPUs.Filter(filters),
				_services.Entity.Items.ComputerComponents.CPUs
			);

			// Items = new ObservableCollection<ItemListElement>(
			// 	_services.Entity.Items.ComputerComponents.CPUs.Filter(filters)
			// );
		}

		protected override List<CPU> _getItems() {
			return _services.Entity.Items.ComputerComponents.CPUs.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.CPUs
				.Get(id)
				.Name;
		}

		public CPUsListModel(IServices services, User user): base(services, user) {

			_integratedGraphicsOnceSelected = false;
			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			CPUSockets = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.CPUSockets.List()
			);
			SupportedRamTypes = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.RAMTypes.List()
			);

			CoresCount = new RangeItem();
			ThreadsCount = new RangeItem();
			TechnicalProcess = new RangeItem();
			BaseFrequency = new RangeItem();
			SupportedRAMSize = new RangeItem();
	
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.CPUs.List()
			);
			
			Title = "Центральные процессоры";
		}
	}
}
