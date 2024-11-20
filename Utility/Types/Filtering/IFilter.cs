using System;

namespace GenosStore.Utility.Types.Filtering {
    public interface IFilter {
        Func<T, bool> AsFilter<T>() where T : class;   
    }
}