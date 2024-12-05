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
	public class GraphicsCardsListModel: ComputerComponentListViewModel<GraphicsCard> {
		
		public CheckableCollection<GPU> GPUs { get; set; }
		public CheckableCollection<VideoPort> VideoPorts { get; set; }

		public RangeItem VideoRAM { get; set; }
		public RangeItem MaxDisplaysSupported { get; set; }
		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/GraphicsCardPage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new GraphicsCardPageModel(_services, _user, id);
		}
		
		

		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<GraphicsCard, bool>>();

			if (VideoRAM.IsValid()) {
				filters.Add(
					i => VideoRAM.From <= i.VideoRAM && i.VideoRAM <= VideoRAM.To
				);
			}

			if (VideoPorts.IsValid()) {
				filters.Add(
					i => VideoPorts
						.CreateFilterClosure(
							n => {
								foreach (var type in i.VideoPorts) {
									if (type.Name == n) {
										return true;
									}
								}

								return false;
							}
						)
				);
			}

			if (GPUs.IsValid()) {
				filters.Add(
					i => GPUs.CreateFilterClosure(n => n.Contains(i.GPU.Name))
				);
			}

			if (MaxDisplaysSupported.IsValid()) {
				filters.Add(
					i => MaxDisplaysSupported.From <= i.MaxDisplaysSupported && i.MaxDisplaysSupported <= MaxDisplaysSupported.To
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
				_services.Entity.Items.ComputerComponents.GraphicsCards.Filter(filters),
				_services.Entity.Items.ComputerComponents.GraphicsCards
			);

			// Items = new ObservableCollection<ItemListElement>(
			// 	_services.Entity.Items.ComputerComponents.GraphicsCards.Filter(filters)
			// );
		}

		protected override List<GraphicsCard> _getItems() {
			return _services.Entity.Items.ComputerComponents.GraphicsCards.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.GraphicsCards
				.Get(id)
				.Name;
		}

		public GraphicsCardsListModel(IServices services, User user): base(services, user) {
			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			GPUs = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.SimpleComputerComponents.GPUs.List()
			);
			VideoPorts = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.VideoPorts.List()
			);

			VideoRAM = new RangeItem();
			MaxDisplaysSupported = new RangeItem();
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.GraphicsCards.List()
			);
			
		}
	}
}
