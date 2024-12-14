using System;
using System.Collections.Generic;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types.Enum;
using GenosStore.Utility.Types.Filtering;
using GenosStore.ViewModel.ItemPage;

namespace GenosStore.ViewModel.ItemList {
	public class CPUCoolersListModel: ComputerComponentListViewModel<CPUCooler> {
		
		protected override ItemTypeDescriptor _itemType => ItemTypeDescriptor.CPUCooler;
		
		public CheckableCollection<CoolerMaterial> FoundationMaterials { get; set; }
		public CheckableCollection<CoolerMaterial> RadiatorMaterials { get; set; }
		
		public RangeItem MaxFanRPM { get; set; }
		public RangeItem TubesCount { get; set; }
		public RangeItem TubesDiameter { get; set; }
		public RangeItem FanCount { get; set; }
		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/CPUCoolerPage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new CPUCoolerPageModel(_services, _user, id);
		}
		
		

		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<CPUCooler, bool>>();

			if (FoundationMaterials.IsValid()) {
				filters.Add(
					i => FoundationMaterials.CreateFilterClosure(n => n.Contains(i.FoundationMaterial.Name))
				);
			}

			if (RadiatorMaterials.IsValid()) {
				filters.Add(
					i => RadiatorMaterials.CreateFilterClosure(n => n.Contains(i.RadiatorMaterial.Name))
				);
			}

			if (MaxFanRPM.IsValid()) {
				filters.Add(
					i => MaxFanRPM.From <= i.MaxFanRPM && i.MaxFanRPM <= MaxFanRPM.To
				);
			}

			if (TubesCount.IsValid()) {
				filters.Add(
					i => TubesCount.From <= i.TubesCount && i.TubesCount <= TubesCount.To
				);
			}

			if (TubesDiameter.IsValid()) {
				filters.Add(
					i => TubesDiameter.From <= i.TubesDiameter && i.TubesDiameter <= TubesDiameter.To
				);
			}

			if (FanCount.IsValid()) {
				filters.Add(
					i => FanCount.From <= i.FanCount && i.FanCount <= FanCount.To
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
				_services.Entity.Items.ComputerComponents.CPUCoolers.Filter(filters),
				_services.Entity.Items.ComputerComponents.CPUCoolers
			);

		}

		protected override List<CPUCooler> _getItems() {
			return _services.Entity.Items.ComputerComponents.CPUCoolers.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.CPUCoolers
				.Get(id)
				.Name;
		}

		public CPUCoolersListModel(IServices services, User user): base(services, user) {
			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			FoundationMaterials = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.CoolerMaterials.List()
			);
			RadiatorMaterials = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.CoolerMaterials.List()
			);

			MaxFanRPM = new RangeItem();
			TubesCount = new RangeItem();
			TubesDiameter = new RangeItem();
			FanCount = new RangeItem();
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.CPUCoolers.List()
			);
			
			Title = "Кулеры для процессоров";
		}
	}
}
