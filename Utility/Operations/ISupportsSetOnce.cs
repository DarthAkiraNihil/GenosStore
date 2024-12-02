namespace GenosStore.Utility.Operations {
    public interface ISupportsSetOnce<T> {
        void SetOnce(T value);
    }
}