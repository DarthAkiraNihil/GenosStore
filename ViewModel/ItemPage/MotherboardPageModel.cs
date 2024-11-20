using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.ItemPage {
	public class MotherboardPageModel: ItemPageViewModel<Motherboard> {

		public MotherboardPageModel(IServices services, User user, int itemId): base(services, user) {
			MessageBox.Show("EBAL");
		}

	}
}
