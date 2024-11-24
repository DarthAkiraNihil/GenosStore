using GenosStore.Services.Implementation.Common;
using GenosStore.Services.Implementation.Entity;
using GenosStore.Services.Implementation.Entity.Items;
using GenosStore.Services.Implementation.Entity.Items.ComputerComponents;
using GenosStore.Services.Implementation.Entity.Orders;
using GenosStore.Services.Implementation.Entity.Users;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity;
using GenosStore.Services.Interface.Entity.Items;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;
using GenosStore.Services.Interface.Entity.Orders;
using GenosStore.Services.Interface.Entity.Users;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules {
    public class ServicesModule: NinjectModule {
        
        public override void Load() {
            
            Bind<IMotherboardService>().To<MotherboardService>().InSingletonScope();
            Bind<IComputerComponentServices>().To<ComputerComponentServices>().InSingletonScope();
            Bind<IItemServices>().To<ItemServices>().InSingletonScope();
            Bind<ICartService>().To<CartService>();
            Bind<IOrderEntitiesService>().To<OrderEntitiesService>();
            Bind<IEntityServices>().To<EntityServices>().InSingletonScope();
            Bind<IAuthorizationService>().To<AuthorizationService>().InSingletonScope();
            Bind<ICommonServices>().To<CommonServices>().InSingletonScope();
            Bind<IUserService>().To<UserService>().InSingletonScope();
            Bind<IServices>().To<Services.Implementation.Services>().InSingletonScope();
            
        }
        
    }
}