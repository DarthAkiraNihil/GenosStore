namespace GenosStore.Utility.Operations {
	public interface ISupportsEdit<T> where T: class {
		void Edit(T item);
	}
}