using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class MatrixTypeService: IMatrixTypeService {
        private IGenosStoreRepositories _repositories;

        public MatrixTypeService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void Create(MatrixType item) {
            _repositories.Items.Characteristics.MatrixTypes.Create(item);
        }

        public MatrixType Get(int id) {
            return _repositories.Items.Characteristics.MatrixTypes.Get(id);
        }

        public List<MatrixType> List() {
            return _repositories.Items.Characteristics.MatrixTypes.List();
        }

        public void Update(MatrixType item) {
            _repositories.Items.Characteristics.MatrixTypes.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.MatrixTypes.Delete(id);
        }

        public int Save() {
            return _repositories.Save();
        }
        
        public MatrixType GetFromString(string value) {
            return _repositories.Items.Characteristics.MatrixTypes.List().FirstOrDefault(i => i.Name == value);
        }
    }
}