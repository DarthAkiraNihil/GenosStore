// using System.Collections.Generic;
// using System.Data.Entity;
// using System.Linq;
// using GenosStore.Model.Context;
// using GenosStore.Model.Entity.Item.ComputerComponent;
// using GenosStore.Model.Repository.Interface.Item.ComputerComponent;
//
// namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
//     public class DiskDriveRepositoryPostgreSQL: IDiskDriveRepository {
//
//         private readonly GenosStoreDatabaseContext _context;
//         
//         public DiskDriveRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
//             _context = context;
//         }
//
//         public List<DiskDrive> List() {
//             return _context.DiskDrives.ToList();
//         }
//
//         public DiskDrive Get(int id) {
//             return _context.DiskDrives.Find(id);
//         }
//
//         public void Create(DiskDrive DiskDrive) {
//             _context.DiskDrives.Add(DiskDrive);
//         }
//
//         public void Update(DiskDrive DiskDrive) {
//             _context.Entry(DiskDrive).State = EntityState.Modified;
//         }
//
//         public void Delete(int id) {
//             DiskDrive DiskDrive = _context.DiskDrives.Find(id);
//             if (DiskDrive != null)
//                 _context.DiskDrives.Remove(DiskDrive);
//         }
//         
//     }
// }