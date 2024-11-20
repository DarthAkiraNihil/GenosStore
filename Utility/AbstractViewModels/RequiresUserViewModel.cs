using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;

namespace GenosStore.Utility.AbstractViewModels {
    public class RequiresUserViewModel: AbstractViewModel {
        protected User _user;

        public RequiresUserViewModel(IServices services, User user): base(services) {
            _user = user;
        }
    }
}