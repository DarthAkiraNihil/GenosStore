using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity;

namespace GenosStore.Services.Interface {
    public interface IServices {
        IEntityServices Entity { get; }
        ICommonServices Common { get; }
    }
}