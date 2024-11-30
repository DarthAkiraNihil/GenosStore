using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class RAMTypesService: IRAMTypeService {
        private IGenosStoreRepositories _repositories;

        public void Create(RAMType item) {
            _repositories.Items.Characteristics.RAMTypes.Create(item);
        }

        public RAMType Get(int id) {
            return _repositories.Items.Characteristics.RAMTypes.Get(id);
        }

        public List<RAMType> List() {
            return _repositories.Items.Characteristics.RAMTypes.List();
        }

        public void Update(RAMType item) {
            _repositories.Items.Characteristics.RAMTypes.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.RAMTypes.Delete(id);
        }

        public RAMTypesService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public RAMType GetFromString(string value) {
            return _repositories.Items.Characteristics.RAMTypes.List().FirstOrDefault(i => i.Name == value);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}