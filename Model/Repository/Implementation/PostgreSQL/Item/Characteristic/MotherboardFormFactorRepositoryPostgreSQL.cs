using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class MotherboardFormFactorRepositoryPostgreSQL: IMotherboardFormFactorRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public MotherboardFormFactorRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<MotherboardFormFactor> List() {
            return _context.MotherboardFormFactors.ToList();
        }

        public MotherboardFormFactor Get(int id) {
            return _context.MotherboardFormFactors.Find(id);
        }

        public void Create(MotherboardFormFactor motherboardFormFactor) {
            _context.MotherboardFormFactors.Add(motherboardFormFactor);
        }

        public void Update(MotherboardFormFactor motherboardFormFactor) {
            _context.Entry(motherboardFormFactor).State = EntityState.Modified;
        }

        public void Delete(int id) {
            MotherboardFormFactor motherboardFormFactor = _context.MotherboardFormFactors.Find(id);
            if (motherboardFormFactor != null)
                _context.MotherboardFormFactors.Remove(motherboardFormFactor);
        }
        
    }
}