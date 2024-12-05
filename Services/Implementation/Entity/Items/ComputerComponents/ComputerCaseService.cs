using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items.ComputerComponents {
    public class ComputerCaseService: IComputerCaseService {
        private IGenosStoreRepositories _repositories;

        public ComputerCaseService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(ComputerCase item) {
            _repositories.Items.ComputerComponents.ComputerCases.Create(item);
        }

        public ComputerCase Get(int id) {
            return _repositories.Items.ComputerComponents.ComputerCases.Get(id);
        }

        public List<ComputerCase> List() {
            return _repositories.Items.ComputerComponents.ComputerCases.List();
        }

        public void Update(ComputerCase item) {
            _repositories.Items.ComputerComponents.ComputerCases.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.ComputerComponents.ComputerCases.Delete(id);
        }

        public List<ComputerCase> Filter(List<Func<ComputerCase, bool>> filters) {
            var result = List();
            foreach (var filter in filters) {
                result = result.Where(filter).ToList();
            }
            return result;
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}