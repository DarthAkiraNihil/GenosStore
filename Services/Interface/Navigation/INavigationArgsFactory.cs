using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Utility.Navigation;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.Services.Interface.Navigation {
    public interface INavigationArgsFactory {
        NavigationArgs GetNavigationArgs(PageTypeDescriptor pageType, IServices services);
        NavigationArgs GetNavigationArgs(PageTypeDescriptor pageType, IServices services, User user, ItemTypeDescriptor? itemType = null, int? itemId = null);
        NavigationArgs GetNavigationArgs(PageTypeDescriptor pageType, IServices services, User user, Order order);
    }
}