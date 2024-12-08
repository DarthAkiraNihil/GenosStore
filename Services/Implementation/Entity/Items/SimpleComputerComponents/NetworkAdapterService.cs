using System.Collections.Generic;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents {
    public class NetworkAdapterService: INetworkAdapterService {
        private IGenosStoreRepositories _repositories;

        public NetworkAdapterService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(NetworkAdapter item) {
            _repositories.Items.SimpleComputerComponents.NetworkAdapters.Create(item);
        }

        public NetworkAdapter Get(int id) {
            return _repositories.Items.SimpleComputerComponents.NetworkAdapters.Get(id);
        }

        public List<NetworkAdapter> List() {
            return _repositories.Items.SimpleComputerComponents.NetworkAdapters.List();
        }

        public void Update(NetworkAdapter item) {
            _repositories.Items.SimpleComputerComponents.NetworkAdapters.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.SimpleComputerComponents.NetworkAdapters.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}