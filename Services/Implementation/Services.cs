using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity;

namespace GenosStore.Services.Implementation {
    public class Services: IServices {
        
        private ICommonServices _commonServices;

        public ICommonServices Common {
            get {
                return _commonServices;
            }
        }

        public IEntityServices Entity {
            get {
                return null;
            }
        }

        public Services(ICommonServices commonServices) {
            _commonServices = commonServices;
        }

    }
}