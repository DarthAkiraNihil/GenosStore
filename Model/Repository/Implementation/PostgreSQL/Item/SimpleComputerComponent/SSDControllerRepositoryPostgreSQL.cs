using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent {
    public class SSDControllerRepositoryPostgreSQL: ISSDControllerRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public SSDControllerRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<SSDController> List() {
            return _context.SSDControllers.ToList();
        }

        public SSDController Get(int id) {
            return _context.SSDControllers.Find(id);
        }

        public void Create(SSDController ssdController) {
            _context.SSDControllers.Add(ssdController);
        }

        public void Update(SSDController ssdController) {
            _context.Entry(ssdController).State = EntityState.Modified;
        }

        public void Delete(int id) {
            SSDController ssdController = _context.SSDControllers.Find(id);
            if (ssdController != null)
                _context.SSDControllers.Remove(ssdController);
        }
        
    }
}