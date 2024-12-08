using GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules.ServiceModules {
    public class ItemSimpleComputerComponentsModule: NinjectModule {
        public override void Load() {
            
            Bind<ICPUCoreService>().To<CPUCoresService>();
            Bind<IGPUService>().To<GPUService>();
            Bind<IAudioChipsetService>().To<AudioChipsetService>();
            Bind<IMotherboardChipsetService>().To<MotherboardChipsetService>();
            Bind<ISSDControllerService>().To<SSDControllerService>();
            Bind<ISimpleComputerComponentTypeService>().To<SimpleComputerComponentTypeService>();
            Bind<INetworkAdapterService>().To<NetworkAdapterService>();
            Bind<ISimpleComputerComponentService>().To<SimpleComputerComponentsService>();
            
        }
    }
}