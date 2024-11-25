using System.Windows;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.Order {
    public class OrderPageModel: RequiresUserViewModel {

        private class OrderItemDetails {
            public Item Item { get; set; }
            public int Quantity { get; set; }
            public float Subtotal { get; set; }
        }
        public OrderPageModel(IServices services, User user, int? orderId) : base(services, user) {

            if (orderId == null) {
                var id = _services.Entity.Orders.Orders.CreateOrderFromCart(user as Customer);
                MessageBox.Show(id.ToString());
            }
            
            //var order 

        }
    }
}