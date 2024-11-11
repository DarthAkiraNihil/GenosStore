using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class DisplayRepositoryPostgreSQL: IDisplayRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public DisplayRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Display> List() {
            return _context.Displays.ToList();
        }

        public Display Get(int id) {
            return _context.Displays.Find(id);
        }

        public void Create(Display display) {
            _context.Displays.Add(display);
        }

        public void Update(Display display) {
            _context.Entry(display).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Display display = _context.Displays.Find(id);
            if (display != null)
                _context.Displays.Remove(display);
        }
        
    }
}