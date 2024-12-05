using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class RAMService: IRAMService {
        private IGenosStoreRepositories _repositories;

        public RAMService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(RAM item) {
            _repositories.Items.ComputerComponents.RAMs.Create(item);
        }

        public RAM Get(int id) {
            return _repositories.Items.ComputerComponents.RAMs.Get(id);
        }

        public List<RAM> List() {
            return _repositories.Items.ComputerComponents.RAMs.List();
        }

        public void Update(RAM item) {
            _repositories.Items.ComputerComponents.RAMs.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ComputerComponents.RAMs.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public List<RAM> Filter(List<Func<RAM, bool>> filters) {
            var result = List();
            foreach (var filter in filters) {
                result = result.Where(filter).ToList();
            }
            return result;
        }
    }
}