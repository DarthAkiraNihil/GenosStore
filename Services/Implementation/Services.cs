using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity;
using GenosStore.Services.Interface.Navigation;

namespace GenosStore.Services.Implementation {
    public class Services: IServices {
        
        private ICommonServices _commonServices;
        private IEntityServices _entityServices;
        private INavigationServices _navigationServices;

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

        public INavigationServices Navigation {
            get {
                return _navigationServices;
            }
        }

        public Services(ICommonServices commonServices, IEntityServices entityServices, INavigationServices navigationServices) {
            _commonServices = commonServices;
            _entityServices = entityServices;
            _navigationServices = navigationServices;
        }
    }
}