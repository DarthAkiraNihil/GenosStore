﻿using System;
using System.Collections.Generic;
using System.Windows.Controls;
using GenosStore.Services.Interface.Common;
using GenosStore.Utility.Navigation;
using GenosStore.View.AuthRegister;
using GenosStore.View.ItemList;
using GenosStore.View.ItemPage;
using GenosStore.View.Main;
using GenosStore.View.Order;
using GenosStore.View.Other;

namespace GenosStore.Services.Implementation.Common {
    public class PageResolverService: IPageResolverService {
        private readonly Dictionary<string, Func<NavigationArgs, Page>> _resolveDict = new Dictionary<string, Func<NavigationArgs, Page>> {
            {"View/AuthRegister/AuthorizationPage.xaml",  a => new AuthorizationPage { DataContext = a.ViewModel } },
            {"View/AuthRegister/RegisterIndividualPage.xaml",  a => new RegisterIndividualPage { DataContext = a.ViewModel } },
            {"View/AuthRegister/RegisterLegalPage.xaml",  a => new RegisterLegalPage { DataContext = a.ViewModel } },
            {"View/Main/ItemCataloguePage.xaml",  a => new ItemCatalogue { DataContext = a.ViewModel } },
            {"View/ItemList/MotherboardsPage.xaml",  a => new MotherboardsPage { DataContext = a.ViewModel } },
            {"View/ItemPage/MotherboardPage.xaml", a => new MotherboardPage { DataContext = a.ViewModel } },
            {"View/Main/MainPage.xaml", a => new MainPage { DataContext = a.ViewModel } },
            {"View/Main/CartPage.xaml", a => new CartPage { DataContext = a.ViewModel } },
            {"View/Main/BankCardsPage.xaml", a => new BankCardsPage { DataContext = a.ViewModel } },
            {"View/Order/OrderPage.xaml", a => new OrderPage { DataContext = a.ViewModel } },
            {"View/Order/OrderHistoryPage.xaml", a => new OrderHistoryPage { DataContext = a.ViewModel } },
            {"View/Order/PaymentPage.xaml", a => new PaymentPage { DataContext = a.ViewModel } },
            {"View/Order/SuccessfulPaymentPage.xaml", a => new SuccessfulPaymentPage { DataContext = a.ViewModel } },
        };

        public Page Resolve(NavigationArgs args) {
            if (_resolveDict.ContainsKey(args.URL)) {
                return _resolveDict[args.URL](args);
            }

            return new PageNotFound();
        }
    }
}