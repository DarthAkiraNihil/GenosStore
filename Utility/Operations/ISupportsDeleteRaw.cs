namespace GenosStore.Utility.Operations {
    public interface ISupportsDeleteRaw<T> {
        void DeleteRaw(T item);
    }
}