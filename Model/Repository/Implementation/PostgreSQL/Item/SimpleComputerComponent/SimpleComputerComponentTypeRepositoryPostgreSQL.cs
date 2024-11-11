using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent {
    public class SimpleComputerComponentTypeRepositoryPostgreSQL: ISimpleComputerComponentTypeRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public SimpleComputerComponentTypeRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<SimpleComputerComponentType> List() {
            return _context.SimpleComputerComponentTypes.ToList();
        }

        public SimpleComputerComponentType Get(int id) {
            return _context.SimpleComputerComponentTypes.Find(id);
        }

        public void Create(SimpleComputerComponentType simpleComputerComponentType) {
            _context.SimpleComputerComponentTypes.Add(simpleComputerComponentType);
        }

        public void Update(SimpleComputerComponentType simpleComputerComponentType) {
            _context.Entry(simpleComputerComponentType).State = EntityState.Modified;
        }

        public void Delete(int id) {
            SimpleComputerComponentType simpleComputerComponentType = _context.SimpleComputerComponentTypes.Find(id);
            if (simpleComputerComponentType != null)
                _context.SimpleComputerComponentTypes.Remove(simpleComputerComponentType);
        }
        
    }
}