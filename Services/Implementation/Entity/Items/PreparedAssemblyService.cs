using System.Collections.Generic;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items;

namespace GenosStore.Services.Implementation.Entity.Items {
    public class PreparedAssemblyService: IPreparedAssemblyService {
        private IGenosStoreRepositories _repositories;

        public PreparedAssemblyService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(PreparedAssembly item) {
            _repositories.Items.PreparedAssemblies.Create(item);
        }

        public PreparedAssembly Get(int id) {
            return _repositories.Items.PreparedAssemblies.Get(id);
        }

        public List<PreparedAssembly> List() {
            return _repositories.Items.PreparedAssemblies.List();
        }

        public void Update(PreparedAssembly item) {
            _repositories.Items.PreparedAssemblies.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.PreparedAssemblies.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}