using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Common.Cache;

namespace GenosStore.Services.Implementation.Common {
    public class CommonServices: ICommonServices {
        
        private readonly IAuthorizationService _authorizationService;
        private readonly ICacheServices _cache;
        private readonly IPageResolverService _pageResolverService;
        
        public IAuthorizationService Authorization {
            get {
                return _authorizationService;
            }
        }

        public ICacheServices Cache {
            get {
                return _cache;
            }
        }

        public IPageResolverService PageResolver {
            get {
                return _pageResolverService;
            }
        }
        
        public CommonServices(IAuthorizationService authorizationService, ICacheServices cache, IPageResolverService pageResolverService) {
            _authorizationService = authorizationService;
            _cache = cache;
            _pageResolverService = pageResolverService;
        }
    }
}