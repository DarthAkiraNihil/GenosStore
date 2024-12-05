using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class VesaSizeService: IVesaSizeService {
        private IGenosStoreRepositories _repositories;

        public VesaSizeService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(VesaSize item) {
            _repositories.Items.Characteristics.VesaSizes.Create(item);
        }

        public VesaSize Get(int id) {
            return _repositories.Items.Characteristics.VesaSizes.Get(id);
        }

        public List<VesaSize> List() {
            return _repositories.Items.Characteristics.VesaSizes.List();
        }

        public void Update(VesaSize item) {
            _repositories.Items.Characteristics.VesaSizes.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.VesaSizes.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public VesaSize GetFromString(string value) {
            return _repositories.Items.Characteristics.VesaSizes.List().FirstOrDefault(i => i.Name == value);
        }
    }
}