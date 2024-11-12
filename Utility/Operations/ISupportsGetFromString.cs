namespace GenosStore.Utility.Operations {
    public interface ISupportsGetFromString<T> where T : class {
        T GetFromString(string value);
    }
}