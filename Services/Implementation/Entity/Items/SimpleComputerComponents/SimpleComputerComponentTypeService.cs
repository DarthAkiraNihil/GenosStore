using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents {
    public class SimpleComputerComponentTypeService: ISimpleComputerComponentTypeService {
        private IGenosStoreRepositories _repositories;

        public SimpleComputerComponentTypeService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(SimpleComputerComponentType item) {
            _repositories.Items.SimpleComputerComponents.SimpleComputerComponentTypes.Create(item);
        }

        public SimpleComputerComponentType Get(int id) {
            return _repositories.Items.SimpleComputerComponents.SimpleComputerComponentTypes.Get(id);
        }

        public List<SimpleComputerComponentType> List() {
            return _repositories.Items.SimpleComputerComponents.SimpleComputerComponentTypes.List();
        }

        public void Update(SimpleComputerComponentType item) {
            _repositories.Items.SimpleComputerComponents.SimpleComputerComponentTypes.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.SimpleComputerComponents.SimpleComputerComponentTypes.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }

        public SimpleComputerComponentType GetFromString(string value) {
            return _repositories.Items.SimpleComputerComponents.SimpleComputerComponentTypes.List().FirstOrDefault(i => i.Name == value);
        }
    }
}