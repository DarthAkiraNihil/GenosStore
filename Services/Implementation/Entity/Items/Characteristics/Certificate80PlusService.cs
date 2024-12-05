using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class Certificate80PlusService: ICertificate80PlusService {
        private IGenosStoreRepositories _repositories;

        public Certificate80PlusService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(Certificate80Plus item) {
            _repositories.Items.Characteristics.Certificates80Plus.Create(item);
        }

        public Certificate80Plus Get(int id) {
            return _repositories.Items.Characteristics.Certificates80Plus.Get(id);
        }

        public List<Certificate80Plus> List() {
            return _repositories.Items.Characteristics.Certificates80Plus.List();
        }

        public void Update(Certificate80Plus item) {
            _repositories.Items.Characteristics.Certificates80Plus.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.Certificates80Plus.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public Certificate80Plus GetFromString(string value) {
            return _repositories.Items.Characteristics.Certificates80Plus.List().FirstOrDefault(i => i.Name == value);
        }
    }
}