using GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules.ServiceModules {
    public class ItemSimpleComputerComponentsModule: NinjectModule {
        public override void Load() {
            
            Bind<ICPUCoreService>().To<CPUCoresService>();
            Bind<IGPUService>().To<GPUService>();
            Bind<ISimpleComputerComponentService>().To<SimpleComputerComponentsService>();
            
        }
    }
}