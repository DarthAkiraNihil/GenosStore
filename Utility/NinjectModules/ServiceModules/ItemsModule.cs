using GenosStore.Services.Implementation.Entity.Items;
using GenosStore.Services.Implementation.Entity.Items.ComputerComponents;
using GenosStore.Services.Interface.Entity.Items;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules.ServiceModules {
    public class ItemsModule: NinjectModule {
        public override void Load() {

            Bind<IComputerCaseService>().To<ComputerCaseService>().InSingletonScope();
            Bind<ICPUCoolerService>().To<CPUCoolerService>().InSingletonScope();
            Bind<ICPUService>().To<CPUService>().InSingletonScope();
            Bind<IDisplayService>().To<DisplayService>().InSingletonScope();
            Bind<IGraphicsCardService>().To<GraphicsCardService>().InSingletonScope();
            Bind<IHDDService>().To<HDDService>().InSingletonScope();
            Bind<IKeyboardService>().To<KeyboardService>().InSingletonScope();
            Bind<IMouseService>().To<MouseService>().InSingletonScope();
            Bind<INVMeSSDService>().To<NVMeSSDService>().InSingletonScope();
            Bind<IPowerSupplyService>().To<PowerSupplyService>().InSingletonScope();
            Bind<IRAMService>().To<RAMService>().InSingletonScope();
            Bind<ISataSSDService>().To<SataSSDService>().InSingletonScope();
            Bind<IMotherboardService>().To<MotherboardService>().InSingletonScope();
            Bind<IComputerComponentServices>().To<ComputerComponentServices>().InSingletonScope();
            Bind<IAllItemsService>().To<AllItemsService>();
            
        }
    }
}