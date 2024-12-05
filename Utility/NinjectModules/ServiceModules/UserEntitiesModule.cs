using GenosStore.Services.Implementation.Entity.Users;
using GenosStore.Services.Interface.Entity.Users;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules.ServiceModules {
    public class UserEntitiesModule: NinjectModule {
        public override void Load() {
            
            Bind<IUserService>().To<UserService>().InSingletonScope();
            
        }
    }
}