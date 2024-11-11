using GenosStore.Utility.Operations;

namespace GenosStore.Model.Repository.Interface.Base {
    public interface IRepository<T>:
        ISupportsCreate<T>,
        ISupportsGet<T>,
        ISupportsList<T>,
        ISupportsEdit<T>,
        ISupportsDelete where T: class {
        
    }
}