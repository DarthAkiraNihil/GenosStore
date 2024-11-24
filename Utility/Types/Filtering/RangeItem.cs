using System;
using System.Collections.Generic;
using System.Linq;

namespace GenosStore.Utility.Types.Filtering {
    public class RangeItem: ISupportsValidation {
        public int From { get; set; }
        public int To { get; set; }

        public RangeItem() {
            From = 0;
            To = 0;
        }

        public bool IsValid() {
            return To < From;
        }
    }
}