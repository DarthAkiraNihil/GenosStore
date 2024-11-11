using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class UnderlightRepositoryPostgreSQL: IUnderlightRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public UnderlightRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Underlight> List() {
            return _context.Underlights.ToList();
        }

        public Underlight Get(int id) {
            return _context.Underlights.Find(id);
        }

        public void Create(Underlight underlight) {
            _context.Underlights.Add(underlight);
        }

        public void Update(Underlight underlight) {
            _context.Entry(underlight).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Underlight underlight = _context.Underlights.Find(id);
            if (underlight != null)
                _context.Underlights.Remove(underlight);
        }
        
    }
}