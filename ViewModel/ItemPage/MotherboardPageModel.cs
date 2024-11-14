using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GenosStore.Services.Interface;
using GenosStore.Utility;

namespace GenosStore.ViewModel.ItemPage {
	public class MotherboardPageModel: ItemPageViewModel {

		public MotherboardPageModel(IServices services): base(services) {
			MessageBox.Show("EBAL");
		}

	}
}
