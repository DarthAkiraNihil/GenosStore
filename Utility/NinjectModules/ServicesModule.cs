using GenosStore.Services.Implementation.Customer;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Common;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules {
    public class ServicesModule: NinjectModule {
        
        public override void Load() {
            
            Bind<IAuthorizationService>().To<AuthorizationService>();
            Bind<ICommonServices>().To<CommonServices>();
            Bind<IServices>().To<Services.Implementation.Services>().InSingletonScope();
            
        }
        
    }
}