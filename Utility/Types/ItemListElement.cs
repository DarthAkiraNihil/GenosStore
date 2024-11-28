using GenosStore.Model.Entity.Item;

namespace GenosStore.Utility.Types {
    public class ItemListElement<T> where T : Item {
        public T Item { get; set; }
        public double? Price { get; set; }
        public double? DiscountedPrice { get; set; }
        public double? OldPrice { get; set; }
    }
}