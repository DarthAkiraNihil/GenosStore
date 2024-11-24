using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface.Base;
using GenosStore.Utility.Operations;

namespace GenosStore.Model.Repository.Interface.Orders {
    public interface ICartItemsRepository: IRepository<CartItem>, ISupportsDeleteRaw<CartItem> {
        
    }
}