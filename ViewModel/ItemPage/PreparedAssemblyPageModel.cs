﻿using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.ViewModel.ItemPage {
	public class PreparedAssemblyPageModel: ItemPageViewModel<PreparedAssembly> {
		protected override ItemTypeDescriptor _itemType => ItemTypeDescriptor.PreparedAssembly;

		public PreparedAssemblyPageModel(IServices services, User user, int itemId): base(services, user) {
			Item = _services.Entity.Items.PreparedAssemblies.Get(itemId);
			if (_services.Entity.Orders.Carts.IsInCart(Item, _user as Customer)) {
				ButtonText = "В корзине";
				_itemIsInCart = true;
			}
			FillPrices(Item);
			Title = Item.Name;
		}

	}
}
