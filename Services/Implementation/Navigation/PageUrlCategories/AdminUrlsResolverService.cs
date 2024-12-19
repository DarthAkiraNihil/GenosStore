using GenosStore.Services.Interface.Navigation.PageUrlCategories;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.Services.Implementation.Navigation.PageUrlCategories {
    public class AdminUrlsResolverService: StandardPageUrlResolver, IAdminUrlsResolverService {
        private string Dashboard => "View/Admin/DashboardPage.xaml";
        private string LegalEntityVerification => "View/Admin/LegalEntityVerificationPage.xaml";
        private string OrderManagement => "View/Admin/OrderManagementPage.xaml";
        private string SingleOrderManagement => "View/Admin/SingleOrderManagementPage.xaml";
        private string SalesAnalysisReport => "View/Admin/SalesAnalysisReportPage.xaml";
        private string DiscountManagement => "View/Admin/DiscountPage.xaml";

        public string GetUrl(PageTypeDescriptor pageType, ItemTypeDescriptor? itemType) {
            switch (pageType) {
                case PageTypeDescriptor.Dashboard: {
                    return Dashboard;
                }
                case PageTypeDescriptor.LegalEntityVerification: {
                    return LegalEntityVerification;
                }
                case PageTypeDescriptor.OrderManagement: {
                    return OrderManagement;
                }
                case PageTypeDescriptor.SingleOrderManagement: {
                    return SingleOrderManagement;
                }
                case PageTypeDescriptor.SalesAnalysisReport: {
                    return SalesAnalysisReport;
                }
                case PageTypeDescriptor.DiscountManagement: {
                    return DiscountManagement;
                }
                default: {
                    return NotFound;
                }
            }
        }
    }
}