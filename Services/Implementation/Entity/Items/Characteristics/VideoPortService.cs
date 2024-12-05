using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class VideoPortService: IVideoPortService {
        private IGenosStoreRepositories _repositories;

        public VideoPortService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(VideoPort item) {
            _repositories.Items.Characteristics.VideoPorts.Create(item);
        }

        public VideoPort Get(int id) {
            return _repositories.Items.Characteristics.VideoPorts.Get(id);
        }

        public List<VideoPort> List() {
            return _repositories.Items.Characteristics.VideoPorts.List();
        }

        public void Update(VideoPort item) {
            _repositories.Items.Characteristics.VideoPorts.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.VideoPorts.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public VideoPort GetFromString(string value) {
            return _repositories.Items.Characteristics.VideoPorts.List().FirstOrDefault(i => i.Name == value);
        }
    }
}