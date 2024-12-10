using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Common.Cache;
using GenosStore.Services.Interface.Entity.Users;

namespace GenosStore.Services.Implementation.Common {
    public class CommonServices: ICommonServices {
        
        private readonly IAuthorizationService _authorizationService;
        private readonly ICacheServices _cache;
        private readonly IPageResolverService _pageResolverService;
        private readonly IPaymentService _paymentService;
        private readonly IReportService _reportService;
        private readonly ISaveService _saveService;
        
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

        public IPaymentService Payment {
            get {
                return _paymentService;
            }
        }

        public IReportService Reports {
            get {
                return _reportService;
            }
        }

        public ISaveService Saving {
            get {
                return _saveService;
            }
        }

        public CommonServices(
            IAuthorizationService authorizationService,
            ICacheServices cache,
            IPageResolverService pageResolverService,
            IPaymentService paymentService,
            IReportService reportService,
            ISaveService saveService
            ) {
            _authorizationService = authorizationService;
            _cache = cache;
            _pageResolverService = pageResolverService;
            _paymentService = paymentService;
            _reportService = reportService;
            _saveService = saveService;
        }
    }
}