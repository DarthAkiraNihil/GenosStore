using GenosStore.Utility.Operations;

namespace GenosStore.Services.Interface.Base {
    public interface IEnumService<T>:
        ISupportsGetFromString<T>,
        IStandardService<T> where T : class {
                
    }
}