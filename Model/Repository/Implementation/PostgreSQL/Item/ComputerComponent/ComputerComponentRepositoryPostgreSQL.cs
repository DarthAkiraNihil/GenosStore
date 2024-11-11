// using System.Collections.Generic;
// using System.Data.Entity;
// using System.Linq;
// using GenosStore.Model.Context;
// using GenosStore.Model.Entity.Item.ComputerComponent;
// using GenosStore.Model.Repository.Interface.Item.ComputerComponent;
//
// namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
//     public class ComputerComponentRepositoryPostgreSQL: IComputerComponentRepository {
//
//         private readonly GenosStoreDatabaseContext _context;
//         
//         public ComputerComponentRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
//             _context = context;
//         }
//
//         public List<Entity.Item.ComputerComponent.ComputerComponent> List() {
//             return _context.ComputerComponents.ToList();
//         }
//
//         public ComputerComponent Get(int id) {
//             return _context.ComputerComponents.Find(id);
//         }
//
//         public void Create(ComputerComponent computerComponent) {
//             _context.ComputerComponents.Add(computerComponent);
//         }
//
//         public void Update(ComputerComponent computerComponent) {
//             _context.Entry(computerComponent).State = EntityState.Modified;
//         }
//
//         public void Delete(int id) {
//             ComputerComponent computerComponent = _context.ComputerComponents.Find(id);
//             if (computerComponent != null)
//                 _context.ComputerComponents.Remove(computerComponent);
//         }
//         
//     }
// }