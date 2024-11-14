using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface.Base;

namespace GenosStore.Services.Interface.Base {
    public interface IStandardService<T>: IRepository<T> where T : class {
        bool CheckAccessRights(UserType userType);
    }
}