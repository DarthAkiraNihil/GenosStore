using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class MouseRepositoryPostgreSQL: IMouseRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public MouseRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Mouse> List() {
            return _context.Mouses.ToList();
        }

        public Mouse Get(int id) {
            return _context.Mouses.Find(id);
        }

        public void Create(Mouse mouse) {
            _context.Mouses.Add(mouse);
        }

        public void Update(Mouse mouse) {
            _context.Entry(mouse).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Mouse mouse = _context.Mouses.Find(id);
            if (mouse != null)
                _context.Mouses.Remove(mouse);
        }
        
    }
}