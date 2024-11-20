using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GenosStore.Model.Entity.Base;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Utility.Types.Filtering;
using GenosStore.View.Other;

namespace GenosStore.Utility {
    public class Utilities {
        public static ObservableCollection<CheckableItem<T>> ConvertToCheckableCollection<T>(List<T> list) {
            var converted = new ObservableCollection<CheckableItem<T>>();
            foreach (var element in list) {
                converted.Add(
                    new CheckableItem<T> {Item = element, IsChecked = false}
                );
            }
            return converted;
        }

        public static void SpawnMessageBox(string title, string message) {
            var messageBox = new GenosStoreMessageBox(title, message);
            messageBox.ShowDialog();
        }
        
        public static List<string> GetNamesFromChecked<T>(ObservableCollection<CheckableItem<T>> collection) where T: Named{
            return collection
                   .Where(i => i.IsChecked)
                   .Select(i => i.Item.Name)
                   .ToList();
        }
    }
}