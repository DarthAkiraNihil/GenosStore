using System.Collections.Generic;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents {
    public class SSDControllerService: ISSDControllerService {
        private IGenosStoreRepositories _repositories;

        public SSDControllerService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(SSDController item) {
            _repositories.Items.SimpleComputerComponents.SSDControllers.Create(item);
        }

        public SSDController Get(int id) {
            return _repositories.Items.SimpleComputerComponents.SSDControllers.Get(id);
        }

        public List<SSDController> List() {
            return _repositories.Items.SimpleComputerComponents.SSDControllers.List();
        }

        public void Update(SSDController item) {
            _repositories.Items.SimpleComputerComponents.SSDControllers.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.SimpleComputerComponents.SSDControllers.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}