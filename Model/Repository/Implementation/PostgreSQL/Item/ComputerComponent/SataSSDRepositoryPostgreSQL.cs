using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class SataSSDRepositoryPostgreSQL: ISataSSDRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public SataSSDRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<SataSSD> List() {
            return _context.SataSSDs.ToList();
        }

        public SataSSD Get(int id) {
            return _context.SataSSDs.Find(id);
        }

        public void Create(SataSSD sataSSD) {
            _context.SataSSDs.Add(sataSSD);
        }

        public void Update(SataSSD sataSSD) {
            _context.Entry(sataSSD).State = EntityState.Modified;
        }

        public void Delete(int id) {
            SataSSD sataSSD = _context.SataSSDs.Find(id);
            if (sataSSD != null)
                _context.SataSSDs.Remove(sataSSD);
        }
        
    }
}