using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class PowerSupplyRepositoryPostgreSQL: IPowerSupplyRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public PowerSupplyRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<PowerSupply> List() {
            return _context.PowerSupplies.ToList();
        }

        public PowerSupply Get(int id) {
            return _context.PowerSupplies.Find(id);
        }

        public void Create(PowerSupply powerSupply) {
            _context.PowerSupplies.Add(powerSupply);
        }

        public void Update(PowerSupply powerSupply) {
            _context.Entry(powerSupply).State = EntityState.Modified;
        }

        public void Delete(int id) {
            PowerSupply powerSupply = _context.PowerSupplies.Find(id);
            if (powerSupply != null)
                _context.PowerSupplies.Remove(powerSupply);
        }
        
    }
}