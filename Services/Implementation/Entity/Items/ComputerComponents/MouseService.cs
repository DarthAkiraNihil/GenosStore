using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class MouseService: IMouseService {
        private IGenosStoreRepositories _repositories;

        public MouseService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(Mouse item) {
            _repositories.Items.ComputerComponents.Mouses.Create(item);
        }

        public Mouse Get(int id) {
            return _repositories.Items.ComputerComponents.Mouses.Get(id);
        }

        public List<Mouse> List() {
            return _repositories.Items.ComputerComponents.Mouses.List();
        }

        public void Update(Mouse item) {
            _repositories.Items.ComputerComponents.Mouses.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ComputerComponents.Mouses.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public List<Mouse> Filter(List<Func<Mouse, bool>> filters) {
            var result = List();
            foreach (var filter in filters) {
                result = result.Where(filter).ToList();
            }
            return result;
        }
    }
}