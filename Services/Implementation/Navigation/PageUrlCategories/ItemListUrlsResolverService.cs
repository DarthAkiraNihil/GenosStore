using System;
using GenosStore.Services.Interface.Navigation.PageUrlCategories;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.Services.Implementation.Navigation.PageUrlCategories {
    public class ItemListUrlsResolverService: StandardPageUrlResolver, IItemListUrlsResolverService {
        private string ComputerCaseList => "View/ItemList/ComputerCasesPage.xaml";
        private string CPUCoolerList => "View/ItemList/CPUCoolersPage.xaml";
        private string CPUList => "View/ItemList/CPUsPage.xaml";
        private string DisplayList => "View/ItemList/DisplaysPage.xaml";
        private string GraphicsCardList => "View/ItemList/GraphicsCardsPage.xaml";
        private string HDDList => "View/ItemList/HDDsPage.xaml";
        private string KeyboardList => "View/ItemList/KeyboardsPage.xaml";
        private string MotherboardList => "View/ItemList/MotherboardsPage.xaml";
        private string MouseList => "View/ItemList/MousesPage.xaml";
        private string NVMeSSDList => "View/ItemList/NVMeSSDsPage.xaml";
        private string PowerSupplyList => "View/ItemList/PowerSuppliesPage.xaml";
        private string PreparedAssemblyList => "View/ItemList/PreparedAssembliesPage.xaml";
        private string RAMList => "View/ItemList/RAMsPage.xaml";
        private string SataSSDList => "View/ItemList/SataSSDsPage.xaml";

        public string GetUrl(PageTypeDescriptor pageType, ItemTypeDescriptor? itemType = null) {

            if (pageType != PageTypeDescriptor.ItemList) {
                throw new ArgumentException($"Page type {pageType} is not supported. Only item lists");
            }
            
            if (itemType == null) {
                throw new ArgumentException("itemType cannot be null");
            }

            switch (itemType) {
                case ItemTypeDescriptor.ComputerCase: {
                    return ComputerCaseList;
                }
                case ItemTypeDescriptor.CPUCooler: {
                    return CPUCoolerList;
                }
                case ItemTypeDescriptor.CPU: {
                    return CPUList;
                }
                case ItemTypeDescriptor.Display: {
                    return DisplayList;
                }
                case ItemTypeDescriptor.GraphicsCard: {
                    return GraphicsCardList;
                }
                case ItemTypeDescriptor.HDD: {
                    return HDDList;
                }
                case ItemTypeDescriptor.Keyboard: {
                    return KeyboardList;
                }
                case ItemTypeDescriptor.Motherboard: {
                    return MotherboardList;
                }
                case ItemTypeDescriptor.Mouse: {
                    return MouseList;
                }
                case ItemTypeDescriptor.NVMeSSD: {
                    return NVMeSSDList;
                }
                case ItemTypeDescriptor.PowerSupply: {
                    return PowerSupplyList;
                }
                case ItemTypeDescriptor.PreparedAssembly: {
                    return PreparedAssemblyList;
                }
                case ItemTypeDescriptor.RAM: {
                    return RAMList;
                }
                case ItemTypeDescriptor.SataSSD: {
                    return SataSSDList;
                }
                default: {
                    return NotFound;
                }
            }
        }
    }
}