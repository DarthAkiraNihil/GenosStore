using System.Collections.Generic;
using System.Windows.Documents;

namespace GenosStore.Utility.Operations {
	public interface ISupportsList<T> where T: class {
		List<T> List();
	}
}