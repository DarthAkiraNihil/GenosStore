using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Implementation.PostgreSQL;
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
					i => MotherboardFormFactors.CreateFilterClosure(n => n.Contains(i.FormFactor.Name))
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

		public MotherboardsListModel(IServices services, User user): base(services, user) {

			_nvmeOnceSelected = false;
			
			var context = new GenosStoreDatabaseContext();

			// var ac = new AudioChipset();
			// ac.Model = "Realtek ALC897";
			// ac.Name = "Realtek ALC897";
			// ac.Type = context.SimpleComputerComponentTypes.Where(i => i.Name == "AudioChipset").FirstOrDefault();
			// // context.MotherboardChipsets.Add(ac);
			// var na = new NetworkAdapter();
			// na.Model = "Realtek RTL8111H";
			// na.Name = "Realtek RTL8111H";
			// na.Type = context.SimpleComputerComponentTypes.Where(i => i.Name == "NetworkAdapter").FirstOrDefault();

			//context.AudioChipsets.Add(ac);
			//context.NetworkAdapters.Add(na);

			//context.SaveChanges();

			MessageBox.Show("SIMPLEDIMPLE");

			//var m = new Motherboard();

			//m.Name = "Материнская плата MSI PRO H610M-E DDR4";
			//m.Description =
			//	"Материнская плата MSI PRO H610M-E DDR4 – надежная основа для построения офисного или домашнего ПК с универсальной производительностью. Данная плата основана на чипсете Intel H610 с процессорным разъемом LGA 1700 и обладает компактными размерами благодаря форм-фактору Micro-ATX. Для подключения необходимых комплектующих реализованы востребованные средства, среди которых отмечаются 2 слота под модули оперативной памяти объемом до 64 ГБ, по одному слоту расширения PCI-E x16 и PCI-E x1, 4 разъема SATA и 1 разъем M.2.\r\nMSI PRO H610M-E оборудована сетевым адаптером 1 Гбит/с и 7.1-канальным звуковым кодеком. На панели ввода/вывода расположены порты и разъемы, включая USB и HDMI. Плата разработана с применением надежных компонентов и технологий, что служит гарантией стабильной и долговечной работы.";
			//m.Model = "MSI PRO H610M-E DDR4";
			//m.Price = 7500f;

			//var mb = context.ItemTypes.Where(i => i.Name == "Motherboard").First();

			//m.ItemType = mb;
			//m.TDP = 0f;

			//var ff = context.MotherboardFormFactors.Where(i=>i.Name== "micro-ATX").First();
			//m.FormFactor = ff;
			//var sock = context.CPUSockets.Where(i => i.Name == "LGA1700").First();

			//m.CPUSocket = sock;

			//var al = context.CPUCores.Where(c => c.Name == "Alder Lake").First();
			//var rl = context.CPUCores.Where(c => c.Name == "Raptor Lake").First();
			//var rlr = context.CPUCores.Where(c => c.Name == "Raptor Lake Refresh").First();

			//var v = context.Vendors.Where(i => i.Name == "MSI").FirstOrDefault(); ;


			//m.Vendor = v;
			//m.SupportedCPUCores = new List<CPUCore>() { al, rl, rlr };

			//var ddr4 = context.RAMTypes.Where(i => i.Name == "DDR4").First();

			//m.SupportedRAMTypes = new List<RAMType>() { ddr4 };

			//m.RAMSlots = 2;
			//m.RAMChannels = 2;
			//m.MaxRAMFrequency = 3200;
			//m.PCIESlotsCount = 1;

			//var pc = context.PCIEVersions.Where(i => i.Name == "4.0").First();

			//m.PCIEVersion = pc;

			//m.HasNVMeSupport = true;

			//m.M2SlotsCount = 1;
			//m.SataPortsCount = 4;
			//m.USBPortsCount = 6;
			
			//var hdmi = context.VideoPorts.Where(i => i.Name=="HDMI").First();
			//;
			//var vga = context.VideoPorts.Where(i => i.Name == "VGA").First();

			//m.VideoPorts = new List<VideoPort>() { hdmi, vga };

			//m.DigiralAudioPortsCount = 3;
			//m.RJ45PortsCount = 1;

			//m.MotherboardChipset = context.MotherboardChipsets.Where(i=>i.Name == "Intel H610").FirstOrDefault();
			//m.AudioChipset = context.AudioChipsets.Where(i => i.Name== "Realtek ALC897").FirstOrDefault();
			//m.NetworkAdapter = context.NetworkAdapters.Where(i => i.Name == "Realtek RTL8111H").FirstOrDefault();
			//m.NetworkAdapterSpeed = 1.0f;

			//context.Motherboards.Add(m);
			//context.SaveChanges();

			MessageBox.Show("SIMPLEDIMPLE 2!");

			var dbAccessor = new GenosStoreRepositoriesPostgreSQL();
			

			Vendors = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.Vendors.List());
			MotherboardFormFactors = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.MotherboardFormFactors.List());
			CPUSockets = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.CPUSockets.List());
			CPUCores = Utilities.ConvertToCheckableCollection(dbAccessor.Items.SimpleComputerComponents.CPUCores.List());
			RAMTypes = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.RAMTypes.List());
			MotherboardFormFactors = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.MotherboardFormFactors.List());
			
			RAMSlotsCount = new RangeItem();
			PCIESlotsCount = new RangeItem();
			SataPortsCount = new RangeItem();
			USBPortsCount = new RangeItem();
			
			// var motherboards = _services.Entity.Items.ComputerComponents.Motherboards.List();
			// var converted = new ObservableCollection<ItemListElement>();
			//
			// foreach (var item in motherboards) {
			// 	var discount = item.ActiveDiscount;
			// 	var listItem = new ItemListElement();
			// 	listItem.Item = item;
			// 	if (discount != null) {
			// 		var now = DateTime.Now;
			// 		if (discount.EndsAt < now) {
			// 			item.ActiveDiscount = null;
			// 			listItem.Price = item.Price;
			// 			_services.Entity.Items.ComputerComponents.Motherboards.Update(item);
			// 		} else {
			// 			listItem.DiscountedPrice = item.Price * discount.Value;
			// 			listItem.OldPrice = item.Price;
			// 		}
			// 	} else {
			// 		listItem.Price = item.Price;
			// 	}
			// 	
			// 	converted.Add(listItem);
			// }
			//
			// _services.Entity.Items.ComputerComponents.Motherboards.Save();

			Items = Utilities.ConvertAndCheckDiscounts(
				_services.Entity.Items.ComputerComponents.Motherboards.List(),
				_services.Entity.Items.ComputerComponents.Motherboards
			);
			
		}
	}
}
