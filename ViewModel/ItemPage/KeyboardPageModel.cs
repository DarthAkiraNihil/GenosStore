﻿using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.ItemPage {
	public class KeyboardPageModel: ItemPageViewModel<Keyboard> {

		public KeyboardPageModel(IServices services, User user, int itemId): base(services, user) {
			Item = _services.Entity.Items.ComputerComponents.Keyboards.Get(itemId);
			if (_services.Entity.Orders.Carts.IsInCart(Item, _user as Customer)) {
				ButtonText = "В корзине";
				_itemIsInCart = true;
			}
			FillPrices(Item);
			Title = Item.Name;
		}

	}
}
