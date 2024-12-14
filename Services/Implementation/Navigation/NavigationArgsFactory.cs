using GalaSoft.MvvmLight.Views;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Navigation;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.Services.Implementation.Navigation {
    public class NavigationArgsFactory: INavigationArgsFactory {
        
        private readonly IPageUrlResolverService _pageUrlResolverService;
        private readonly IViewModelFactory _viewModelFactory;

        public NavigationArgsFactory(IPageUrlResolverService pageUrlResolverService, IViewModelFactory viewModelFactory) {
            _pageUrlResolverService = pageUrlResolverService;
            _viewModelFactory = viewModelFactory;
        }

        public NavigationArgs GetNavigationArgs(PageTypeDescriptor pageType, IServices services) {
            
            var vm = _viewModelFactory.CreateViewModel(pageType, services);
            
            var args = new NavigationArgsBuilder()
                        .WithURL(_pageUrlResolverService.GetUrl(pageType))
                        .WithTitle(vm.Title)
                       //.WithURL("View/ItemPage/MotherboardPage.xaml")
                       //.WithViewModel(new MotherboardsListModel(_services, _user))
                        .WithViewModel(vm)
                        .Build();
            
            return args;
        }

        public NavigationArgs GetNavigationArgs(PageTypeDescriptor pageType, IServices services, User user, ItemTypeDescriptor? itemType = null, int? itemId = null) {
            var vm = _viewModelFactory.CreateViewModel(pageType, services, user, itemId, itemType);
            
            var args = new NavigationArgsBuilder()
                        .WithURL(_pageUrlResolverService.GetUrl(pageType, itemType))
                        .WithTitle(vm.Title)
                        .WithViewModel(vm)
                        .Build();
            
            return args;
        }

        public NavigationArgs GetNavigationArgs(PageTypeDescriptor pageType, IServices services, User user, Order order) {
            var vm = _viewModelFactory.CreateViewModel(pageType, services, user, order);
            
            var args = new NavigationArgsBuilder()
                        .WithURL(_pageUrlResolverService.GetUrl(pageType))
                        .WithTitle(vm.Title)
                       //.WithURL("View/ItemPage/MotherboardPage.xaml")
                       //.WithViewModel(new MotherboardsListModel(_services, _user))
                        .WithViewModel(vm)
                        .Build();
            
            return args;
        }
    }
}