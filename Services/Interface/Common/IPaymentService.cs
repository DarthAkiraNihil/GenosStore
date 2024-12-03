using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;

namespace GenosStore.Services.Interface.Common {
    public interface IPaymentService {
        string GetOrdererInfo(Customer customer);
        bool ProcessPayment(Order order);
    }
}