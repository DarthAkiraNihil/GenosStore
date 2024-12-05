using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class KeyboardTypesizeService: IKeyboardTypesizeService {
        private IGenosStoreRepositories _repositories;

        public KeyboardTypesizeService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(KeyboardTypesize item) {
            _repositories.Items.Characteristics.KeyboardTypesizes.Create(item);
        }

        public KeyboardTypesize Get(int id) {
            return _repositories.Items.Characteristics.KeyboardTypesizes.Get(id);
        }

        public List<KeyboardTypesize> List() {
            return _repositories.Items.Characteristics.KeyboardTypesizes.List();
        }

        public void Update(KeyboardTypesize item) {
            _repositories.Items.Characteristics.KeyboardTypesizes.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.KeyboardTypesizes.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public KeyboardTypesize GetFromString(string value) {
            return _repositories.Items.Characteristics.KeyboardTypesizes.List().FirstOrDefault(i => i.Name == value);
        }
    }
}