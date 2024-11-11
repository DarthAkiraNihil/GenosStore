namespace GenosStore.Utility.Operations {
	public interface ISupportsCreate<T> where T: class {
		void Create(T item);
	}
}