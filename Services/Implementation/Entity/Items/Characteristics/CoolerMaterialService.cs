using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class CoolerMaterialService: ICoolerMaterialService {
        private IGenosStoreRepositories _repositories;
        
        public CoolerMaterialService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(CoolerMaterial item) {
            _repositories.Items.Characteristics.CoolerMaterials.Create(item);
        }

        public CoolerMaterial Get(int id) {
            return _repositories.Items.Characteristics.CoolerMaterials.Get(id);
        }

        public List<CoolerMaterial> List() {
            return _repositories.Items.Characteristics.CoolerMaterials.List();
        }

        public void Update(CoolerMaterial item) {
            _repositories.Items.Characteristics.CoolerMaterials.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.CoolerMaterials.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public CoolerMaterial GetFromString(string value) {
            return _repositories.Items.Characteristics.CoolerMaterials.List().FirstOrDefault(i => i.Name == value);
        }
    }
}