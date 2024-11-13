using GenosStore.Services.Interface.EntityAccess;

namespace GenosStore.Services.Interface {
    public interface IServices {
        IEntityServices Entity { get; }
    }
}