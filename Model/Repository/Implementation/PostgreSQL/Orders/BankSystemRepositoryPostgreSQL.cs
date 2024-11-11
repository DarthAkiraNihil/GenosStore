using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface.Orders;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Orders {
    public class BankSystemRepositoryPostgreSQL: IBankSystemRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public BankSystemRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<BankSystem> List() {
            return _context.BankSystems.ToList();
        }

        public BankSystem Get(int id) {
            return _context.BankSystems.Find(id);
        }

        public void Create(BankSystem bankSystem) {
            _context.BankSystems.Add(bankSystem);
        }

        public void Update(BankSystem bankSystem) {
            _context.Entry(bankSystem).State = EntityState.Modified;
        }

        public void Delete(int id) {
            BankSystem bankSystem = _context.BankSystems.Find(id);
            if (bankSystem != null)
                _context.BankSystems.Remove(bankSystem);
        }
        
    }
}