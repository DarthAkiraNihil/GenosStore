using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Orders;

namespace GenosStore.Services.Implementation.Entity.Orders {
    public class BankSystemService: IBankSystemService {
        private IGenosStoreRepositories _repositories;

        public BankSystemService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(BankSystem item) {
            _repositories.Orders.BankSystems.Create(item);
        }

        public BankSystem Get(int id) {
            return _repositories.Orders.BankSystems.Get(id);
        }

        public List<BankSystem> List() {
            return _repositories.Orders.BankSystems.List();
        }

        public void Update(BankSystem item) {
            _repositories.Orders.BankSystems.Update(item);
        }

        public void Delete(int id) {
            _repositories.Orders.BankSystems.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }

        public BankSystem GetFromString(string value) {
            return _repositories.Orders.BankSystems.List().FirstOrDefault(i => i.Name == value);
        }
    }
}