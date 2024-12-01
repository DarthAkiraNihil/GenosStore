using System.Collections.Generic;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface.Base;

namespace GenosStore.Services.Interface.Entity.Orders {
    public interface IOrderService: IStandardService<Order> {
        long CreateOrderFromCart(Customer customer);
        double CalculateTotal(Order order);
        List<Order> ListOfSpecificCustomer(Customer customer);
        bool OrderExists(int orderId);
    }
}