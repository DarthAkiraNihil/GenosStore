using GenosStore.Services.Implementation.Entity;
using GenosStore.Services.Implementation.Entity.Items;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Entity;
using GenosStore.Services.Interface.Entity.Items;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules {
    public class ServicesModule: NinjectModule {
        
        public override void Load() {
            
            Bind<IPreparedAssemblyService>().To<PreparedAssemblyService>().InSingletonScope();

            Bind<IItemTypeService>().To<ItemTypesService>().InSingletonScope();
            Bind<IItemServices>().To<ItemServices>().InSingletonScope();

            Bind<IEntityServices>().To<EntityServices>();
            
            Bind<IServices>().To<Services.Implementation.Services>().InSingletonScope();
            
        }
        
    }
}