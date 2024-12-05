using GenosStore.Services.Implementation.Entity.Orders;
using GenosStore.Services.Interface.Entity.Orders;
using Ninject.Modules;

namespace GenosStore.Utility.NinjectModules.ServiceModules {
    public class OrderEntitiesModule: NinjectModule {
        public override void Load() {
            
            Bind<ICartService>().To<CartService>().InSingletonScope();
            Bind<IActiveDiscountService>().To<ActiveDiscountService>().InSingletonScope();
            Bind<IOrderService>().To<OrderService>().InSingletonScope();
            Bind<IBankSystemService>().To<BankSystemService>().InSingletonScope();
            Bind<IBankCardService>().To<BankCardsService>().InSingletonScope();
            Bind<IOrderStatusService>().To<OrderStatusService>().InSingletonScope();
            Bind<IOrderEntitiesService>().To<OrderEntitiesService>().InSingletonScope();
            
        }
    }
}