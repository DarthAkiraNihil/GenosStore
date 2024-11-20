using GenosStore.Services.Implementation.Common;
using GenosStore.Services.Implementation.Entity;
using GenosStore.Services.Implementation.Entity.Items;
using GenosStore.Services.Implementation.Entity.Items.ComputerComponents;
using GenosStore.Services.Implementation.Entity.Users;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity;
using GenosStore.Services.Interface.Entity.Items;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;
using GenosStore.Services.Interface.Entity.Users;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules {
    public class ServicesModule: NinjectModule {
        
        public override void Load() {
            
            Bind<IMotherboardService>().To<MotherboardService>();
            Bind<IComputerComponentServices>().To<ComputerComponentServices>();
            Bind<IItemServices>().To<ItemServices>();
            Bind<IEntityServices>().To<EntityServices>();
            Bind<IAuthorizationService>().To<AuthorizationService>();
            Bind<ICommonServices>().To<CommonServices>();
            Bind<IUserService>().To<UserService>();
            Bind<IServices>().To<Services.Implementation.Services>().InSingletonScope();
            
        }
        
    }
}