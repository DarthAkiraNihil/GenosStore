using GenosStore.Services.Implementation.Customer;
using GenosStore.Services.Implementation.Entity.Users;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity.Users;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules {
    public class ServicesModule: NinjectModule {
        
        public override void Load() {
            
            Bind<IAuthorizationService>().To<AuthorizationService>();
            Bind<ICommonServices>().To<CommonServices>();
            Bind<IUserService>().To<UserService>();
            Bind<IServices>().To<Services.Implementation.Services>().InSingletonScope();
            
        }
        
    }
}