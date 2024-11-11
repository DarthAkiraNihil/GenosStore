using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface.User;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.User {
    public class LegalEntityRepositoryPostgreSQL: ILegalEntityRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public LegalEntityRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<LegalEntity> List() {
            return _context.LegalEntities.ToList();
        }

        public LegalEntity Get(int id) {
            return _context.LegalEntities.Find(id);
        }

        public void Create(LegalEntity legalEntity) {
            _context.LegalEntities.Add(legalEntity);
        }

        public void Update(LegalEntity legalEntity) {
            _context.Entry(legalEntity).State = EntityState.Modified;
        }

        public void Delete(int id) {
            LegalEntity legalEntity = _context.LegalEntities.Find(id);
            if (legalEntity != null)
                _context.LegalEntities.Remove(legalEntity);
        }
        
    }
}