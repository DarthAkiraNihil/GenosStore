using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class RAMRepositoryPostgreSQL: IRAMRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public RAMRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<RAM> List() {
            return _context.RAMs.ToList();
        }

        public RAM Get(int id) {
            return _context.RAMs.Find(id);
        }

        public void Create(RAM ram) {
            _context.RAMs.Add(ram);
        }

        public void Update(RAM ram) {
            _context.Entry(ram).State = EntityState.Modified;
        }

        public void Delete(int id) {
            RAM ram = _context.RAMs.Find(id);
            if (ram != null)
                _context.RAMs.Remove(ram);
        }
        
    }
}