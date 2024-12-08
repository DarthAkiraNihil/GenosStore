using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items;

namespace GenosStore.Services.Implementation.Entity.Items {
    public class ItemTypesService: IItemTypeService {
        private IGenosStoreRepositories _repositories;

        public ItemTypesService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(ItemType item) {
            _repositories.Items.ItemTypes.Create(item);
        }

        public ItemType Get(int id) {
            return _repositories.Items.ItemTypes.Get(id);
        }

        public List<ItemType> List() {
            return _repositories.Items.ItemTypes.List();
        }

        public void Update(ItemType item) {
            _repositories.Items.ItemTypes.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ItemTypes.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public ItemType GetFromString(string value) {
            return _repositories.Items.ItemTypes.List().FirstOrDefault(i => i.Name == value);
        }
    }
}