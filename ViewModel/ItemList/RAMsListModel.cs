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
using GenosStore.Utility.Types.Enum;
using GenosStore.Utility.Types.Filtering;
using GenosStore.ViewModel.ItemPage;

namespace GenosStore.ViewModel.ItemList {
	public class RAMsListModel: ComputerComponentListViewModel<RAM> {
		protected override ItemTypeDescriptor _itemType => ItemTypeDescriptor.RAM;
		
		public CheckableCollection<RAMType> RAMTypes { get; set; }

		public RangeItem TotalSize { get; set; }
		public RangeItem ModuleSize { get; set; }
		public RangeItem Frequency { get; set; }

		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/RAMPage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new RAMPageModel(_services, _user, id);
		}
		
		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<RAM, bool>>();

			if (TotalSize.IsValid()) {
				filters.Add(
					i => TotalSize.From <= i.TotalSize && i.TotalSize <= TotalSize.To
				);
			}

			if (ModuleSize.IsValid()) {
				filters.Add(
					i => ModuleSize.From <= i.ModuleSize && i.ModuleSize <= ModuleSize.To
				);
			}

			if (Frequency.IsValid()) {
				filters.Add(
					i => Frequency.From <= i.Frequency && i.Frequency <= Frequency.To
				);
			}

			if (RAMTypes.IsValid()) {
				filters.Add(
					i => RAMTypes.CreateFilterClosure(n => n.Contains(i.RAMType.Name))
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
				_services.Entity.Items.ComputerComponents.RAMs.Filter(filters),
				_services.Entity.Items.ComputerComponents.RAMs
			);

			// Items = new ObservableCollection<ItemListElement>(
			// 	_services.Entity.Items.ComputerComponents.RAMs.Filter(filters)
			// );
		}

		protected override List<RAM> _getItems() {
			return _services.Entity.Items.ComputerComponents.RAMs.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.RAMs
				.Get(id)
				.Name;
		}

		public RAMsListModel(IServices services, User user): base(services, user) {

			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			RAMTypes = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.RAMTypes.List()
			);

			TotalSize = new RangeItem();
			ModuleSize = new RangeItem();
			Frequency = new RangeItem();
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.RAMs.List()
			);
			
			Title = "Оперативная память";
			
		}
	}
}
