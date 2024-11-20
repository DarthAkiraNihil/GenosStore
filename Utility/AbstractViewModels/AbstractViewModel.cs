using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using GenosStore.Services.Interface;
using GenosStore.Utility.Navigation;

namespace GenosStore.Utility.AbstractViewModels {
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
