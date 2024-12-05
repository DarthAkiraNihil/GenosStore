using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class CPUCoolerService: ICPUCoolerService {
        private IGenosStoreRepositories _repositories;

        public CPUCoolerService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(CPUCooler item) {
            _repositories.Items.ComputerComponents.CPUCoolers.Create(item);
        }

        public CPUCooler Get(int id) {
            return _repositories.Items.ComputerComponents.CPUCoolers.Get(id);
        }

        public List<CPUCooler> List() {
            return _repositories.Items.ComputerComponents.CPUCoolers.List();
        }

        public void Update(CPUCooler item) {
            _repositories.Items.ComputerComponents.CPUCoolers.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ComputerComponents.CPUCoolers.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public List<CPUCooler> Filter(List<Func<CPUCooler, bool>> filters) {
            var result = List();
            foreach (var filter in filters) {
                result = result.Where(filter).ToList();
            }
            return result;
        }
    }
}