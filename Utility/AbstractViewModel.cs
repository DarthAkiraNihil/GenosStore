using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Entity.Users;
using GenosStore.Utility.Navigation;

namespace GenosStore.Utility {
	public abstract class AbstractViewModel: INotifyPropertyChanged {
		
		protected readonly IServices _services;
		public AbstractViewModel(IServices services) {
			_services = services;
		}

		public string Title { get; set; }
		public void Navigate(NavigationArgs args) {
			Messenger.Default.Send<NavigationArgs>(args);
		}
		
		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged(string propertyName) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
