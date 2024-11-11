using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class Certificate80PlusRepositoryPostgreSQL: ICertificate80PlusRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public Certificate80PlusRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Certificate80Plus> List() {
            return _context.Certificates80Plus.ToList();
        }

        public Certificate80Plus Get(int id) {
            return _context.Certificates80Plus.Find(id);
        }

        public void Create(Certificate80Plus certificate80Plus) {
            _context.Certificates80Plus.Add(certificate80Plus);
        }

        public void Update(Certificate80Plus certificate80Plus) {
            _context.Entry(certificate80Plus).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Certificate80Plus certificate80Plus = _context.Certificates80Plus.Find(id);
            if (certificate80Plus != null)
                _context.Certificates80Plus.Remove(certificate80Plus);
        }
        
    }
}