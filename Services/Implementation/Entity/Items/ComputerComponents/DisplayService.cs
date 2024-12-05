using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class DisplayService: IDisplayService {
        private IGenosStoreRepositories _repositories;

        public DisplayService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(Display item) {
            _repositories.Items.ComputerComponents.Displays.Create(item);
        }

        public Display Get(int id) {
            return _repositories.Items.ComputerComponents.Displays.Get(id);
        }

        public List<Display> List() {
            return _repositories.Items.ComputerComponents.Displays.List();
        }

        public void Update(Display item) {
            _repositories.Items.ComputerComponents.Displays.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ComputerComponents.Displays.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public List<Display> Filter(List<Func<Display, bool>> filters) {
            var result = List();
            foreach (var filter in filters) {
                result = result.Where(filter).ToList();
            }
            return result;
        }
    }
}