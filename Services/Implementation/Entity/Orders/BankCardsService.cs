using System.Collections.Generic;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Orders;

namespace GenosStore.Services.Implementation.Entity.Orders {
    public class BankCardsService: IBankCardService {
        private IGenosStoreRepositories _repositories;

        public BankCardsService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(BankCard item) {
            _repositories.Orders.BankCards.Create(item);
        }

        public BankCard Get(int id) {
            return _repositories.Orders.BankCards.Get(id);
        }

        public List<BankCard> List() {
            return _repositories.Orders.BankCards.List();
        }

        public void Update(BankCard item) {
            _repositories.Orders.BankCards.Update(item);
        }

        public void Delete(int id) {
            _repositories.Orders.BankCards.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}