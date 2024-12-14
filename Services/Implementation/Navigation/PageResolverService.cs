using System;
using System.Collections.Generic;
using System.Windows.Controls;
using GenosStore.Services.Interface.Navigation;
using GenosStore.Utility.Navigation;
using GenosStore.View.Admin;
using GenosStore.View.AuthRegister;
using GenosStore.View.ItemList;
using GenosStore.View.ItemPage;
using GenosStore.View.Main;
using GenosStore.View.Order;
using GenosStore.View.Other;

namespace GenosStore.Services.Implementation.Navigation {
    public class PageResolverService: IPageResolverService {
        private readonly Dictionary<string, Func<NavigationArgs, Page>> _resolveDict = new Dictionary<string, Func<NavigationArgs, Page>> {
            {"View/AuthRegister/AuthorizationPage.xaml",  a => new AuthorizationPage { DataContext = a.ViewModel } },
            {"View/AuthRegister/RegisterIndividualPage.xaml",  a => new RegisterIndividualPage { DataContext = a.ViewModel } },
            {"View/AuthRegister/RegisterLegalPage.xaml",  a => new RegisterLegalPage { DataContext = a.ViewModel } },
            
            {"View/Main/ItemCataloguePage.xaml",  a => new ItemCatalogue { DataContext = a.ViewModel } },
            
            {"View/ItemList/MotherboardsPage.xaml",  a => new MotherboardsPage { DataContext = a.ViewModel } },
            {"View/ItemList/CPUsPage.xaml",  a => new CPUsPage { DataContext = a.ViewModel } },
            {"View/ItemList/ComputerCasesPage.xaml",  a => new ComputerCasesPage { DataContext = a.ViewModel } },
            {"View/ItemList/CPUCoolersPage.xaml",  a => new CPUCoolersPage { DataContext = a.ViewModel } },
            {"View/ItemList/DisplaysPage.xaml",  a => new DisplaysPage { DataContext = a.ViewModel } },
            {"View/ItemList/GraphicsCardsPage.xaml",  a => new GraphicCardsPage { DataContext = a.ViewModel } },
            {"View/ItemList/HDDsPage.xaml",  a => new HDDsPage { DataContext = a.ViewModel } },
            {"View/ItemList/KeyboardsPage.xaml",  a => new KeyboardsPage { DataContext = a.ViewModel } },
            {"View/ItemList/MousesPage.xaml",  a => new MousesPage { DataContext = a.ViewModel } },
            {"View/ItemList/NVMeSSDsPage.xaml",  a => new NVMeSSDsPage { DataContext = a.ViewModel } },
            {"View/ItemList/PowerSuppliesPage.xaml",  a => new PowerSuppliesPage { DataContext = a.ViewModel } },
            {"View/ItemList/RAMsPage.xaml",  a => new RAMsPage { DataContext = a.ViewModel } },
            {"View/ItemList/SataSSDsPage.xaml",  a => new SataSSDsPage { DataContext = a.ViewModel } },
            {"View/ItemList/PreparedAssembliesPage.xaml",  a => new PreparedAssembliesPage { DataContext = a.ViewModel } },
                
                
            
            {"View/ItemPage/MotherboardPage.xaml", a => new MotherboardPage { DataContext = a.ViewModel } },
            {"View/ItemPage/CPUPage.xaml", a => new CPUPage { DataContext = a.ViewModel } },
            {"View/ItemPage/ComputerCasePage.xaml", a => new ComputerCasePage { DataContext = a.ViewModel } },
            {"View/ItemPage/CPUCoolerPage.xaml", a => new CPUCoolerPage { DataContext = a.ViewModel } },
            {"View/ItemPage/DisplayPage.xaml", a => new DisplayPage { DataContext = a.ViewModel } },
            {"View/ItemPage/GraphicsCardPage.xaml", a => new GraphicsCardPage { DataContext = a.ViewModel } },
            {"View/ItemPage/HDDPage.xaml", a => new HDDPage { DataContext = a.ViewModel } },
            {"View/ItemPage/KeyboardPage.xaml", a => new KeyboardPage { DataContext = a.ViewModel } },
            {"View/ItemPage/MousePage.xaml", a => new MousePage { DataContext = a.ViewModel } },
            {"View/ItemPage/NVMeSSDPage.xaml", a => new NVMeSSDPage { DataContext = a.ViewModel } },
            {"View/ItemPage/PowerSupplyPage.xaml", a => new PowerSupplyPage { DataContext = a.ViewModel } },
            {"View/ItemPage/RAMPage.xaml", a => new RAMPage { DataContext = a.ViewModel } },
            {"View/ItemPage/SataSSDPage.xaml", a => new SataSSDPage { DataContext = a.ViewModel } },
            {"View/ItemPage/PreparedAssemblyPage.xaml", a => new PreparedAssemblyPage { DataContext = a.ViewModel } },
            
            {"View/Main/MainPage.xaml", a => new MainPage { DataContext = a.ViewModel } },
            {"View/Main/CartPage.xaml", a => new CartPage { DataContext = a.ViewModel } },
            {"View/Main/BankCardsPage.xaml", a => new BankCardsPage { DataContext = a.ViewModel } },
            {"View/Order/OrderPage.xaml", a => new OrderPage { DataContext = a.ViewModel } },
            {"View/Order/OrderHistoryPage.xaml", a => new OrderHistoryPage { DataContext = a.ViewModel } },
            {"View/Order/PaymentPage.xaml", a => new PaymentPage { DataContext = a.ViewModel } },
            {"View/Order/SuccessfulPaymentPage.xaml", a => new SuccessfulPaymentPage { DataContext = a.ViewModel } },
            
            {"View/Admin/LegalEntityVerificationPage.xaml", a => new LegalEntityVerificationPage { DataContext = a.ViewModel } },
            {"View/Admin/OrderManagementPage.xaml", a => new OrderManagementPage { DataContext = a.ViewModel } },
            {"View/Admin/SingleOrderManagementPage.xaml", a => new SingleOrderManagementPage { DataContext = a.ViewModel } },
            {"View/Admin/DashboardPage.xaml", a => new DashboardPage { DataContext = a.ViewModel } },
            {"View/Admin/SalesAnalysisReportPage.xaml", a => new SalesAnalysisReportPage { DataContext = a.ViewModel } },
        };

        public Page Resolve(NavigationArgs args) {
            if (_resolveDict.ContainsKey(args.URL)) {
                return _resolveDict[args.URL](args);
            }

            return new PageNotFound();
        }
    }
}