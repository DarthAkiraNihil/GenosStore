using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class ComputerCaseTypesizeRepositoryPostgreSQL: IComputerCaseTypesizeRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public ComputerCaseTypesizeRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<ComputerCaseTypesize> List() {
            return _context.ComputerCaseTypesizes.ToList();
        }

        public ComputerCaseTypesize Get(int id) {
            return _context.ComputerCaseTypesizes.Find(id);
        }

        public void Create(ComputerCaseTypesize computerCaseTypesize) {
            _context.ComputerCaseTypesizes.Add(computerCaseTypesize);
        }

        public void Update(ComputerCaseTypesize computerCaseTypesize) {
            _context.Entry(computerCaseTypesize).State = EntityState.Modified;
        }

        public void Delete(int id) {
            ComputerCaseTypesize computerCaseTypesize = _context.ComputerCaseTypesizes.Find(id);
            if (computerCaseTypesize != null)
                _context.ComputerCaseTypesizes.Remove(computerCaseTypesize);
        }
        
    }
}