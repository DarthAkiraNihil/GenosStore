using System;
using GenosStore.Services.Interface.Navigation.PageUrlCategories;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.Services.Implementation.Navigation.PageUrlCategories {
    public class ItemUrlsResolverService: StandardPageUrlResolver, IItemUrlsResolverService {
        private string ComputerCase => "View/ItemPage/ComputerCasePage.xaml"; 
        private string CPUCooler => "View/ItemPage/CPUCoolerPage.xaml"; 
        private string CPU => "View/ItemPage/CPUPage.xaml"; 
        private string Display => "View/ItemPage/DisplayPage.xaml"; 
        private string GraphicsCard => "View/ItemPage/GraphicsCardPage.xaml"; 
        private string HDD => "View/ItemPage/HDDPage.xaml"; 
        private string Keyboard => "View/ItemPage/KeyboardPage.xaml"; 
        private string Motherboard => "View/ItemPage/MotherboardPage.xaml"; 
        private string Mouse => "View/ItemPage/MousePage.xaml"; 
        private string NVMeSSD => "View/ItemPage/NVMeSSDPage.xaml"; 
        private string PowerSupply => "View/ItemPage/PowerSupplyPage.xaml"; 
        private string PreparedAssembly => "View/ItemPage/PreparedAssemblyPage.xaml"; 
        private string RAM => "View/ItemPage/RAMPage.xaml"; 
        private string SataSSD => "View/ItemPage/SataSSDPage.xaml"; 
        
        public string GetUrl(PageTypeDescriptor pageType, ItemTypeDescriptor? itemType = null) {

            if (pageType != PageTypeDescriptor.ItemPage) {
                throw new ArgumentException($"Page type {pageType} is not supported. Only item lists");
            }
            
            if (itemType == null) {
                throw new ArgumentException("itemType cannot be null");
            }

            switch (itemType) {
                case ItemTypeDescriptor.ComputerCase: {
                    return ComputerCase;
                }
                case ItemTypeDescriptor.CPUCooler: {
                    return CPUCooler;
                }
                case ItemTypeDescriptor.CPU: {
                    return CPU;
                }
                case ItemTypeDescriptor.Display: {
                    return Display;
                }
                case ItemTypeDescriptor.GraphicsCard: {
                    return GraphicsCard;
                }
                case ItemTypeDescriptor.HDD: {
                    return HDD;
                }
                case ItemTypeDescriptor.Keyboard: {
                    return Keyboard;
                }
                case ItemTypeDescriptor.Motherboard: {
                    return Motherboard;
                }
                case ItemTypeDescriptor.Mouse: {
                    return Mouse;
                }
                case ItemTypeDescriptor.NVMeSSD: {
                    return NVMeSSD;
                }
                case ItemTypeDescriptor.PowerSupply: {
                    return PowerSupply;
                }
                case ItemTypeDescriptor.PreparedAssembly: {
                    return PreparedAssembly;
                }
                case ItemTypeDescriptor.RAM: {
                    return RAM;
                }
                case ItemTypeDescriptor.SataSSD: {
                    return SataSSD;
                }
                default: {
                    return NotFound;
                }
            }
        }
    }
}