namespace GenosStore.Utility.Operations {
	public interface ISupportsGet<T> where T: class {
		T Get(int id);
	}
}