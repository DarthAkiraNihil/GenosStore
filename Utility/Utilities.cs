using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GenosStore.Model.Entity.Base;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types.Filtering;
using GenosStore.View.Other;

namespace GenosStore.Utility {
    public class Utilities {
        public static CheckableCollection<T> ConvertToCheckableCollection<T>(List<T> list) where T: Named{
            var converted = new CheckableCollection<T>();
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
        
        public static List<string> GetNamesFromChecked<T>(CheckableCollection<T> collection) where T: Named{
            return collection
                   .Where(i => i.IsChecked)
                   .Select(i => i.Item.Name)
                   .ToList();
        }

        // public static ObservableCollection<ItemListViewModel<T>.ItemListElement> ConvertToItemListAndCheckDiscounts<T>(List<T> list) where T : Item {
        //     var converted = new ObservableCollection<ItemListViewModel<T>.ItemListElement>();
        //
        //     foreach (var item in list) {
        //         
        //     }
        // }
    }
}