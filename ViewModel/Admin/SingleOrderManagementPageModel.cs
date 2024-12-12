using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.Admin {
    public class SingleOrderManagementPageModel: RequiresUserViewModel {
        public SingleOrderManagementPageModel(IServices services, User user) : base(services, user) {
        }
    }
}