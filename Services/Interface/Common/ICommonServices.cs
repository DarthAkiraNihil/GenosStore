using GenosStore.Services.Interface.Common.Cache;

namespace GenosStore.Services.Interface.Common {
    public interface ICommonServices {
        IAuthorizationService Authorization { get; }
        ICacheServices Cache { get; }
        IPaymentService Payment { get; }
        IReportService Reports { get; }
        ISaveService Saving { get; }
        IDashboardService Dashboard { get; }
    }
}