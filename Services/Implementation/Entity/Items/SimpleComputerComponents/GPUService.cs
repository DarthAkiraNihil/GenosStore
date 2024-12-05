using System.Collections.Generic;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents {
    public class GPUService: IGPUService {
        private IGenosStoreRepositories _repositories;

        public GPUService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(GPU item) {
            _repositories.Items.SimpleComputerComponents.GPUs.Create(item);
        }

        public GPU Get(int id) {
            return _repositories.Items.SimpleComputerComponents.GPUs.Get(id);
        }

        public List<GPU> List() {
            return _repositories.Items.SimpleComputerComponents.GPUs.List();
        }

        public void Update(GPU item) {
            _repositories.Items.SimpleComputerComponents.GPUs.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.SimpleComputerComponents.GPUs.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}