using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent {
    public class ComputerCaseRepositoryPostgreSQL: IComputerCaseRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public ComputerCaseRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<ComputerCase> List() {
            return _context.ComputerCases.ToList();
        }

        public ComputerCase Get(int id) {
            return _context.ComputerCases.Find(id);
        }

        public void Create(ComputerCase computerCase) {
            _context.ComputerCases.Add(computerCase);
        }

        public void Update(ComputerCase computerCase) {
            _context.Entry(computerCase).State = EntityState.Modified;
        }

        public void Delete(int id) {
            ComputerCase computerCase = _context.ComputerCases.Find(id);
            if (computerCase != null)
                _context.ComputerCases.Remove(computerCase);
        }
        
    }
}