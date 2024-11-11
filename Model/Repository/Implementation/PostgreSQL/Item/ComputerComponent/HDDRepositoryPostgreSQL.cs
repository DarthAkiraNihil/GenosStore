using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class HDDRepositoryPostgreSQL: IHDDRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public HDDRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<HDD> List() {
            return _context.HDDs.ToList();
        }

        public HDD Get(int id) {
            return _context.HDDs.Find(id);
        }

        public void Create(HDD hdd) {
            _context.HDDs.Add(hdd);
        }

        public void Update(HDD hdd) {
            _context.Entry(hdd).State = EntityState.Modified;
        }

        public void Delete(int id) {
            HDD hdd = _context.HDDs.Find(id);
            if (hdd != null)
                _context.HDDs.Remove(hdd);
        }
        
    }
}