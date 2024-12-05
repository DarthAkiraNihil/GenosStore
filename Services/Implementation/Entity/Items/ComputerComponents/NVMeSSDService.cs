using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class NVMeSSDService: INVMeSSDService {
        private IGenosStoreRepositories _repositories;

        public NVMeSSDService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(NVMeSSD item) {
            _repositories.Items.ComputerComponents.NVMeSSDs.Create(item);
        }

        public NVMeSSD Get(int id) {
            return _repositories.Items.ComputerComponents.NVMeSSDs.Get(id);
        }

        public List<NVMeSSD> List() {
            return _repositories.Items.ComputerComponents.NVMeSSDs.List();
        }

        public void Update(NVMeSSD item) {
            _repositories.Items.ComputerComponents.NVMeSSDs.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ComputerComponents.NVMeSSDs.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public List<NVMeSSD> Filter(List<Func<NVMeSSD, bool>> filters) {
            var result = List();
            foreach (var filter in filters) {
                result = result.Where(filter).ToList();
            }
            return result;
        }
    }
}