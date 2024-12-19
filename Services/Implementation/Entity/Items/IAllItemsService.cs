using System.Collections.Generic;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Base;
using GenosStore.Services.Interface.Entity.Items;

namespace GenosStore.Services.Implementation.Entity.Items {
    public class AllItemsService: IAllItemsService {
        private IGenosStoreRepositories _repositories;

        public AllItemsService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(Item item) {
            _repositories.Items.All.Create(item);
        }

        public Item Get(int id) {
            return _repositories.Items.All.Get(id);
        }

        public List<Item> List() {
            return _repositories.Items.All.List();
        }

        public void Update(Item item) {
            _repositories.Items.All.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.All.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}