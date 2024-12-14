using GenosStore.Services.Implementation.Navigation;
using GenosStore.Services.Interface.Navigation;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules.NavigationModules {
    public class NavigationServicesModule: NinjectModule  {
        public override void Load() {
            Bind<IViewModelFactory>().To<ViewModelFactory>();
            Bind<INavigationArgsFactory>().To<NavigationArgsFactory>();
            Bind<IPageResolverService>().To<PageResolverService>().InSingletonScope();
            Bind<INavigationServices>().To<NavigationServices>();
        }
    }
}