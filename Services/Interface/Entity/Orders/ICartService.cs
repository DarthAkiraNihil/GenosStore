using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface.Base;

namespace GenosStore.Services.Interface.Entity.Orders {
    public interface ICartService: IStandardService<Cart> {
        void AddToCart(Item item, Customer customer);
        void RemoveFromCart(Item item, Customer customer);
        void IncrementCartItemQuantity(Item item, Customer customer);
        void DecrementCartItemQuantity(Item item, Customer customer);
        bool IsInCart(Item item, Customer customer);
        void ClearCart(Customer customer);
        
    }
}