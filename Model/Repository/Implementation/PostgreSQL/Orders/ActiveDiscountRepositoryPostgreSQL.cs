using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface.Orders;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Orders {
    public class ActiveDiscountRepositoryPostgreSQL: IActiveDiscountRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public ActiveDiscountRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<ActiveDiscount> List() {
            return _context.ActiveDiscounts.ToList();
        }

        public ActiveDiscount Get(int id) {
            return _context.ActiveDiscounts.Find(id);
        }

        public void Create(ActiveDiscount activeDiscount) {
            _context.ActiveDiscounts.Add(activeDiscount);
        }

        public void Update(ActiveDiscount activeDiscount) {
            _context.Entry(activeDiscount).State = EntityState.Modified;
        }

        public void Delete(int id) {
            ActiveDiscount activeDiscount = _context.ActiveDiscounts.Find(id);
            if (activeDiscount != null)
                _context.ActiveDiscounts.Remove(activeDiscount);
        }
        
    }
}