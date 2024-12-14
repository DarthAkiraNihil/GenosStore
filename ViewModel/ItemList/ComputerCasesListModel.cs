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
	public class ComputerCasesListModel: ComputerComponentListViewModel<ComputerCase> {
		protected override ItemTypeDescriptor _itemType => ItemTypeDescriptor.ComputerCase;
		public CheckableCollection<ComputerCaseTypesize> ComputerCaseTypesizes { get; set; }
		public CheckableCollection<MotherboardFormFactor> SupportedMotherboardFormFactors { get; set; }

		public RangeItem Length { get; set; }
		public RangeItem Width { get; set; }
		public RangeItem Height { get; set; }

		public bool HasARGBLighting {
			get {
				return _hasArgbLighting;
			}
			set {
				_hasArgbLighting = value;
				_argbOnceSelected = true;
				NotifyPropertyChanged("HasARGBLighting");
			}
		}
		public RangeItem DrivesSlotsCount { get; set; }

		private bool _argbOnceSelected;
		private bool _hasArgbLighting;
		
		protected override string _itemPageURL {
			get {
				return "View/ItemPage/ComputerCasePage.xaml";
			}
		}

		protected override AbstractViewModel _itemPageViewModel(int id) {
			return new ComputerCasePageModel(_services, _user, id);
		}
		
		

		protected override void ApplyFilters(object parameter) {
			
			var filters = new List<Func<ComputerCase, bool>>();

			if (Length.IsValid()) {
				filters.Add(
					i => Length.From <= i.Length && i.Length <= Length.To
				);
			}

			if (Width.IsValid()) {
				filters.Add(
					i => Width.From <= i.Width && i.Width <= Width.To
				);
			}

			if (Height.IsValid()) {
				filters.Add(
					i => Height.From <= i.Height && i.Height <= Height.To
				);
			}

			if (DrivesSlotsCount.IsValid()) {
				filters.Add(
					i => DrivesSlotsCount.From <= i.DrivesSlotsCount && i.DrivesSlotsCount <= DrivesSlotsCount.To
				);
			}

			

			if (ComputerCaseTypesizes.IsValid()) {
				filters.Add(
					i => ComputerCaseTypesizes.CreateFilterClosure(n => n.Contains(i.ComputerCaseTypesize.Name))
				);
			}

			if (SupportedMotherboardFormFactors.IsValid()) {
				filters.Add(
					i => SupportedMotherboardFormFactors
						.CreateFilterClosure(
							n => {
								foreach (var type in i.SupportedMotherboardFormFactors) {
									if (type.Name == n) {
										return true;
									}
								}

								return false;
							}
						)
				);
			}

			if (_argbOnceSelected) {
				filters.Add(
					i => i.HasARGBLighting == HasARGBLighting
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
				_services.Entity.Items.ComputerComponents.ComputerCases.Filter(filters),
				_services.Entity.Items.ComputerComponents.ComputerCases
			);

			// Items = new ObservableCollection<ItemListElement>(
			// 	_services.Entity.Items.ComputerComponents.ComputerCases.Filter(filters)
			// );
		}

		protected override List<ComputerCase> _getItems() {
			return _services.Entity.Items.ComputerComponents.ComputerCases.List();
		}

		protected override string _getItemName(int id) {
			return _services
				.Entity
				.Items
				.ComputerComponents
				.ComputerCases
				.Get(id)
				.Name;
		}

		public ComputerCasesListModel(IServices services, User user): base(services, user) {

			_argbOnceSelected = false;
			
			Vendors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.Vendors.List()
			);
			
			ComputerCaseTypesizes = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.ComputerCaseTypesizes.List()
			);
			
			SupportedMotherboardFormFactors = Utilities.ConvertToCheckableCollection(
				_services.Entity.Items.Characteristics.MotherboardFormFactors.List()
			);
			
			Length = new RangeItem();
			Width = new RangeItem();
			Height = new RangeItem();
			DrivesSlotsCount = new RangeItem();
			
			Items = GetItemsAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.ComputerCases.List()
			);

			Title = "Корпуса";

		}
	}
}
