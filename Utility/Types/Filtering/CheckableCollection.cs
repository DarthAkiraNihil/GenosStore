using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GenosStore.Model.Entity.Base;

namespace GenosStore.Utility.Types.Filtering {
    public class CheckableCollection<T>: ObservableCollection<CheckableItem<T>>, ISupportsValidation where T: Named {

        public bool CreateFilterClosure(Func<string, bool> primalFilter) {
            return Utilities
                   .GetNamesFromChecked(this)
                   .Where(primalFilter)
                   .FirstOrDefault() != null;
        }

        public bool IsValid() {
            return this.Any(i => i.IsChecked);
        }
    }
}