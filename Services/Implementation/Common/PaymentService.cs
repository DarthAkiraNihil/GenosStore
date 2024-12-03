using System;
using System.Linq;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Common;

namespace GenosStore.Services.Implementation.Common {
    public class PaymentService: IPaymentService {
        private IGenosStoreRepositories _repositories;

        public PaymentService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public string GetOrdererInfo(Customer customer) {
            if (customer == null) {
                return string.Empty;
            }

            if (customer is IndividualEntity) {
                var ie = (IndividualEntity)customer;
                return $"{ie.Name} {ie.Surname}";
            }

            if (customer is LegalEntity) {
                var le = (LegalEntity)customer;
                return $"{le.Email} (ИНН: {le.INN})";
            }
            
            return string.Empty;
        }

        public bool ProcessPayment(Order order) {
            var paid = _repositories.Orders.OrderStatuses.List().First(os => os.Name == "Paid");
            
            double chance = new Random().NextDouble();
            if (chance <= 0.05) {
                return false;
            }

            order.OrderStatus = paid;
            _repositories.Orders.Orders.Update(order);
            _repositories.Save();
            return true;
        }
    }
}