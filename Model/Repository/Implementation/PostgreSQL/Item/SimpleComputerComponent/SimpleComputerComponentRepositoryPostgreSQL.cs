// using System.Collections.Generic;
// using System.Data.Entity;
// using System.Linq;
// using GenosStore.Model.Context;
// using GenosStore.Model.Entity.Item.SimpleComputerComponent;
// using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;
//
// namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent {
//     public class SimpleComputerComponentRepositoryPostgreSQL: ISimpleComputerComponentRepository {
//
//         private readonly GenosStoreDatabaseContext _context;
//         
//         public SimpleComputerComponentRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
//             _context = context;
//         }
//
//         public List<SimpleComputerComponent> List() {
//             return _context.SimpleComputerComponents.ToList();
//         }
//
//         public SimpleComputerComponent Get(int id) {
//             return _context.SimpleComputerComponents.Find(id);
//         }
//
//         public void Create(SimpleComputerComponent simpleComputerComponent) {
//             _context.SimpleComputerComponents.Add(simpleComputerComponent);
//         }
//
//         public void Update(SimpleComputerComponent simpleComputerComponent) {
//             _context.Entry(simpleComputerComponent).State = EntityState.Modified;
//         }
//
//         public void Delete(int id) {
//             SimpleComputerComponent simpleComputerComponent = _context.SimpleComputerComponents.Find(id);
//             if (simpleComputerComponent != null)
//                 _context.SimpleComputerComponents.Remove(simpleComputerComponent);
//         }
//         
//     }
// }