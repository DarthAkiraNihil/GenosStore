using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class MotherboardFormFactorsService: IMotherboardFormFactorService {
        private IGenosStoreRepositories _repositories;

        public MotherboardFormFactorsService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(MotherboardFormFactor item) {
            _repositories.Items.Characteristics.MotherboardFormFactors.Create(item);
        }

        public MotherboardFormFactor Get(int id) {
            return _repositories.Items.Characteristics.MotherboardFormFactors.Get(id);
        }

        public List<MotherboardFormFactor> List() {
            return _repositories.Items.Characteristics.MotherboardFormFactors.List();
        }

        public void Update(MotherboardFormFactor item) {
            _repositories.Items.Characteristics.MotherboardFormFactors.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.MotherboardFormFactors.Delete(id);
        }

        public MotherboardFormFactor GetFromString(string value) {
            return _repositories.Items.Characteristics.MotherboardFormFactors.List().FirstOrDefault(i => i.Name == value);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}