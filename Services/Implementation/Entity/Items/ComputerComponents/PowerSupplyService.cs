using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class PowerSupplyService: IPowerSupplyService {
        private IGenosStoreRepositories _repositories;

        public PowerSupplyService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(PowerSupply item) {
            _repositories.Items.ComputerComponents.PowerSupplies.Create(item);
        }

        public PowerSupply Get(int id) {
            return _repositories.Items.ComputerComponents.PowerSupplies.Get(id);
        }

        public List<PowerSupply> List() {
            return _repositories.Items.ComputerComponents.PowerSupplies.List();
        }

        public void Update(PowerSupply item) {
            _repositories.Items.ComputerComponents.PowerSupplies.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ComputerComponents.PowerSupplies.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public List<PowerSupply> Filter(List<Func<PowerSupply, bool>> filters) {
            var result = List();
            foreach (var filter in filters) {
                result = result.Where(filter).ToList();
            }
            return result;
        }
    }
}