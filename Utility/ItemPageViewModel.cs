using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.Utility {
	public abstract class ItemPageViewModel: AbstractViewModel {
		private int _itemId;

		public int ItemId {
			get {
				return _itemId;
			}
			set {
				_itemId = value;
				MessageBox.Show(value.ToString());
				NotifyPropertyChanged("ItemId");
			}

		}

		public ItemPageViewModel(IServices services) : base(services) {
		}
	}
}
