using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface.Base;
using GenosStore.Utility.Operations;

namespace GenosStore.Services.Interface.Base {
    public interface IStandardService<T>: IRepository<T>, ISupportsSave where T : class {
    }
}