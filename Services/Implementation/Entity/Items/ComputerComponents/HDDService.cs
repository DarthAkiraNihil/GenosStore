using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class HDDService: IHDDService {
        private IGenosStoreRepositories _repositories;

        public HDDService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(HDD item) {
            _repositories.Items.ComputerComponents.HDDs.Create(item);
        }

        public HDD Get(int id) {
            return _repositories.Items.ComputerComponents.HDDs.Get(id);
        }

        public List<HDD> List() {
            return _repositories.Items.ComputerComponents.HDDs.List();
        }

        public void Update(HDD item) {
            _repositories.Items.ComputerComponents.HDDs.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ComputerComponents.HDDs.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public List<HDD> Filter(List<Func<HDD, bool>> filters) {
            var result = List();
            foreach (var filter in filters) {
                result = result.Where(filter).ToList();
            }
            return result;
        }
    }
}