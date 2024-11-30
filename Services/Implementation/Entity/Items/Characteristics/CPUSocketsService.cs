using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class CPUSocketsService: ICPUSocketService {
        private IGenosStoreRepositories _repositories;

        public CPUSocketsService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(CPUSocket item) {
            _repositories.Items.Characteristics.CPUSockets.Create(item);
        }

        public CPUSocket Get(int id) {
            return _repositories.Items.Characteristics.CPUSockets.Get(id);
        }

        public List<CPUSocket> List() {
            return _repositories.Items.Characteristics.CPUSockets.List();
        }

        public void Update(CPUSocket item) {
            _repositories.Items.Characteristics.CPUSockets.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.CPUSockets.Delete(id);
        }

        public CPUSocket GetFromString(string value) {
            return _repositories.Items.Characteristics.CPUSockets.List().FirstOrDefault(i => i.Name == value);
        }
        
        public int Save() {
            return _repositories.Save();
        }
    }
}