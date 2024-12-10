using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;

namespace GenosStore.Services.Interface.Common {
    public interface IReportService {
        void CreateOrderReceipt(Customer customer, Order order, string path);
        void CreateOrderHistoryReport(Customer customer, string path);
    }
}