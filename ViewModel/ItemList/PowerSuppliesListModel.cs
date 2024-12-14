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
	public class PowerSuppliesListModel: ComputerComponentListViewModel<PowerSupply> {
		protected override ItemTypeDescriptor _itemType => ItemTypeDescriptor.PowerSupply;
		
		public CheckableCollection<Certificate80Plus> Certificates80Plus { get; set; }
		public RangeItem SataPorts { get; set; }
		public RangeItem MolexPorts { get; set; }
		public RangeItem PowerOutput { get; set; }
		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/PowerSupplyPage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new PowerSupplyPageModel(_services, _user, id);
		}
		
		

		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<PowerSupply, bool>>();

			if (SataPorts.IsValid()) {
				filters.Add(
					i => SataPorts.From <= i.SataPorts && i.SataPorts <= SataPorts.To
				);
			}

			if (MolexPorts.IsValid()) {
				filters.Add(
					i => MolexPorts.From <= i.MolexPorts && i.MolexPorts <= MolexPorts.To
				);
			}

			if (PowerOutput.IsValid()) {
				filters.Add(
					i => PowerOutput.From <= i.PowerOutput && i.PowerOutput <= PowerOutput.To
				);
			}

			if (Certificates80Plus.IsValid()) {
				filters.Add(
					i => Certificates80Plus.CreateFilterClosure(n => n.Contains(i.Certificate80Plus.Name))
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
				_services.Entity.Items.ComputerComponents.PowerSupplies.Filter(filters),
				_services.Entity.Items.ComputerComponents.PowerSupplies
			);

			// Items = new ObservableCollection<ItemListElement>(
			// 	_services.Entity.Items.ComputerComponents.PowerSupplies.Filter(filters)
			// );
		}

		protected override List<PowerSupply> _getItems() {
			return _services.Entity.Items.ComputerComponents.PowerSupplies.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.PowerSupplies
				.Get(id)
				.Name;
		}

		public PowerSuppliesListModel(IServices services, User user): base(services, user) {
			
			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			
			Certificates80Plus = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Certificates80Plus.List()
			);
			
			SataPorts = new RangeItem();
			MolexPorts = new RangeItem();
			PowerOutput = new RangeItem();
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.PowerSupplies.List()
			);
			
			Title = "Блоки питания";
		}
	}
}
