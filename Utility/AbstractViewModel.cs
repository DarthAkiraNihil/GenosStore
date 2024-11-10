using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Utility {
	public abstract class AbstractViewModel: INotifyPropertyChanged {
		public AbstractViewModel() {}

		public string Title { get; set; }
		public void Navigate(string url, string title, AbstractViewModel viewModel) {
			Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url, title, viewModel, 0));
		}

		public void Navigate(string url, string title, int itemId) {
			Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url, title, null, itemId));
		}

		public class NavigateArgs {
			public NavigateArgs() {

			}

			public NavigateArgs(string url, string title, AbstractViewModel viewModel, int id) {
				URL = url;
				Title = title;
				ViewModel = viewModel;
				Id = id;
			}

			public string URL { get; set; }
			public string Title { get; set; }
			public AbstractViewModel ViewModel { get; set; }
			public int Id { get; set; }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged(string propertyName) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
