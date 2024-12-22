using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.ViewModel.ItemPage {
	public class CPUCoolerPageModel: ItemPageViewModel<CPUCooler> {
		
		protected override ItemTypeDescriptor _itemType => ItemTypeDescriptor.CPUCooler;

		public CPUCoolerPageModel(IServices services, User user, int itemId): base(services, user) {
			Item = _services.Entity.Items.ComputerComponents.CPUCoolers.Get(itemId);
			if (_services.Entity.Orders.Carts.IsInCart(Item, _user as Customer)) {
				ButtonText = "В корзине";
				_itemIsInCart = true;
			}
			FillPrices(Item);
			Title = Item.Name;
		}

	}
}
