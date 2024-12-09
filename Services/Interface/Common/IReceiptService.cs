using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;

namespace GenosStore.Services.Interface.Common {
    public interface IReceiptService {
        void CreateOrderReceipt(Customer customer, Order order, string path);
    }
}