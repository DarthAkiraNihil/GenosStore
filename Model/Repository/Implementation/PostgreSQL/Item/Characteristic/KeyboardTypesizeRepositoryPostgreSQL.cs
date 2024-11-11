using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class KeyboardTypesizeRepositoryPostgreSQL: IKeyboardTypesizeRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public KeyboardTypesizeRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<KeyboardTypesize> List() {
            return _context.KeyboardTypesizes.ToList();
        }

        public KeyboardTypesize Get(int id) {
            return _context.KeyboardTypesizes.Find(id);
        }

        public void Create(KeyboardTypesize keyboardTypesize) {
            _context.KeyboardTypesizes.Add(keyboardTypesize);
        }

        public void Update(KeyboardTypesize keyboardTypesize) {
            _context.Entry(keyboardTypesize).State = EntityState.Modified;
        }

        public void Delete(int id) {
            KeyboardTypesize keyboardTypesize = _context.KeyboardTypesizes.Find(id);
            if (keyboardTypesize != null)
                _context.KeyboardTypesizes.Remove(keyboardTypesize);
        }
        
    }
}