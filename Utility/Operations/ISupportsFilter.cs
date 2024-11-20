using System;
using System.Collections.Generic;

namespace GenosStore.Utility.Operations {
    public interface ISupportsFilter<T> where T : class {
        List<T> Filter(List<Func<T, bool>> filters);
    }
}