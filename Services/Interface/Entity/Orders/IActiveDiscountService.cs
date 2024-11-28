using GenosStore.Model.Entity.Orders;
using GenosStore.Services.Interface.Base;

namespace GenosStore.Services.Interface.Entity.Orders {
    public interface IActiveDiscountService: IStandardService<ActiveDiscount> {
		bool IsActive(ActiveDiscount activeDiscount);
        void Deactivate(ActiveDiscount activeDiscount);
    }
}