using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class DefinitionRepositoryPostgreSQL: IDefinitionRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public DefinitionRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Definition> List() {
            return _context.Definitions.ToList();
        }

        public Definition Get(int id) {
            return _context.Definitions.Find(id);
        }

        public void Create(Definition definition) {
            _context.Definitions.Add(definition);
        }

        public void Update(Definition definition) {
            _context.Entry(definition).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Definition definition = _context.Definitions.Find(id);
            if (definition != null)
                _context.Definitions.Remove(definition);
        }
        
    }
}