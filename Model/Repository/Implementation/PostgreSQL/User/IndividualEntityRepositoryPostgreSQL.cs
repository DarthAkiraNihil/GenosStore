using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface.User;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.User {
    public class IndividualEntityRepositoryPostgreSQL: IIndividualEntityRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public IndividualEntityRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<IndividualEntity> List() {
            return _context.IndividualEntities.ToList();
        }

        public IndividualEntity Get(int id) {
            return _context.IndividualEntities.Find(id);
        }

        public void Create(IndividualEntity individualEntity) {
            _context.IndividualEntities.Add(individualEntity);
        }

        public void Update(IndividualEntity individualEntity) {
            _context.Entry(individualEntity).State = EntityState.Modified;
        }

        public void Delete(int id) {
            IndividualEntity individualEntity = _context.IndividualEntities.Find(id);
            if (individualEntity != null)
                _context.IndividualEntities.Remove(individualEntity);
        }
        
    }
}