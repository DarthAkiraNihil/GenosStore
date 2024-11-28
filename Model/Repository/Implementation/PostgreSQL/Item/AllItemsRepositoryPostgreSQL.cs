using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Repository.Interface.Item;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item {
    public class AllItemsRepositoryPostgreSQL: IAllItemsRepository {
        
        private readonly GenosStoreDatabaseContext _context;
        
        public AllItemsRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<Entity.Item.Item> List() {
            return _context.Items.ToList();
        }

        public Entity.Item.Item Get(int id) {
            return _context.Items.Find(id);
        }

        public void Create(Entity.Item.Item itemType) {
            _context.Items.Add(itemType);
        }

        public void Update(Entity.Item.Item itemType) {
            _context.Entry(itemType).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Entity.Item.Item item = _context.Items.Find(id);
            if (item != null)
                _context.Items.Remove(item);
        }
        
    }
}