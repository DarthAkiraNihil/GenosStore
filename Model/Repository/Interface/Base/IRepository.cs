using GenosStore.Utility.Operations;

namespace GenosStore.Model.Repository.Interface.Base {
    public interface IRepository<T>:
        ISupportsCreate<T>,
        ISupportsGet<T>,
        ISupportsList<T>,
        ISupportsUpdate<T>,
        ISupportsDelete where T: class {
        
    }
}