using GenosStore.Model.Entity.Orders;

namespace GenosStore.Utility.Types {
    public class CartListElement {
        public CartItem Item { get; set; }
        public double? Price { get; set; }
        public double? DiscountedPrice { get; set; }
        public double? OldPrice { get; set; }
    }
}