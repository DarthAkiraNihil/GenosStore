using GenosStore.Utility.Operations;

namespace GenosStore.Services.Interface.Base {
    public interface IFilterService<T>: ISupportsFilter<T> where T : class {
        
    }
}