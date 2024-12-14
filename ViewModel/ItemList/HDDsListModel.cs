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
	public class HDDsListModel: ComputerComponentListViewModel<HDD> {
		protected override ItemTypeDescriptor _itemType => ItemTypeDescriptor.HDD;
		
		public RangeItem Capacity { get; set; }
		public RangeItem ReadSpeed { get; set; }
		
		public RangeItem WriteSpeed { get; set; }
		public RangeItem RPM { get; set; }
		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/HDDPage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new HDDPageModel(_services, _user, id);
		}
		
		
		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<HDD, bool>>();

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

			if (RPM.IsValid()) {
				filters.Add(
					i => RPM.From <= i.RPM && i.RPM <= RPM.To
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
				_services.Entity.Items.ComputerComponents.HDDs.Filter(filters),
				_services.Entity.Items.ComputerComponents.HDDs
			);

			// Items = new ObservableCollection<ItemListElement>(
			// 	_services.Entity.Items.ComputerComponents.HDDs.Filter(filters)
			// );
		}

		protected override List<HDD> _getItems() {
			return _services.Entity.Items.ComputerComponents.HDDs.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.HDDs
				.Get(id)
				.Name;
		}

		public HDDsListModel(IServices services, User user): base(services, user) {

			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			
			Capacity = new RangeItem();
			ReadSpeed = new RangeItem();
			WriteSpeed = new RangeItem();
			RPM = new RangeItem();
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.HDDs.List()
			);
			
			Title = "Жёсткие диски";
			
		}
	}
}
