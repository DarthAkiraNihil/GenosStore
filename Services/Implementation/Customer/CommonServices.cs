using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity;

namespace GenosStore.Services.Implementation.Customer {
    public class CommonServices: ICommonServices {
        
        private IAuthorizationService _authorizationService;
        
        public IAuthorizationService Authorization {
            get {
                return _authorizationService;
            }
        }

        public CommonServices(IAuthorizationService authorizationService) {
            _authorizationService = authorizationService;
        }
        
    }
}