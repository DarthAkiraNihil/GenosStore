using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent {
    public class MotherboardChipsetRepositoryPostgreSQL: IMotherboardChipsetRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public MotherboardChipsetRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<MotherboardChipset> List() {
            return _context.MotherboardChipsets.ToList();
        }

        public MotherboardChipset Get(int id) {
            return _context.MotherboardChipsets.Find(id);
        }

        public void Create(MotherboardChipset motherboardChipset) {
            _context.MotherboardChipsets.Add(motherboardChipset);
        }

        public void Update(MotherboardChipset motherboardChipset) {
            _context.Entry(motherboardChipset).State = EntityState.Modified;
        }

        public void Delete(int id) {
            MotherboardChipset motherboardChipset = _context.MotherboardChipsets.Find(id);
            if (motherboardChipset != null)
                _context.MotherboardChipsets.Remove(motherboardChipset);
        }
        
    }
}