using System.Collections.Generic;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents {
    public class MotherboardChipsetService: IMotherboardChipsetService {
        private IGenosStoreRepositories _repositories;

        public MotherboardChipsetService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(MotherboardChipset item) {
            _repositories.Items.SimpleComputerComponents.MotherboardChipsets.Create(item);
        }

        public MotherboardChipset Get(int id) {
            return _repositories.Items.SimpleComputerComponents.MotherboardChipsets.Get(id);
        }

        public List<MotherboardChipset> List() {
            return _repositories.Items.SimpleComputerComponents.MotherboardChipsets.List();
        }

        public void Update(MotherboardChipset item) {
            _repositories.Items.SimpleComputerComponents.MotherboardChipsets.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.SimpleComputerComponents.MotherboardChipsets.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}