using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class MotherboardRepositoryPostgreSQL: IMotherboardRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public MotherboardRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Motherboard> List() {
            return _context.Motherboards.ToList();
        }

        public Motherboard Get(int id) {
            return _context.Motherboards.Find(id);
        }

        public void Create(Motherboard motherboard) {
            _context.Motherboards.Add(motherboard);
        }

        public void Update(Motherboard motherboard) {
            _context.Entry(motherboard).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Motherboard motherboard = _context.Motherboards.Find(id);
            if (motherboard != null)
                _context.Motherboards.Remove(motherboard);
        }
        
    }
}