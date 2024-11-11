using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Repository.Interface.Item;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item {
    public class ItemTypeRepositoryPostgreSQL: IItemTypeRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public ItemTypeRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Entity.Item.ItemType> List() {
            return _context.ItemTypes.ToList();
        }

        public Entity.Item.ItemType Get(int id) {
            return _context.ItemTypes.Find(id);
        }

        public void Create(Entity.Item.ItemType itemType) {
            _context.ItemTypes.Add(itemType);
        }

        public void Update(Entity.Item.ItemType itemType) {
            _context.Entry(itemType).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Entity.Item.ItemType itemType = _context.ItemTypes.Find(id);
            if (itemType != null)
                _context.ItemTypes.Remove(itemType);
        }
        
    }
}