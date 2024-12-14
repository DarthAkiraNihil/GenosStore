using GenosStore.Services.Interface.Navigation.PageUrlCategories;
using GenosStore.Utility.Types.Enum;
using GenosStore.View.Other;

namespace GenosStore.Services.Implementation.Navigation.PageUrlCategories {
    public class OrderUrlsResolverService: StandardPageUrlResolver, IOrderUrlsResolverService {
        private string OrderHistory => "View/Order/OrderHistoryPage.xaml";
        private string Order => "View/Order/OrderPage.xaml";
        private string Payment => "View/Order/PaymentPage.xaml";
        private string SuccessfulPayment => "View/Order/SuccessfulPaymentPage.xaml";

        public string GetUrl(PageTypeDescriptor pageType, ItemTypeDescriptor? itemType = null) {
            switch (pageType) {
                case PageTypeDescriptor.OrderHistory: {
                    return OrderHistory;
                }
                case PageTypeDescriptor.Order: {
                    return Order;
                }
                case PageTypeDescriptor.Payment: {
                    return Payment;
                }
                case PageTypeDescriptor.SuccessfulPayment: {
                    return SuccessfulPayment;
                }
                default: {
                    return NotFound;
                }
            }
        }
    }
}