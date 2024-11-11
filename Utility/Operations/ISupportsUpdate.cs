﻿namespace GenosStore.Utility.Operations {
	public interface ISupportsUpdate<T> where T: class {
		void Update(T item);
	}
}