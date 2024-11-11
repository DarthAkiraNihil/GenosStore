// using System.Collections.Generic;
// using System.Data.Entity;
// using System.Linq;
// using GenosStore.Model.Context;
// using GenosStore.Model.Entity.Item.SimpleComputerComponent;
// using GenosStore.Model.Repository.Interface.Item;
// using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;
//
// namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item {
//     public class ItemRepositoryPostgreSQL: IItemRepository {
//
//         private readonly GenosStoreDatabaseContext _context;
//         
//         public ItemRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
//             _context = context;
//         }
//
//         public List<Item> List() {
//             return _context.Items.ToList();
//         }
//
//         public Item Get(int id) {
//             return _context.Items.Find(id);
//         }
//
//         public void Create(Item item) {
//             _context.Items.Add(item);
//         }
//
//         public void Update(Item item) {
//             _context.Entry(item).State = EntityState.Modified;
//         }
//
//         public void Delete(int id) {
//             Item item = _context.Items.Find(id);
//             if (item != null)
//                 _context.Items.Remove(item);
//         }
//         
//     }
// }