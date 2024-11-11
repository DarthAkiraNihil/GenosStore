using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class RAMTypeRepositoryPostgreSQL: IRAMTypeRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public RAMTypeRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<RAMType> List() {
            return _context.RAMTypes.ToList();
        }

        public RAMType Get(int id) {
            return _context.RAMTypes.Find(id);
        }

        public void Create(RAMType ramType) {
            _context.RAMTypes.Add(ramType);
        }

        public void Update(RAMType ramType) {
            _context.Entry(ramType).State = EntityState.Modified;
        }

        public void Delete(int id) {
            RAMType ramType = _context.RAMTypes.Find(id);
            if (ramType != null)
                _context.RAMTypes.Remove(ramType);
        }
        
    }
}