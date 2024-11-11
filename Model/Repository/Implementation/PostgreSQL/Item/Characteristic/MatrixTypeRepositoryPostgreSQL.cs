using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.Characteristic;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic {
    public class MatrixTypeRepositoryPostgreSQL: IMatrixTypeRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public MatrixTypeRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<MatrixType> List() {
            return _context.MatrixTypes.ToList();
        }

        public MatrixType Get(int id) {
            return _context.MatrixTypes.Find(id);
        }

        public void Create(MatrixType matrixType) {
            _context.MatrixTypes.Add(matrixType);
        }

        public void Update(MatrixType matrixType) {
            _context.Entry(matrixType).State = EntityState.Modified;
        }

        public void Delete(int id) {
            MatrixType matrixType = _context.MatrixTypes.Find(id);
            if (matrixType != null)
                _context.MatrixTypes.Remove(matrixType);
        }
        
    }
}