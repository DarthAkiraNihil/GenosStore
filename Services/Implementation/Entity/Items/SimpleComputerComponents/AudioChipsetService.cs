using System.Collections.Generic;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.SimpleComputerComponents {
    public class AudioChipsetService: IAudioChipsetService {
        private IGenosStoreRepositories _repositories;

        public AudioChipsetService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(AudioChipset item) {
            _repositories.Items.SimpleComputerComponents.AudioChipsets.Create(item);
        }

        public AudioChipset Get(int id) {
            return _repositories.Items.SimpleComputerComponents.AudioChipsets.Get(id);
        }

        public List<AudioChipset> List() {
            return _repositories.Items.SimpleComputerComponents.AudioChipsets.List();
        }

        public void Update(AudioChipset item) {
            _repositories.Items.SimpleComputerComponents.AudioChipsets.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.SimpleComputerComponents.AudioChipsets.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}