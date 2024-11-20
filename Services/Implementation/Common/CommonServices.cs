using GenosStore.Services.Interface.Common;

namespace GenosStore.Services.Implementation.Common {
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