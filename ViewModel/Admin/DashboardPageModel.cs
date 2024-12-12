using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.Admin {
    public class DashboardPageModel: RequiresUserViewModel {
        public DashboardPageModel(IServices services, User user) : base(services, user) {
        }
    }
}