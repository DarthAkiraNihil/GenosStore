using GenosStore.Model.Entity.Orders;

namespace GenosStore.Utility.Types {
    public class OrderItemDetails {
        public OrderItems Item { get; set; }
        public double Subtotal { get; set; }
    }
}