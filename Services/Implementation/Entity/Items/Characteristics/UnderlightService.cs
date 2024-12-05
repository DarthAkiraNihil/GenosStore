using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class UnderlightService: IUnderlightService {
        private IGenosStoreRepositories _repositories;

        public UnderlightService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(Underlight item) {
            _repositories.Items.Characteristics.Underlights.Create(item);
        }

        public Underlight Get(int id) {
            return _repositories.Items.Characteristics.Underlights.Get(id);
        }

        public List<Underlight> List() {
            return _repositories.Items.Characteristics.Underlights.List();
        }

        public void Update(Underlight item) {
            _repositories.Items.Characteristics.Underlights.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.Underlights.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public Underlight GetFromString(string value) {
            return _repositories.Items.Characteristics.Underlights.List().FirstOrDefault(i => i.Name == value);
        }
    }
}