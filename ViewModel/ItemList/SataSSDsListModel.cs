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
	public class SataSSDsListModel: ComputerComponentListViewModel<SataSSD> {
		protected override ItemTypeDescriptor _itemType => ItemTypeDescriptor.SataSSD;
		
		
		public RangeItem Capacity { get; set; }
		public RangeItem ReadSpeed { get; set; }
		
		public RangeItem WriteSpeed { get; set; }
		public RangeItem TBW { get; set; }
		public RangeItem DWPD { get; set; }
		public RangeItem BitsForCell { get; set; }
		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/SataSSDPage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new SataSSDPageModel(_services, _user, id);
		}
		
		

		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<SataSSD, bool>>();
			
			if (Capacity.IsValid()) {
				filters.Add(
					i => Capacity.From <= i.Capacity && i.Capacity <= Capacity.To
				);
			}

			if (ReadSpeed.IsValid()) {
				filters.Add(
					i => ReadSpeed.From <= i.ReadSpeed && i.ReadSpeed <= ReadSpeed.To
				);
			}

			if (WriteSpeed.IsValid()) {
				filters.Add(
					i => WriteSpeed.From <= i.WriteSpeed && i.WriteSpeed <= WriteSpeed.To
				);
			}

			if (TBW.IsValid()) {
				filters.Add(
					i => TBW.From <= i.TBW && i.TBW <= TBW.To
				);
			}

			if (DWPD.IsValid()) {
				filters.Add(
					i => DWPD.From <= i.DWPD && i.DWPD <= DWPD.To
				);
			}

			if (BitsForCell.IsValid()) {
				filters.Add(
					i => BitsForCell.From <= i.BitsForCell && i.BitsForCell <= BitsForCell.To
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
				_services.Entity.Items.ComputerComponents.SataSSDs.Filter(filters),
				_services.Entity.Items.ComputerComponents.SataSSDs
			);

			// Items = new ObservableCollection<ItemListElement>(
			// 	_services.Entity.Items.ComputerComponents.NVMeSSDs.Filter(filters)
			// );
		}

		protected override List<SataSSD> _getItems() {
			return _services.Entity.Items.ComputerComponents.SataSSDs.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.SataSSDs
				.Get(id)
				.Name;
		}

		public SataSSDsListModel(IServices services, User user): base(services, user) {

			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			
			Capacity = new RangeItem();
			ReadSpeed = new RangeItem();
			WriteSpeed = new RangeItem();
			TBW = new RangeItem();
			DWPD = new RangeItem();
			BitsForCell = new RangeItem();
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.SataSSDs.List()
			);
			
			Title = "Твердотельные накопители Sata";
			
		}
	}
}
