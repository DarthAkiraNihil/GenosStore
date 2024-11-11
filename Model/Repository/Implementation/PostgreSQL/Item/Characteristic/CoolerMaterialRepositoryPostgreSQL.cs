using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class CoolerMaterialRepositoryPostgreSQL: ICoolerMaterialRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public CoolerMaterialRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<CoolerMaterial> List() {
            return _context.CoolerMaterials.ToList();
        }

        public CoolerMaterial Get(int id) {
            return _context.CoolerMaterials.Find(id);
        }

        public void Create(CoolerMaterial coolerMaterial) {
            _context.CoolerMaterials.Add(coolerMaterial);
        }

        public void Update(CoolerMaterial coolerMaterial) {
            _context.Entry(coolerMaterial).State = EntityState.Modified;
        }

        public void Delete(int id) {
            CoolerMaterial coolerMaterial = _context.CoolerMaterials.Find(id);
            if (coolerMaterial != null)
                _context.CoolerMaterials.Remove(coolerMaterial);
        }
        
    }
}