using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class PCIEVersionRepositoryPostgreSQL: IPCIEVersionRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public PCIEVersionRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<PCIEVersion> List() {
            return _context.PCIEVersions.ToList();
        }

        public PCIEVersion Get(int id) {
            return _context.PCIEVersions.Find(id);
        }

        public void Create(PCIEVersion pcieVersion) {
            _context.PCIEVersions.Add(pcieVersion);
        }

        public void Update(PCIEVersion pcieVersion) {
            _context.Entry(pcieVersion).State = EntityState.Modified;
        }

        public void Delete(int id) {
            PCIEVersion pcieVersion = _context.PCIEVersions.Find(id);
            if (pcieVersion != null)
                _context.PCIEVersions.Remove(pcieVersion);
        }
        
    }
}