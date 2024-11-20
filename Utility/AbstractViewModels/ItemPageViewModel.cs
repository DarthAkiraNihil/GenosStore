using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;

namespace GenosStore.Utility.AbstractViewModels {
    public class ItemPageViewModel<T>: RequiresUserViewModel {
        
        public T Item { get; set; }

        public ItemPageViewModel(IServices services, User user) : base(services, user) {
        }
    }
}