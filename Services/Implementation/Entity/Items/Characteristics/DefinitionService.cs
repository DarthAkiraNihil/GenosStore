using System.Collections.Generic;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class DefinitionService: IDefinitionService {
        private IGenosStoreRepositories _repositories;

        public DefinitionService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(Definition item) {
            _repositories.Items.Characteristics.Definitions.Create(item);
        }

        public Definition Get(int id) {
            return _repositories.Items.Characteristics.Definitions.Get(id);
        }

        public List<Definition> List() {
            return _repositories.Items.Characteristics.Definitions.List();
        }

        public void Update(Definition item) {
            _repositories.Items.Characteristics.Definitions.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.Definitions.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}