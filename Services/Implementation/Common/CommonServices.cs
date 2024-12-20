using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Common.Cache;

namespace GenosStore.Services.Implementation.Common {
    public class CommonServices: ICommonServices {
        
        private readonly IAuthorizationService _authorizationService;
        private readonly ICacheServices _cache;
        private readonly IPaymentService _paymentService;
        private readonly IReportService _reportService;
        private readonly ISaveService _saveService;
        private readonly IDashboardService _dashboardService;
        
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

        public IDashboardService Dashboard {
            get {
                return _dashboardService;
            }
        }

        public CommonServices(
            IAuthorizationService authorizationService,
            ICacheServices cache,
            IPaymentService paymentService,
            IReportService reportService,
            ISaveService saveService,
            IDashboardService dashboardService
            ) {
            _authorizationService = authorizationService;
            _cache = cache;
            _paymentService = paymentService;
            _reportService = reportService;
            _saveService = saveService;
            _dashboardService = dashboardService;
        }
    }
}