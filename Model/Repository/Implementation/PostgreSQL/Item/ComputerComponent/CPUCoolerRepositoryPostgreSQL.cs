using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class CPUCoolerRepositoryPostgreSQL: ICPUCoolerRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public CPUCoolerRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<CPUCooler> List() {
            return _context.CPUCoolers.ToList();
        }

        public CPUCooler Get(int id) {
            return _context.CPUCoolers.Find(id);
        }

        public void Create(CPUCooler cpuCooler) {
            _context.CPUCoolers.Add(cpuCooler);
        }

        public void Update(CPUCooler cpuCooler) {
            _context.Entry(cpuCooler).State = EntityState.Modified;
        }

        public void Delete(int id) {
            CPUCooler cpuCooler = _context.CPUCoolers.Find(id);
            if (cpuCooler != null)
                _context.CPUCoolers.Remove(cpuCooler);
        }
        
    }
}