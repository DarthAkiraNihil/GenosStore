using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Utility {
	public abstract class AbstractViewModel {
		public AbstractViewModel() {}

		public string Title { get; set; }
		public void Navigate(string url) {
			Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url));
		}

		public class NavigateArgs {
			public NavigateArgs() {

			}

			public NavigateArgs(string url) {
				Url = url;
			}

			public string Url { get; set; }
		}
	}
}
