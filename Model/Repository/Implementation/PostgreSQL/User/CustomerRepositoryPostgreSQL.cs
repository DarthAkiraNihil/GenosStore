// using System.Collections.Generic;
// using System.Data.Entity;
// using System.Linq;
// using GenosStore.Model.Context;
// using GenosStore.Model.Entity.User;
// using GenosStore.Model.Repository.Interface.User;
//
// namespace GenosStore.Model.Repository.Implementation.PostgreSQL.User {
//     public class CustomerRepositoryPostgreSQL: ICustomerRepository {
//
//         private readonly GenosStoreDatabaseContext _context;
//         
//         public CustomerRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
//             _context = context;
//         }
//
//         public List<Customer> List() {
//             return _context.Customers.ToList();
//         }
//
//         public Customer Get(int id) {
//             return _context.Customers.Find(id);
//         }
//
//         public void Create(Customer customer) {
//             _context.Customers.Add(customer);
//         }
//
//         public void Update(Customer customer) {
//             _context.Entry(customer).State = EntityState.Modified;
//         }
//
//         public void Delete(int id) {
//             Customer customer = _context.Customers.Find(id);
//             if (customer != null)
//                 _context.Customers.Remove(customer);
//         }
//         
//     }
// }