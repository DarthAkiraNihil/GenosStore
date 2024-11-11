using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Repository.Interface.Item;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item {
    public class PreparedAssemblyRepositoryPostgreSQL: IPreparedAssemblyRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public PreparedAssemblyRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Entity.Item.PreparedAssembly> List() {
            return _context.PreparedAssemblies.ToList();
        }

        public Entity.Item.PreparedAssembly Get(int id) {
            return _context.PreparedAssemblies.Find(id);
        }

        public void Create(Entity.Item.PreparedAssembly preparedAssembly) {
            _context.PreparedAssemblies.Add(preparedAssembly);
        }

        public void Update(Entity.Item.PreparedAssembly preparedAssembly) {
            _context.Entry(preparedAssembly).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Entity.Item.PreparedAssembly preparedAssembly = _context.PreparedAssemblies.Find(id);
            if (preparedAssembly != null)
                _context.PreparedAssemblies.Remove(preparedAssembly);
        }
        
    }
}