using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class ComputerCaseTypesizesServive: IComputerCaseTypesizeService {
        private IGenosStoreRepositories _repositories;

        public ComputerCaseTypesizesServive(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(ComputerCaseTypesize item) {
            _repositories.Items.Characteristics.ComputerCaseTypesizes.Create(item);
        }

        public ComputerCaseTypesize Get(int id) {
            return _repositories.Items.Characteristics.ComputerCaseTypesizes.Get(id);
        }

        public List<ComputerCaseTypesize> List() {
            return _repositories.Items.Characteristics.ComputerCaseTypesizes.List();
        }

        public void Update(ComputerCaseTypesize item) {
            _repositories.Items.Characteristics.ComputerCaseTypesizes.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.ComputerCaseTypesizes.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public ComputerCaseTypesize GetFromString(string value) {
            return _repositories.Items.Characteristics.ComputerCaseTypesizes.List().FirstOrDefault(i => i.Name == value);
        }
    }
}