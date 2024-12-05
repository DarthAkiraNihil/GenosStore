using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class KeyboardTypeService: IKeyboardTypeService {
        private IGenosStoreRepositories _repositories;

        public KeyboardTypeService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(KeyboardType item) {
            _repositories.Items.Characteristics.KeyboardTypes.Create(item);
        }

        public KeyboardType Get(int id) {
            return _repositories.Items.Characteristics.KeyboardTypes.Get(id);
        }

        public List<KeyboardType> List() {
            return _repositories.Items.Characteristics.KeyboardTypes.List();
        }

        public void Update(KeyboardType item) {
            _repositories.Items.Characteristics.KeyboardTypes.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.KeyboardTypes.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public KeyboardType GetFromString(string value) {
            return _repositories.Items.Characteristics.KeyboardTypes.List().FirstOrDefault(i => i.Name == value);
        }
    }
}