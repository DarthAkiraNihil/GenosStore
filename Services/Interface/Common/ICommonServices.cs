using GenosStore.Services.Interface.Common.Cache;

namespace GenosStore.Services.Interface.Common {
    public interface ICommonServices {
        IAuthorizationService Authorization { get; }
        ICacheServices Cache { get; }
        IPageResolverService PageResolver { get; }
        IPaymentService Payment { get; }
    }
}