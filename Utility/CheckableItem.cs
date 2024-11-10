using System;

namespace GenosStore.Utility {
    public class CheckableItem<T> {
        public T Item { get; set; }
        public bool IsChecked { get; set; }
    }
}