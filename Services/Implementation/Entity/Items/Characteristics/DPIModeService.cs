using System.Collections.Generic;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Items.Characteristics;

namespace GenosStore.Services.Implementation.Entity.Items.Characteristics {
    public class DPIModeService: IDPIModeService {
        private IGenosStoreRepositories _repositories;

        public DPIModeService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public List<DPIMode> List() {
            return _repositories.Items.Characteristics.DPIModes.List();
        }
        
    }
}