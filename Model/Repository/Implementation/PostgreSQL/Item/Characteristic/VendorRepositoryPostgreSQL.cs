using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class VendorRepositoryPostgreSQL: IVendorRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public VendorRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Vendor> List() {
            return _context.Vendors.ToList();
        }

        public Vendor Get(int id) {
            return _context.Vendors.Find(id);
        }

        public void Create(Vendor vendor) {
            _context.Vendors.Add(vendor);
        }

        public void Update(Vendor vendor) {
            _context.Entry(vendor).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Vendor vendor = _context.Vendors.Find(id);
            if (vendor != null)
                _context.Vendors.Remove(vendor);
        }
        
    }
}