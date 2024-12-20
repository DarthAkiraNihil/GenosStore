using GenosStore.Model.Entity.User;
using GenosStore.Utility.Operations;


namespace GenosStore.Services.Interface.Entity.Users {
    public interface IUserService:
        ISupportsCreate<User>,
        ISupportsList<User> {
        bool Exists(string email);
        User FindByEmail(string email);
    }
}