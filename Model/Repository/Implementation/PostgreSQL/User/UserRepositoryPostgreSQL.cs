using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Repository.Interface.User;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.User {
    public class UserRepositoryPostgreSQL: IUserRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public UserRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Entity.User.User> List() {
            return _context.Users.ToList();
        }

        public Entity.User.User Get(int id) {
            return _context.Users.Find(id);
        }

        public void Create(Entity.User.User user) {
            _context.Users.Add(user);
        }

        public void Update(Entity.User.User user) {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Entity.User.User user = _context.Users.Find(id);
            if (user != null)
                _context.Users.Remove(user);
        }
        
    }
}