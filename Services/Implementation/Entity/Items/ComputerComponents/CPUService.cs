using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class CPUService: ICPUService {
        private IGenosStoreRepositories _repositories;

        public CPUService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(CPU item) {
            _repositories.Items.ComputerComponents.CPUs.Create(item);
        }

        public CPU Get(int id) {
            return _repositories.Items.ComputerComponents.CPUs.Get(id);
        }

        public List<CPU> List() {
            return _repositories.Items.ComputerComponents.CPUs.List();
        }

        public void Update(CPU item) {
            _repositories.Items.ComputerComponents.CPUs.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ComputerComponents.CPUs.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public List<CPU> Filter(List<Func<CPU, bool>> filters) {
            var result = List();
            foreach (var filter in filters) {
                result = result.Where(filter).ToList();
            }
            return result;
        }
    }
}