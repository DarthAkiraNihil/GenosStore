using System;
using System.Collections.Generic;

namespace GenosStore.Utility.Types.Filtering {
    public interface IFilter {
        Func<C, bool> AsFilter<C>(C characteristic) where C : class;   
    }
}