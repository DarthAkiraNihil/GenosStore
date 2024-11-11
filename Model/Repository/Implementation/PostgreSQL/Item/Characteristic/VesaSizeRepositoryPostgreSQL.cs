using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class VesaSizeRepositoryPostgreSQL: IVesaSizeRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public VesaSizeRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<VesaSize> List() {
            return _context.VesaSizes.ToList();
        }

        public VesaSize Get(int id) {
            return _context.VesaSizes.Find(id);
        }

        public void Create(VesaSize vesaSize) {
            _context.VesaSizes.Add(vesaSize);
        }

        public void Update(VesaSize vesaSize) {
            _context.Entry(vesaSize).State = EntityState.Modified;
        }

        public void Delete(int id) {
            VesaSize vesaSize = _context.VesaSizes.Find(id);
            if (vesaSize != null)
                _context.VesaSizes.Remove(vesaSize);
        }
        
    }
}