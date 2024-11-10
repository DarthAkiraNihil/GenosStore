using System.Collections.Generic;
using System.Collections.ObjectModel;
using GenosStore.Model.Entity.Item.Characteristic;

namespace GenosStore.Utility {
    public class Utilities {
        public static ObservableCollection<CheckableItem<T>> ConvertToCheckableCollection<T>(List<T> list) {
            var converted = new ObservableCollection<CheckableItem<T>>();
            foreach (var element in list) {
                converted.Add(
                    new CheckableItem<T>() {Item = element, IsChecked = false}
                );
            }
            return converted;
        }
    }
}