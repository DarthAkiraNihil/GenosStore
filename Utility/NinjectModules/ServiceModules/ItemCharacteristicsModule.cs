using GenosStore.Services.Implementation.Entity.Items.Characteristics;
using GenosStore.Services.Interface.Entity.Items.Characteristics;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules.ServiceModules {
    public class ItemCharacteristicsModule: NinjectModule {
        public override void Load() {
            
            Bind<ICertificate80PlusService>().To<Certificate80PlusService>().InSingletonScope();
            Bind<IComputerCaseTypesizeService>().To<ComputerCaseTypesizesServive>().InSingletonScope();
            Bind<ICoolerMaterialService>().To<CoolerMaterialService>().InSingletonScope();
            Bind<ICPUSocketService>().To<CPUSocketsService>().InSingletonScope();
            Bind<IDefinitionService>().To<DefinitionService>().InSingletonScope();
            Bind<IDPIModeService>().To<DPIModeService>().InSingletonScope();
            Bind<IKeyboardTypeService>().To<KeyboardTypeService>().InSingletonScope();
            Bind<IKeyboardTypesizeService>().To<KeyboardTypesizeService>().InSingletonScope();
            Bind<IMatrixTypeService>().To<MatrixTypeService>().InSingletonScope();
            Bind<IMotherboardFormFactorService>().To<MotherboardFormFactorsService>().InSingletonScope();
            Bind<IRAMTypeService>().To<RAMTypesService>().InSingletonScope();
            Bind<IUnderlightService>().To<UnderlightService>().InSingletonScope();
            Bind<IVendorService>().To<VendorsService>().InSingletonScope();
            Bind<IVesaSizeService>().To<VesaSizeService>().InSingletonScope();
            Bind<IVideoPortService>().To<VideoPortService>().InSingletonScope();
            Bind<ICharacteristicsService>().To<CharacreristicsService>().InSingletonScope();
            
        }
    }
}