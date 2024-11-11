using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class CPUSocketRepositoryPostgreSQL: ICPUSocketRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public CPUSocketRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<CPUSocket> List() {
            return _context.CPUSockets.ToList();
        }

        public CPUSocket Get(int id) {
            return _context.CPUSockets.Find(id);
        }

        public void Create(CPUSocket cpuSocket) {
            _context.CPUSockets.Add(cpuSocket);
        }

        public void Update(CPUSocket cpuSocket) {
            _context.Entry(cpuSocket).State = EntityState.Modified;
        }

        public void Delete(int id) {
            CPUSocket cpuSocket = _context.CPUSockets.Find(id);
            if (cpuSocket != null)
                _context.CPUSockets.Remove(cpuSocket);
        }
        
    }
}