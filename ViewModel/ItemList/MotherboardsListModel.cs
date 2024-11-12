using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Implementation.PostgreSQL;
using GenosStore.Utility;

namespace GenosStore.ViewModel.ItemList {
	public class MotherboardsListModel: AbstractViewModel {
		
		private readonly RelayCommand _toItemPageCommand;
		private readonly RelayCommand _applyFiltersCommand;
		
		public ObservableCollection<CheckableItem<Vendor>> Vendors { get; set; }
		public ObservableCollection<CheckableItem<MotherboardFormFactor>> MotherboardFormFactors { get; set; }
		public ObservableCollection<CheckableItem<CPUSocket>> CPUSockets { get; set; }
		public ObservableCollection<CheckableItem<CPUCore>> CPUCores { get; set; }
		public ObservableCollection<CheckableItem<RAMType>> RAMTypes { get; set; }
		
		public ObservableCollection<Motherboard> Motherboards { get; set; }
		
		public RelayCommand ToItemPageCommand {
			get { return _toItemPageCommand; }
		}

		public RelayCommand ApplyFiltersCommand {
			get { return _applyFiltersCommand; }
		}

		private void ToItemPage(object parameter) {
			int id = (int) parameter;
			
			Navigate("View/ItemPage/MotherboardPage.xaml", "", id);
		}

		private bool CanToItemPage(object parameter) {
			return true;
		}

		private void ApplyFilters(object parameter) {
			MessageBox.Show("A");
		}

		private bool CanApplyFilters(object parameter) {
			return true;
		}

		public MotherboardsListModel() {
			_toItemPageCommand = new RelayCommand(ToItemPage, CanToItemPage);
			_applyFiltersCommand = new RelayCommand(ApplyFilters, CanApplyFilters);
			
			//var context = new GenosStoreDatabaseContext();

			//var ac = new MotherboardChipset();
			//ac.Model = "Intel H610";
			//ac.Name = "Intel H610";
			//ac.Type = context.SimpleComputerComponentTypes.Where(i => i.Name == "MotherboardChipset").FirstOrDefault();
			//context.MotherboardChipsets.Add(ac);
			////var na = new NetworkAdapter();
			////na.Model = "Realtek RTL8111H";
			////na.Name = "Realtek RTL8111H";
			////na.Type = context.SimpleComputerComponentTypes.Where(i => i.Name == "NetworkAdapter").FirstOrDefault();

			////context.AudioChipsets.Add(ac);
			////context.NetworkAdapters.Add(na);

			//context.SaveChanges();

			//MessageBox.Show("SIMPLEDIMPLE");

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

			//MessageBox.Show("SIMPLEDIMPLE 2!");

			var dbAccessor = new GenosStoreRepositoriesPostgreSQL();
			

			Vendors = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.Vendors.List());
			MotherboardFormFactors = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.MotherboardFormFactors.List());
			CPUSockets = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.CPUSockets.List());
			CPUCores = Utilities.ConvertToCheckableCollection(dbAccessor.Items.SimpleComputerComponents.CPUCores.List());
			RAMTypes = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.RAMTypes.List());
			MotherboardFormFactors = Utilities.ConvertToCheckableCollection(dbAccessor.Items.Characteristics.MotherboardFormFactors.List());

			Motherboards = new ObservableCollection<Motherboard>(dbAccessor.Items.ComputerComponents.Motherboards.List());


		}
		
	}
}
