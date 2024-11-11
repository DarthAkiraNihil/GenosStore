using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class NVMeSSDRepositoryPostgreSQL: INVMeSSDRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public NVMeSSDRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<NVMeSSD> List() {
            return _context.NVMeSSDs.ToList();
        }

        public NVMeSSD Get(int id) {
            return _context.NVMeSSDs.Find(id);
        }

        public void Create(NVMeSSD nvmeSSD) {
            _context.NVMeSSDs.Add(nvmeSSD);
        }

        public void Update(NVMeSSD nvmeSSD) {
            _context.Entry(nvmeSSD).State = EntityState.Modified;
        }

        public void Delete(int id) {
            NVMeSSD nvmeSSD = _context.NVMeSSDs.Find(id);
            if (nvmeSSD != null)
                _context.NVMeSSDs.Remove(nvmeSSD);
        }
        
    }
}