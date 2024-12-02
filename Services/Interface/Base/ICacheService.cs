namespace GenosStore.Services.Interface.Base {
    public interface ICacheService<T> {
        T Get(string key);
        bool HasKey(string key);
        void Add(string key, T value);
    }
}