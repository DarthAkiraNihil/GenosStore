using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class KeyboardRepositoryPostgreSQL: IKeyboardRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public KeyboardRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Keyboard> List() {
            return _context.Keyboards.ToList();
        }

        public Keyboard Get(int id) {
            return _context.Keyboards.Find(id);
        }

        public void Create(Keyboard keyboard) {
            _context.Keyboards.Add(keyboard);
        }

        public void Update(Keyboard keyboard) {
            _context.Entry(keyboard).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Keyboard keyboard = _context.Keyboards.Find(id);
            if (keyboard != null)
                _context.Keyboards.Remove(keyboard);
        }
        
    }
}