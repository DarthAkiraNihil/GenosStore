using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.Navigation;
using GenosStore.ViewModel.AuthRegister;
using GenosStore.ViewModel.Main;
using GenosStore.ViewModel.Order;

namespace GenosStore.ViewModel.AppWindows {
	public class MainWindowModel: RequiresUserViewModel {
		
		#region Commands

		#region ToMainPageCommand

		private readonly RelayCommand _toMainPageCommand;

		public RelayCommand ToMainPageCommand {
			get {
				return _toMainPageCommand;
			}
		}

		private void ToMainPage(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/Main/MainPage.xaml")
			           .WithTitle("Главная страница")
			           .WithViewModel(new MainPageModel(_services, _user))
			           .Build();
			Navigate(args);
		}

		private bool CanToMainPage(object parameter) {
			return true;
		}

		#endregion

		#region ToCataloguePage

		private readonly RelayCommand _toCatalogueCommand;

		public RelayCommand ToCataloguePage {
			get { return _toCatalogueCommand; }
		}

		private void ToCatalogue(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/Main/ItemCataloguePage.xaml")
			           .WithTitle("Каталог товаров")
			           .WithViewModel(new ItemCatalogueModel(_services, _user))
			           .Build();
			
			Navigate(args);
		}

		private bool CanToCatalogue(object parameter) {
			return true;
		}

		#endregion

		#region BankCardsCommand

		private readonly RelayCommand _bankCardsCommand;

		public RelayCommand BankCardsCommand {
			get { return _bankCardsCommand; }
		}

		private void BankCards(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/Main/BankCardsPage.xaml")
			           .WithTitle("Банковские карты")
			           .WithViewModel(new BankCardsModel(_services, _user))
			           .Build();
			
			Navigate(args);
		}

		private bool CanToBankCards(object parameter) {
			return true;
		}

		#endregion

		#region ToCartPageCommand

		private readonly RelayCommand _toCartPageCommand;

		public RelayCommand ToCartPageCommand {
			get { return _toCartPageCommand; }
		}

		private void ToCartPage(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/Main/CartPage.xaml")
			           .WithTitle("Корзина")
			           .WithViewModel(new CartPageModel(_services, _user))
			           .Build();
			Navigate(args);
		}

		private bool CanToCartPage(object parameter) {
			return true;
		}

		#endregion

		#region ToOrderHistoryCommand

		private readonly RelayCommand _toOrderHistoryCommand;

		public RelayCommand ToOrderHistoryCommand {
			get { return _toOrderHistoryCommand; }
		}

		private void ToOrderHistory(object parameter) {
			var args = new NavigationArgsBuilder()
			           .WithURL("View/Order/OrderHistoryPage.xaml")
			           .WithViewModel(new OrderHistoryPageModel(_services, _user))
			           .WithTitle("История заказов")
			           .Build();

			Navigate(args);
		}

		private bool CanToOrderHistory(object parameter) {
			return true;
		}

		#endregion
		
		#endregion
		
		public MainWindowModel(IServices services, User user) : base(services, user) {
			_toMainPageCommand = new RelayCommand(ToMainPage, CanToMainPage);
			_toCatalogueCommand = new RelayCommand(ToCatalogue, CanToCatalogue);
			_bankCardsCommand = new RelayCommand(BankCards, CanToBankCards);
			_toCartPageCommand = new RelayCommand(ToCartPage, CanToCartPage);
			_toOrderHistoryCommand = new RelayCommand(ToOrderHistory, CanToOrderHistory);
			
			// var s = _services.Entity.Items.PreparedAssemblies;
			// var i = new PreparedAssembly();
			//
			// i.Name = "Конфигурация ПК 1-24";
			// i.Model = "PC-1-24";
			// i.Description = "Здесь должно быть описание сборки";
			// i.Price = 96192;
			//
			// i.RAM = new List<RAM> {
			// 	_services.Entity.Items.ComputerComponents.RAMs.List().First(j => j.Model == "Kingston FURY Beast Black")
			// };
			// i.Disks = new List<DiskDrive> {
			// 	_services.Entity.Items.ComputerComponents.NVMeSSDs.List().First(j => j.Model == "ADATA XPG GAMMIX S11 Pro")
			// };
			// i.CPU = _services.Entity.Items.ComputerComponents.CPUs.List().First(j => j.Model == "Intel Core i5-12400F");
			// i.Motherboard = _services.Entity.Items.ComputerComponents.Motherboards.List().First(j => j.Model == "MSI PRO H610M-E DDR4");
			// i.GraphicsCard = _services.Entity.Items.ComputerComponents.GraphicsCards.List().First(j => j.Model == "Palit GeForce RTX 4060 Dual");
			// i.PowerSupply = _services.Entity.Items.ComputerComponents.PowerSupplies.List().First(j => j.Model == "DEEPCOOL PF550");
			// i.ComputerCase = _services.Entity.Items.ComputerComponents.ComputerCases.List().First(j => j.Model == "ARDOR GAMING Rare M2 ARGB");
			// i.CPUCooler = _services.Entity.Items.ComputerComponents.CPUCoolers.List().First(j => j.Model == "DEEPCOOL AG400 BK ARGB");
			//
			// i.ItemType = _services.Entity.Items.ItemTypes.GetFromString("PreparedAssembly");
			// s.Create(i);
			// s.Save();
			
			// var s = _services.Entity.Items.ComputerComponents.Mouses;
			// var i = new Mouse();
			//
			// i.Name = "Мышь проводная ARDOR GAMING Fury [ARD-FURY3327-BK] черный";
			// i.Model = "ARDOR GAMING Fury";
			// i.Description = "Мышь проводная ARDOR GAMING Fury [ARD-FURY3327-BK] собрана в эффектно выглядящем эргономичном корпусе, рассчитанном на хват правой рукой. Манипулятор украшен эффектной разноцветной подсветкой. Мышь ориентирована на совместное использование с игровыми стационарными компьютерами и ноутбуками. Модель оснащена оптическим светодиодным датчиком PixArt PMW3327, обеспечивающим разрешение до 12400 dpi. Такая точность позиционирования курсора прежде всего актуальна в динамичных видеоиграх. Мышь способна выдерживать ускорение до 30 G. Частота опроса датчика типична – 1000 Гц.\nМышь проводная ARDOR GAMING Fury [ARD-FURY3327-BK] оснащена 7 кнопками, 6 из которых могут программироваться. Для соединения устройства с ПК используется интерфейс USB. Длина кабеля, составляющая 180 см, в подавляющем большинстве случаев гарантирует отсутствие сложностей с подключением.\nМатериал корпуса мыши – приятный на ощупь матовый пластик. Несмотря на довольно существенные размеры (73x41x131 мм), устройство отличается легкостью. Масса мыши составляет лишь 95 г. Манипулятор имеет практичный черный цвет.";
			// i.TDP = 0;
			// i.Price = 1750;
			//
			// i.ButtonsCount = 7;
			// i.HasProgrammableButtons = true;
			// i.IsWireless = false;
			//
			// var d = _services.Entity.Items.Characteristics.DPIModes.List();
			//
			// i.DPIModes = d.ToList();
			//
			// i.Vendor = _services.Entity.Items.Characteristics.Vendors.GetFromString("Ardor");
			// i.ItemType = _services.Entity.Items.ItemTypes.GetFromString("Mouse");
			// s.Create(i);
			// s.Save();
			
			// var s = _services.Entity.Items.ComputerComponents.Mouses;
			// var i = new Mouse();
			//
			// i.Name = "Мышь проводная ARDOR GAMING Fury [ARD-FURY3327-BK] черный";
			// i.Model = "ARDOR GAMING Fury";
			// i.Description = "Мышь проводная ARDOR GAMING Fury [ARD-FURY3327-BK] собрана в эффектно выглядящем эргономичном корпусе, рассчитанном на хват правой рукой. Манипулятор украшен эффектной разноцветной подсветкой. Мышь ориентирована на совместное использование с игровыми стационарными компьютерами и ноутбуками. Модель оснащена оптическим светодиодным датчиком PixArt PMW3327, обеспечивающим разрешение до 12400 dpi. Такая точность позиционирования курсора прежде всего актуальна в динамичных видеоиграх. Мышь способна выдерживать ускорение до 30 G. Частота опроса датчика типична – 1000 Гц.\nМышь проводная ARDOR GAMING Fury [ARD-FURY3327-BK] оснащена 7 кнопками, 6 из которых могут программироваться. Для соединения устройства с ПК используется интерфейс USB. Длина кабеля, составляющая 180 см, в подавляющем большинстве случаев гарантирует отсутствие сложностей с подключением.\nМатериал корпуса мыши – приятный на ощупь матовый пластик. Несмотря на довольно существенные размеры (73x41x131 мм), устройство отличается легкостью. Масса мыши составляет лишь 95 г. Манипулятор имеет практичный черный цвет.";
			// i.TDP = 0;
			// i.Price = 1750;
			//
			// i.ButtonsCount -
			//
			// i.HasRGBLighting = true;
			// i.IsWireless = false;
			//
			// i.KeyboardType = _services.Entity.Items.Characteristics.KeyboardTypes.GetFromString("Mechanic");
			// i.Typesize = _services.Entity.Items.Characteristics.KeyboardTypesizes.GetFromString("TKL");
			//
			// i.Vendor = _services.Entity.Items.Characteristics.Vendors.GetFromString("Ardor");
			// i.ItemType = _services.Entity.Items.ItemTypes.GetFromString("Keyboard");
			// s.Create(i);
			// s.Save();
			
			// var s = _services.Entity.Items.ComputerComponents.Displays;
			// var i = new Display();
			//
			// i.Model = "23.8\" Монитор ARDOR GAMING PORTAL AF24H1 черный";
			// i.Name = "ARDOR GAMING PORTAL AF24H1";
			// i.Description = "Игровой монитор ARDOR GAMING PORTAL AF24H1 представлен в стильном черном корпусе с функциональной подставкой и динамиками по 2 Вт. Экран 23.8” радует яркой и четкой картинкой, которая не зависает в динамичных сценах. Это позволяет с удовольствием смотреть фильмы в FullHD-разрешении и точно управлять игровым персонажем. Монитор дополнен защитой от бликов, синего свечения и мерцания.\nARDOR GAMING PORTAL AF24H1 идет в комплекте с набором кабелей в органайзере, стикером с фирменным логотипом, отверткой и салфеткой. Вы можете заменять встроенные динамики наушниками или колонками с подключением через стандартный аудиоразъем.";
			// i.TDP = 36;
			//
			// i.MaxUpdateFrequency = 144;
			// i.ScreedDiagonal = 23.8;
			//
			// i.MatrixType = _services.Entity.Items.Characteristics.MatrixTypes.GetFromString("IPS");
			// i.VesaSize = _services.Entity.Items.Characteristics.VesaSizes.GetFromString("Vesa100x100");
			// i.Underlight = _services.Entity.Items.Characteristics.Underlights.GetFromString("LED");
			// i.Definition = _services.Entity.Items.Characteristics.Definitions.List().First(d => d.Height == 1080 && d.Width == 1920);
			//
			// i.Vendor = _services.Entity.Items.Characteristics.Vendors.GetFromString("Ardor");
			// i.ItemType = _services.Entity.Items.ItemTypes.GetFromString("Display");
			// s.Create(i);
			// s.Save();
			
			// var s = _services.Entity.Items.ComputerComponents.ComputerCases;
			// var i = new ComputerCase();
			//
			// i.Model = "Корпус ARDOR GAMING Rare M2 ARGB черный";
			// i.Name = "ARDOR GAMING Rare M2 ARGB";
			// i.Description = "Черный корпус ARDOR GAMING Rare M2 ARGB для игрового ПК обладает типоразмером Mid-Tower. Конструкция оснащена металлической решеткой на фронтальной панели и стеклянной боковой стенкой. Такой дизайн подчеркивает ARGB-подсветку 4 установленных вентиляторов и позволяет настраивать систему жидкостного охлаждения.\nARDOR GAMING Rare M2 ARGB допускает нижнее размещение блока питания и вертикальную установку материнской платы. Модель оснащена 8 горизонтальными слотами расширения для добавления звуковых и видеокарт длиной до 38 см, интерфейсных плат и других устройств. В корпусе есть 7 мест для установки накопителей 2.5” и 2 внутренних отсека 3.5”.";
			// i.TDP = 0;
			//
			// var eatx = _services.Entity.Items.Characteristics.MotherboardFormFactors.GetFromString("E-ATX");
			// var matx = _services.Entity.Items.Characteristics.MotherboardFormFactors.GetFromString("mini-ATX");
			// var miatx = _services.Entity.Items.Characteristics.MotherboardFormFactors.GetFromString("micro-ATX");
			// var atx = _services.Entity.Items.Characteristics.MotherboardFormFactors.GetFromString("ATX");
			//
			// i.SupportedMotherboardFormFactors = new List<MotherboardFormFactor> {
			// 	eatx, matx, miatx, atx
			// };
			// i.HasARGBLighting = true;
			// i.DrivesSlotsCount = 9;
			// i.Length = 447;
			// i.Width = 220;
			// i.Height = 510;
			//
			// i.Vendor = _services.Entity.Items.Characteristics.Vendors.GetFromString("Ardor");
			// i.ItemType = _services.Entity.Items.ItemTypes.GetFromString("ComputerCase");
			// i.ComputerCaseTypesize = _services.Entity.Items.Characteristics.ComputerCaseTypesizes.GetFromString("MidTower");
			// s.Create(i);
			// s.Save();

			// var ssdc = new SSDController();
			//
			// ssdc.Name = "Samsung MKX";
			// ssdc.Model = "Samsung MKX";
			// ssdc.Type = _services.Entity.Items.SimpleComputerComponents.Types.GetFromString("SSDController");
			//
			// _services.Entity.Items.SimpleComputerComponents.SSDControllers.Create(ssdc);
			// _services.Entity.Items.SimpleComputerComponents.SSDControllers.Save();

			// ssdc.Name = "Silicon Motion SM2262EN";
			// ssdc.Model = "Silicon Motion SM2262EN";
			// ssdc.Type = _services.Entity.Items.SimpleComputerComponents.Types.GetFromString("SSDController");
			//
			// _services.Entity.Items.SimpleComputerComponents.SSDControllers.Create(ssdc);
			// _services.Entity.Items.SimpleComputerComponents.SSDControllers.Save();
			
			
			// "Motherboards" #
			// "CPUs" #
			// "RAMs" #
			// "GraphicsCards" #
			// "HDDs" #
			// "NVMeSSDs" #
			// "SataSSDs" #
			// "CPUCoolers" $
			// "PowerSupplies"  #
			// "ComputerCases" #
			// "Displays" #
			// "Keyboards" #
			// "Mouses" #
			// "PreparedAssemblies"
			
			// var s = _services.Entity.Items.ComputerComponents.PowerSupplies;
			// var i = new PowerSupply();
			//
			// i.ImageBase64 = "";
			// i.Model = "Блок питания DEEPCOOL PF550 [R-PF550D-HA0B-EU] черный";
			// i.Name = "DEEPCOOL PF550";
			// i.Description = "Блок питания DEEPCOOL PF550 [R-PF550D-HA0B-EU] демонстрирует общую выходную мощность по всем линиям на уровне 550 Вт, что позволяет применять его в системном блоке домашней станции, мультимедийного ПК или игрового компьютера начального уровня. В БП предусмотрены кабели черного цвета с разъемами 20 + 4 pin (основной разъем питания), 4+4 pin CPU (для подключения процессора), 6x SATA (для накопителей), 6+2 pin x2 PCI-E (для видеокарт).\nБлок питания DEEPCOOL PF550 [R-PF550D-HA0B-EU] выполнен в форм-факторе ATX и укомплектован сетевым шнуром. Модель предполагает работу от сети при входном напряжении 200-240 В. БП с активным корректором коэффициента мощности оснащается активной системой охлаждения с вентилятором размером 120x120 мм. Обороты кулера задаются автоматикой в соответствии с текущей нагрузкой блока питания.";
			// i.TDP = 0;
			// i.SataPorts = 1;
			// i.MolexPorts = 1;
			// i.PowerOutput = 550;
			// i.Certificate80Plus = _services.Entity.Items.Characteristics.Certificates80Plus.GetFromString("Нет");
			


			
			// var s = _services.Entity.Items.ComputerComponents.HDDs;
			// var i = new HDD();
			//
			// i.ImageBase64 = "";
			// i.Model = "WD Ultrastar DC HC570";
			// i.Name = "22 ТБ Жесткий диск WD Ultrastar DC HC570 [0F48155]";
			// i.Description = "Стремительный рост объемов данных в сфере технологий искусственного интеллекта и машинного обучения (AI/ML), сетей 5G, Интернета вещей, автомобилей с выходом в Интернет и других, порождает спрос на расширение центров обработки данных. Инновационные жесткие диски позволяют записывать, хранить, анализировать и защищать большую часть этих данных. Жесткие диски большей емкости обеспечивают более высокую плотность записи, что позволяет расширять центры обработки данных и повышать их эффективность.";
			// i.TDP = 9.3;
			// i.Capacity = 22000;
			// i.ReadSpeed = 4000;
			// i.WriteSpeed = 4000;
			// i.RPM = 7200;
			//

			//i.Price = 2899;
			
			// var s = _services.Entity.Items.ComputerComponents.SataSSDs;
			// var i = new SataSSD();
			//
			// i.ImageBase64 = "";
			// i.Model = "Samsung 870 EVO";
			// i.Name = "1000 ГБ 2.5\" SATA накопитель Samsung 870 EVO [MZ-77E1T0BW]";
			// i.Description = "SATA накопитель Samsung 870 EVO обеспечивает надежность хранения данных и повышение отзывчивости системы ПК при выполнении различных задач. Интерфейс SATA и технология 3D NAND гарантируют скорость на уровне показателя 560 Мбайт/сек в режиме чтения и 530 Мбайт/сек в режиме записи. Объем 1000 ГБ предоставляет достаточно пространства для хранения документов, мультимедийных файлов и прочего контента. С помощью фирменного ПО Samsung Magician можно выполнять мониторинг системы и управлять различными настройками накопителя. Тонкий и прочный корпус Samsung 870 EVO устойчив к ударам и вибрации.";
			// i.TDP = 0.33;
			// i.Capacity = 1000;
			// i.ReadSpeed = 560;
			// i.WriteSpeed = 530;
			// i.TBW = 600;
			// i.DWPD = 0.33f;
			// i.BitsForCell = 3;
			//
			// i.SSDController = ssdc;
			//
			// i.Price = 11600;
			
			// i.ImageBase64 = "";
			// i.Model = "Kingston FURY Beast Black";
			// i.Name = "Оперативная память Kingston FURY Beast Black [KF432C16BBK2/32] 32 ГБ";
			// i.Description = "Оперативная память Kingston FURY Beast Black выделяется оригинальным оформлением и мощными характеристиками, поэтому станет надежным дополнением геймерского или оверклокерского ПК. Она представлена в виде комплекта из двух модулей памяти объемом по 16 ГБ, которые работают на частоте 3200 МГц и отличаются низкими задержками. Для эффективного отвода тепла от чипов памяти установлены алюминиевые радиаторы специальной формы. Благодаря тестированию на совместимость и надежность достигается исключительная стабильность функционирования Kingston FURY Beast.";
			// i.TDP = 0;
			// i.TotalSize = 32;
			// i.ModuleSize = 16;
			// i.ModulesCount = 2;
			// i.Frequency = 3200;
			// i.CL = 16;
			// i.tRCD = 20;
			// i.tRP = 20;
			// i.tRAS = 20;
			// i.Price = 8499
			// i.RAMType = _services.Entity.Items.Characteristics.RAMTypes.GetFromString("DDR4");
			// i.Vendor = _services.Entity.Items.Characteristics.Vendors.GetFromString("Western Digital");
			// i.ItemType = _services.Entity.Items.ItemTypes.GetFromString("HDD");
			// s.Create(i);
			// s.Save();

			// var s = _services.Entity.Items.ComputerComponents.NVMeSSDs;
			// var i = new NVMeSSD();
			//
			// i.ImageBase64 = "";
			// i.Model = "ADATA XPG GAMMIX S11 Pro";
			// i.Name = "1000 ГБ M.2 NVMe накопитель ADATA XPG GAMMIX S11 Pro [AGAMMIXS11P-1TT-C]";
			// i.Description = "1024 ГБ SSD M.2 накопитель A-Data XPG GAMMIX S11 Pro [AGAMMIXS11P-1TT-C] станет отличным выбором для значительного повышения быстродействия вашего компьютера при выполнении самых разнообразных задач — будь то запуск игр, работа с файлами или монтаж видео. Благодаря используемым чипам памяти NAND с 3D-структурой и контроллеру Silicon Motion SM2262EN обработка файлов происходит со скоростью до 3500 МБ/с при чтении и 3000 МБ/с при записи, что обеспечит выдающуюся производительность и комфорт при работе. Также данная модель отличается длительным ресурсом, достигающим 640 TBW.\nSSD M.2 накопитель A-Data XPG GAMMIX S11 Pro выполнен в форм-факторе 2280, где 22 мм — это ширина, 80 мм — длина модуля. Модель отличается двусторонней компоновкой чипов памяти и имеет толщину 6.1 мм. Подключение осуществляется посредством интерфейса PCI-e 3.0 x4. Энергопотребление накопителя не превышает 0.33 Вт.";
			// i.TDP = 0.33;
			// i.Capacity = 1000;
			// i.ReadSpeed = 3500;
			// i.WriteSpeed = 3000;
			// i.TBW = 640;
			// i.DWPD = 0.35f;
			// i.BitsForCell = 3;
			//
			// i.SSDController = ssdc;
			//
			// // i.ImageBase64 = "";
			// // i.Model = "Kingston FURY Beast Black";
			// // i.Name = "Оперативная память Kingston FURY Beast Black [KF432C16BBK2/32] 32 ГБ";
			// // i.Description = "Оперативная память Kingston FURY Beast Black выделяется оригинальным оформлением и мощными характеристиками, поэтому станет надежным дополнением геймерского или оверклокерского ПК. Она представлена в виде комплекта из двух модулей памяти объемом по 16 ГБ, которые работают на частоте 3200 МГц и отличаются низкими задержками. Для эффективного отвода тепла от чипов памяти установлены алюминиевые радиаторы специальной формы. Благодаря тестированию на совместимость и надежность достигается исключительная стабильность функционирования Kingston FURY Beast.";
			// // i.TDP = 0;
			// // i.TotalSize = 32;
			// // i.ModuleSize = 16;
			// // i.ModulesCount = 2;
			// // i.Frequency = 3200;
			// // i.CL = 16;
			// // i.tRCD = 20;
			// // i.tRP = 20;
			// // i.tRAS = 20;
			// // i.Price = 8499
			// // i.RAMType = _services.Entity.Items.Characteristics.RAMTypes.GetFromString("DDR4");
			// i.Vendor = _services.Entity.Items.Characteristics.Vendors.GetFromString("ADATA");
			// i.ItemType = _services.Entity.Items.ItemTypes.GetFromString("NVMeSSD");
			// s.Create(i);
			// s.Save();

			//var _gcse = _services.Entity.Items.ComputerComponents.GraphicsCards;
			
			// var gc = new GraphicsCard();
			//
			// gc.ImageBase64 = ";
			// gc.Model = "Palit GeForce RTX 4060 Dual";
			// gc.Name = "Видеокарта Palit GeForce RTX 4060 Dual [NE64060019P1-1070D]";
			// gc.Description = "Видеокарта Palit GeForce RTX 4060 DUAL [NE64060019P1-1070D] ориентирована на игровые системы и рабочие станции. Благодаря микроархитектуре Ada Lovelace и 8 ГБ памяти стандарта GDDR6 она обеспечивает производительность, скорость и плавность при обработке графических данных. Процессор работает на частоте 1830 МГц, которая способна увеличиваться в режиме разгона до показателя 2460 МГц.\nСистема охлаждения с двумя вентиляторами, радиатором и тепловыми трубками отводит тепло и поддерживает низкую температуру нагрева видеокарты Palit GeForce RTX 4060 DUAL [NE64060019P1-1070D]. Технология 0-dB Tech останавливает вращение крыльчатки в режиме низкой нагрузки, что делает работу графического адаптера бесшумной. На верхней стороне кожуха есть полоса с подсветкой RGB. С помощью программного обеспечения ThunderMaster можно настраивать параметры производительности и контролировать состояние системы.";
			// gc.TDP = 115;
			// gc.VideoRAM = 8;
			//
			// var dp = _services.Entity.Items.Characteristics.VideoPorts.GetFromString("DisplayPort");
			// var hdmi = _services.Entity.Items.Characteristics.VideoPorts.GetFromString("HDMI");
			// gc.VideoPorts = new List<VideoPort> { hdmi, dp, dp, dp };
			// gc.MaxDisplaysSupported = 4;
			// gc.UsedSlots = 2;
			//
			// gc.GPU = _services.Entity.Items.SimpleComputerComponents.GPUs.List().Find(g => g.Model == "GeForce RTX 4060"
			// 	);
			//
			// gc.ItemType = _services.Entity.Items.ItemTypes.GetFromString("GraphicsCard");
			// gc.Vendor = _services.Entity.Items.Characteristics.Vendors.List().Find(v => v.Name == "Palit");
			//
			// _gcse.Create(gc);
			// _gcse.Save();
			MessageBox.Show("KONO DIO DA!");
			
			// var cpuse = _services.Entity.Items.ComputerComponents.CPUs;
			//
			// var ddr4 = _services.Entity.Items.Characteristics.RAMTypes.List().Find(i => i.Name == "DDR4");
			// var ddr5 = _services.Entity.Items.Characteristics.RAMTypes.List().Find(i => i.Name == "DDR5");
			//
			// var cpu = new CPU();
			//
			// cpu.ImageBase64 = 
			// cpu.Model = "Intel Core i5-12400F";
			// cpu.Name = "Процессор Intel Core i5-12400F OEM";
			// cpu.Description = "Процессор Intel Core i5-12400F OEM – отличный выбор для пользователей, желающих собрать игровой ПК или производительный универсальный компьютер. CPU имеет 6 производительных ядер. Базовая частота процессора – 2.5 ГГц. Максимальная частота в турборежиме значительно выше – 4.4 ГГц. Значительное влияние на производительность процессора оказывают 7.5-мегабайтный кэш L2 и 18-мегабайтный кэш L3. Устройство совместимо с оперативной памятью DDR4 и DDR5. Максимально поддерживаемый объем ОЗУ равен 128 ГБ.\nПроцессор Intel Core i5-12400F OEM отличается низким тепловыделением. TDP устройства – 65 Вт. Выбор системы охлаждения производится с учетом этого показателя. В комплекте кулер отсутствует. Максимальная рабочая температура процессора – 100 \u00b0C.";
			// cpu.BaseFrequency = 2.5f;
			// cpu.CoresCount = 6;
			// cpu.ThreadsCount = 12;
			// cpu.TechnicalProcess = 7;
			// cpu.HasIntegratedGraphics = false;
			// cpu.L2CahceSize = 7.5f;
			// cpu.L3CacheSize = 18;
			// cpu.CPUSocket = _services.Entity.Items.Characteristics.CPUSockets.List().Find(i => i.Name == "LGA1700");
			// cpu.CPUCore = _services.Entity.Items.SimpleComputerComponents.CPUCores.List().Find(i => i.Name == "Alder Lake-S"); // Alder Lake-S
			// cpu.SupportedRamType = new List<RAMType> { ddr4, ddr5 };
			// cpu.SupportedRAMSize = 128;
			// cpu.ItemType = _services.Entity.Items.ItemTypes.GetFromString("CPU");
			// cpu.Vendor = _services.Entity.Items.Characteristics.Vendors.List().Find(v => v.Name == "Intel");
			//
			// cpuse.Create(cpu);
			// cpuse.Save();
			// MessageBox.Show("SAVED");

		}
	}
}
