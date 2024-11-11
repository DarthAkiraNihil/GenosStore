using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class DPIModeRepositoryPostgreSQL: IDPIModeRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public DPIModeRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<DPIMode> List() {
            return _context.DPIModes.ToList();
        }

        public DPIMode Get(int id) {
            return _context.DPIModes.Find(id);
        }

        public void Create(DPIMode dpiMode) {
            _context.DPIModes.Add(dpiMode);
        }

        public void Update(DPIMode dpiMode) {
            _context.Entry(dpiMode).State = EntityState.Modified;
        }

        public void Delete(int id) {
            DPIMode dpiMode = _context.DPIModes.Find(id);
            if (dpiMode != null)
                _context.DPIModes.Remove(dpiMode);
        }
        
    }
}