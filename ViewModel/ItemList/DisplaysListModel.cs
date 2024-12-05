using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
	public class DisplaysListModel: ComputerComponentListViewModel<Display> {

		public CheckableCollection<MatrixType> MatrixTypes { get; set; }
		public CheckableCollection<Underlight> Underlights { get; set; }
		public CheckableCollection<VesaSize> VesaSizes { get; set; }

		public RangeItem MaxUpdateFrequency { get; set; }
		public RangeItem ScreenDiagonal { get; set; }

		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/DisplayPage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new DisplayPageModel(_services, _user, id);
		}
		
		

		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<Display, bool>>();

			if (MaxUpdateFrequency.IsValid()) {
				filters.Add(
					i => MaxUpdateFrequency.From <= i.MaxUpdateFrequency && i.MaxUpdateFrequency <= MaxUpdateFrequency.To
				);
			}

			if (ScreenDiagonal.IsValid()) {
				filters.Add(
					i => ScreenDiagonal.From <= i.ScreedDiagonal && i.ScreedDiagonal <= ScreenDiagonal.To
				);
			}

			if (MatrixTypes.IsValid()) {
				filters.Add(
					i => MatrixTypes.CreateFilterClosure(n => n.Contains(i.MatrixType.Name))
				);
			}

			if (Underlights.IsValid()) {
				filters.Add(
					i => Underlights.CreateFilterClosure(n => n.Contains(i.Underlight.Name))
				);
			}

			if (VesaSizes.IsValid()) {
				filters.Add(
					i => VesaSizes.CreateFilterClosure(n => n.Contains(i.VesaSize.Name))
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
				_services.Entity.Items.ComputerComponents.Displays.Filter(filters),
				_services.Entity.Items.ComputerComponents.Displays
			);

			// Items = new ObservableCollection<ItemListElement>(
			// 	_services.Entity.Items.ComputerComponents.Displays.Filter(filters)
			// );
		}

		protected override List<Display> _getItems() {
			return _services.Entity.Items.ComputerComponents.Displays.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.Displays
				.Get(id)
				.Name;
		}

		public DisplaysListModel(IServices services, User user): base(services, user) {
			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			MatrixTypes = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.MatrixTypes.List()
			);
			Underlights = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Underlights.List()
			);
			VesaSizes = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.VesaSizes.List()
			);
			
			MaxUpdateFrequency = new RangeItem();
			ScreenDiagonal = new RangeItem();
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.Displays.List()
			);
			
		}
	}
}
