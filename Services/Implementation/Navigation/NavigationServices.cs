using GalaSoft.MvvmLight.Views;
using GenosStore.Services.Interface.Navigation;

namespace GenosStore.Services.Implementation.Navigation {
    public class NavigationServices: INavigationServices {

        private IPageResolverService _pageResolverService;
        private INavigationArgsFactory _navigationArgsFactory;

        public IPageResolverService PageResolver {
            get { return _pageResolverService; }
        }

        public INavigationArgsFactory NavigationArgsFactory {
            get { return _navigationArgsFactory; }
        }

        public NavigationServices(IPageResolverService pageResolverService, INavigationArgsFactory navigationArgsFactory) {
            _pageResolverService = pageResolverService;
            _navigationArgsFactory = navigationArgsFactory;
        }
    }
}