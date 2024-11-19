using GenosStore.Model.Repository.Implementation.PostgreSQL;
using GenosStore.Model.Repository.Interface;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules {
    public class RepositoriesModule: NinjectModule {
        
        private readonly string _connectionString;

        public RepositoriesModule(string connectionString) {
            _connectionString = connectionString;
        }

        public override void Load() {
            Bind<IGenosStoreRepositories>().To<GenosStoreRepositoriesPostgreSQL>().InSingletonScope().WithConstructorArgument(_connectionString);
        }
        
    }
}