using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent {
    public class GPURepositoryPostgreSQL: IGPURepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public GPURepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<GPU> List() {
            return _context.GPUs.ToList();
        }

        public GPU Get(int id) {
            return _context.GPUs.Find(id);
        }

        public void Create(GPU gpu) {
            _context.GPUs.Add(gpu);
        }

        public void Update(GPU gpu) {
            _context.Entry(gpu).State = EntityState.Modified;
        }

        public void Delete(int id) {
            GPU gpu = _context.GPUs.Find(id);
            if (gpu != null)
                _context.GPUs.Remove(gpu);
        }
        
    }
}