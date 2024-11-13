using GenosStore.Services.Interface.EntityAccess.Items;
using GenosStore.Services.Interface.EntityAccess.Orders;
using GenosStore.Services.Interface.EntityAccess.Users;

namespace GenosStore.Services.Interface.EntityAccess {
    public interface IEntityServices {
        IItemService Items { get; }
        IOrderEntitiesService Orders { get; }
        IUserEntitiesService Users { get; }
    }
}