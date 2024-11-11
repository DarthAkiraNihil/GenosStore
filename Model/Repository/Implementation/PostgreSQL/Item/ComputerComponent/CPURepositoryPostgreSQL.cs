using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class CPURepositoryPostgreSQL: ICPURepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public CPURepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<CPU> List() {
            return _context.CPUs.ToList();
        }

        public CPU Get(int id) {
            return _context.CPUs.Find(id);
        }

        public void Create(CPU cpu) {
            _context.CPUs.Add(cpu);
        }

        public void Update(CPU cpu) {
            _context.Entry(cpu).State = EntityState.Modified;
        }

        public void Delete(int id) {
            CPU cpu = _context.CPUs.Find(id);
            if (cpu != null)
                _context.CPUs.Remove(cpu);
        }
        
    }
}