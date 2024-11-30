using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class VendorsService: IVendorService {

        private IGenosStoreRepositories _repositories;

        public void Create(Vendor item) {
            _repositories.Items.Characteristics.Vendors.Create(item);
        }

        public Vendor Get(int id) {
            return _repositories.Items.Characteristics.Vendors.Get(id);
        }

        public List<Vendor> List() {
            return _repositories.Items.Characteristics.Vendors.List();
        }

        public void Update(Vendor item) {
            _repositories.Items.Characteristics.Vendors.Update(item);
        }

        public void Delete(int id) {
            _repositories.Items.Characteristics.Vendors.Delete(id);
        }
        
        public VendorsService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public Vendor GetFromString(string value) {
            return _repositories.Items.Characteristics.Vendors.List().FirstOrDefault(i => i.Name == value);
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}