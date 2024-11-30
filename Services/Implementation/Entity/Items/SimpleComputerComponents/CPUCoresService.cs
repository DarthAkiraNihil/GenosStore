using System.Collections.Generic;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents {
    public class CPUCoresService: ICPUCoreService {
        private IGenosStoreRepositories _repositories;

        public CPUCoresService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(CPUCore item) {
            _repositories.Items.SimpleComputerComponents.CPUCores.Create(item);
        }

        public CPUCore Get(int id) {
            return _repositories.Items.SimpleComputerComponents.CPUCores.Get(id);
        }

        public List<CPUCore> List() {
            return _repositories.Items.SimpleComputerComponents.CPUCores.List();
        }

        public void Update(CPUCore item) {
            _repositories.Items.SimpleComputerComponents.CPUCores.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.SimpleComputerComponents.CPUCores.Delete(id);
        }
        
        public int Save() {
            return _repositories.Save();
        }
    }
}