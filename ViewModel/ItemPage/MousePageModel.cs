﻿using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.ViewModel.ItemPage {
	public class MousePageModel: ItemPageViewModel<Mouse> {
		protected override ItemTypeDescriptor _itemType => ItemTypeDescriptor.Mouse;

		public MousePageModel(IServices services, User user, int itemId): base(services, user) {
			Item = _services.Entity.Items.ComputerComponents.Mouses.Get(itemId);
			if (_services.Entity.Orders.Carts.IsInCart(Item, _user as Customer)) {
				ButtonText = "В корзине";
				_itemIsInCart = true;
			}
			FillPrices(Item);
			Title = Item.Name;
		}

	}
}
