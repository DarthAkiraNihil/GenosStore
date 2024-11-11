using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface.Orders;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Orders {
    public class BankCardRepositoryPostgreSQL: IBankCardRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public BankCardRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<BankCard> List() {
            return _context.BankCards.ToList();
        }

        public BankCard Get(int id) {
            return _context.BankCards.Find(id);
        }

        public void Create(BankCard bankCard) {
            _context.BankCards.Add(bankCard);
        }

        public void Update(BankCard bankCard) {
            _context.Entry(bankCard).State = EntityState.Modified;
        }

        public void Delete(int id) {
            BankCard bankCard = _context.BankCards.Find(id);
            if (bankCard != null)
                _context.BankCards.Remove(bankCard);
        }
        
    }
}