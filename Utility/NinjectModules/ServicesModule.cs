using GenosStore.Services.Implementation.Common;
using GenosStore.Services.Implementation.Common.Cache;
using GenosStore.Services.Implementation.Entity;
using GenosStore.Services.Implementation.Entity.Items;
using GenosStore.Services.Implementation.Entity.Items.Characteristics;
using GenosStore.Services.Implementation.Entity.Items.ComputerComponents;
using GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents;
using GenosStore.Services.Implementation.Entity.Orders;
using GenosStore.Services.Implementation.Entity.Users;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Common.Cache;
using GenosStore.Services.Interface.Entity;
using GenosStore.Services.Interface.Entity.Items;
using GenosStore.Services.Interface.Entity.Items.Characteristics;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;
using GenosStore.Services.Interface.Entity.Orders;
using GenosStore.Services.Interface.Entity.Users;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules {
    public class ServicesModule: NinjectModule {
        
        public override void Load() {

            Bind<ICPUSocketService>().To<CPUSocketsService>();
            Bind<IMotherboardFormFactorService>().To<MotherboardFormFactorsService>();
            Bind<IRAMTypeService>().To<RAMTypesService>();
            Bind<IVendorService>().To<VendorsService>();
            Bind<ICharacteristicsService>().To<CharacreristicsService>();
            
            Bind<IMotherboardService>().To<MotherboardService>().InSingletonScope();
            Bind<IComputerComponentServices>().To<ComputerComponentServices>().InSingletonScope();

            Bind<ICPUCoreService>().To<CPUCoresService>();
            Bind<ISimpleComputerComponentService>().To<SimpleComputerComponentsService>();
            
            Bind<IItemServices>().To<ItemServices>().InSingletonScope();
            
            Bind<ICartService>().To<CartService>();
            Bind<IActiveDiscountService>().To<ActiveDiscountService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IBankSystemService>().To<BankSystemService>();
            Bind<IBankCardService>().To<BankCardsService>();
            Bind<IOrderStatusService>().To<OrderStatusService>();
            Bind<IOrderEntitiesService>().To<OrderEntitiesService>();
            Bind<IEntityServices>().To<EntityServices>().InSingletonScope();
            Bind<IImageCacheService>().To<ImageCacheService>();
            Bind<ICacheServices>().To<CacheServices>();
            Bind<IPageResolverService>().To<PageResolverService>();
            Bind<IAuthorizationService>().To<AuthorizationService>().InSingletonScope();
            Bind<ICommonServices>().To<CommonServices>().InSingletonScope();
            Bind<IUserService>().To<UserService>().InSingletonScope();
            Bind<IServices>().To<Services.Implementation.Services>().InSingletonScope();
            
        }
        
    }
}