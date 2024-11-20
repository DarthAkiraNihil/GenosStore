using GenosStore.Services.Interface.Entity.Items;
using GenosStore.Services.Interface.Entity.Orders;
using GenosStore.Services.Interface.Entity.Users;

namespace GenosStore.Services.Interface.Entity {
    public interface IEntityServices {
        IItemServices Items { get; }
        //IOrderEntitiesService Orders { get; }
        //IUserEntitiesService Users { get; }
    }
}