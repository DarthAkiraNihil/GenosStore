using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class KeyboardTypeRepositoryPostgreSQL: IKeyboardTypeRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public KeyboardTypeRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<KeyboardType> List() {
            return _context.KeyboardTypes.ToList();
        }

        public KeyboardType Get(int id) {
            return _context.KeyboardTypes.Find(id);
        }

        public void Create(KeyboardType keyboardType) {
            _context.KeyboardTypes.Add(keyboardType);
        }

        public void Update(KeyboardType keyboardType) {
            _context.Entry(keyboardType).State = EntityState.Modified;
        }

        public void Delete(int id) {
            KeyboardType keyboardType = _context.KeyboardTypes.Find(id);
            if (keyboardType != null)
                _context.KeyboardTypes.Remove(keyboardType);
        }
        
    }
}