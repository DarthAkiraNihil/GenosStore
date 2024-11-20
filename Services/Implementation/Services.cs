using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity;

namespace GenosStore.Services.Implementation {
    public class Services: IServices {
        
        private ICommonServices _commonServices;
        private IEntityServices _entityServices;

        public ICommonServices Common {
            get {
                return _commonServices;
            }
        }

        public IEntityServices Entity {
            get {
                return _entityServices;
            }
        }

        public Services(ICommonServices commonServices, IEntityServices entityServices) {
            _commonServices = commonServices;
            _entityServices = entityServices;
        }
    }
}