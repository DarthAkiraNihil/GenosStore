using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface.User;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.User {
    public class AdministratorRepositoryPostgreSQL: IAdministratorRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public AdministratorRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Administrator> List() {
            return _context.Administrators.ToList();
        }

        public Administrator Get(int id) {
            return _context.Administrators.Find(id);
        }

        public void Create(Administrator administrator) {
            _context.Administrators.Add(administrator);
        }

        public void Update(Administrator administrator) {
            _context.Entry(administrator).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Administrator administrator = _context.Administrators.Find(id);
            if (administrator != null)
                _context.Administrators.Remove(administrator);
        }
        
    }
}