using GenosStore.Services.Implementation.Common;
using GenosStore.Services.Implementation.Common.Cache;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Common.Cache;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules.ServiceModules {
    public class CommonServicesModule: NinjectModule {
        public override void Load() {

            Bind<IImageCacheService>().To<ImageCacheService>().InSingletonScope();
            Bind<ICacheServices>().To<CacheServices>().InSingletonScope();
            Bind<IPageResolverService>().To<PageResolverService>().InSingletonScope();
            Bind<IAuthorizationService>().To<AuthorizationService>().InSingletonScope();
            Bind<IPaymentService>().To<PaymentService>().InSingletonScope();
            Bind<ICommonServices>().To<CommonServices>().InSingletonScope();
            
        }
    }
}