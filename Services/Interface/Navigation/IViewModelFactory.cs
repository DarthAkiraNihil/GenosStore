using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.Services.Interface.Navigation {
    public interface IViewModelFactory {
        AbstractViewModel CreateViewModel(PageTypeDescriptor pageType, IServices services);
        AbstractViewModel CreateViewModel(PageTypeDescriptor pageType, IServices services, User user, int? id = null, ItemTypeDescriptor? itemType = null);
        AbstractViewModel CreateViewModel(PageTypeDescriptor pageType, IServices services, User user, Order order);
    }
}