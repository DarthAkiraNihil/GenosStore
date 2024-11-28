using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class MotherboardService: IMotherboardService {

        private IGenosStoreRepositories _repositories;

        public void Create(Motherboard item) {
            _repositories.Items.ComputerComponents.Motherboards.Create(item);
        }

        public Motherboard Get(int id) {
            return _repositories.Items.ComputerComponents.Motherboards.Get(id);
        }

        public List<Motherboard> List() {
            return _repositories.Items.ComputerComponents.Motherboards.List();
        }

        public void Update(Motherboard item) {
            _repositories.Items.ComputerComponents.Motherboards.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ComputerComponents.Motherboards.Delete(id);
        }

        public List<Motherboard> Filter(List<Func<Motherboard, bool>> filters) {
            var result = _repositories.Items.ComputerComponents.Motherboards.List();
            foreach (var filter in filters) {
                result = result.Where(filter).ToList();
            }
            return result;
        }
        
        public int Save() {
            return _repositories.Save();
        }

        public MotherboardService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }
    }
}