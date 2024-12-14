using GenosStore.Services.Implementation.Navigation;
using GenosStore.Services.Implementation.Navigation.PageUrlCategories;
using GenosStore.Services.Interface.Navigation;
using GenosStore.Services.Interface.Navigation.PageUrlCategories;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules.NavigationModules {
    public class PageUrlResolverModule: NinjectModule {
        public override void Load() {
            Bind<IAdminUrlsResolverService>().To<AdminUrlsResolverService>();
            Bind<IAuthRegisterUrlsResolverService>().To<AuthRegisterUrlsResolverService>();
            Bind<IItemListUrlsResolverService>().To<ItemListUrlsResolverService>();
            Bind<IItemUrlsResolverService>().To<ItemUrlsResolverService>();
            Bind<IMainUrlsResolverService>().To<MainUrlsResolverService>();
            Bind<IOrderUrlsResolverService>().To<OrderUrlsResolverService>();
            Bind<IPageUrlResolverService>().To<PageUrlResolverService>();
        }
    }
}