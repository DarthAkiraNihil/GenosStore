using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Common.Cache;
using GenosStore.Services.Interface.Entity.Users;

namespace GenosStore.Services.Implementation.Common {
    public class CommonServices: ICommonServices {
        
        private readonly IAuthorizationService _authorizationService;
        private readonly ICacheServices _cache;
        private readonly IPageResolverService _pageResolverService;
        private readonly IPaymentService _paymentService;
        private readonly IReceiptService _receiptService;
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

        public IReceiptService Receipts {
            get {
                return _receiptService;
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
            IReceiptService receiptService,
            ISaveService saveService
            ) {
            _authorizationService = authorizationService;
            _cache = cache;
            _pageResolverService = pageResolverService;
            _paymentService = paymentService;
            _receiptService = receiptService;
            _saveService = saveService;
        }
    }
}