using System;
using System.ComponentModel;
using GenosStore.Utility;
using System.Windows;
using System.Windows.Input;

namespace GenosStore.View.Other {
    public partial class GenosStoreMessageBox : Window {
        public GenosStoreMessageBox(string title, string message) {
            InitializeComponent();
            //MessageBoxViewModel.MsgBoxClose += Close;
            //Owner = Application.Current.MainWindow;
			DataContext = new MessageBoxViewModel(title, message);
        }

		private void closeButton_Click(object sender, RoutedEventArgs e) {
			Close();
		}

		private void minimizeButton_Click(object sender, RoutedEventArgs e) {
			WindowState = WindowState.Minimized;
		}

		private void ok_Click(object sender, RoutedEventArgs e) {
			DialogResult = true;
			Close();
		}

		private class MessageBoxViewModel: INotifyPropertyChanged {
			public static Action MsgBoxClose;
			
			private string _title;

			public string Title {
				get { return _title; }
				set {
					_title = value;
					NotifyPropertyChanged("Title");
				}
			}

			private string _message;

			public string Message {
				get { return _message; }
				set {
					_message = value;
					NotifyPropertyChanged("Message");
				}
			}
			
			public event PropertyChangedEventHandler PropertyChanged;

			private void NotifyPropertyChanged(string propertyName) {
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}

			public MessageBoxViewModel(string title, string message) {
				_title = title;
				_message = message;
				_okCommand = new RelayCommand(OK, CanOK);
			}

			#region OKCommand

			private readonly RelayCommand _okCommand;

			public RelayCommand OKCommand {
				get { return _okCommand; }
			}

			private void OK(object parameter) {
				MsgBoxClose?.Invoke();
			}

			private bool CanOK(object parameter) {
				return true;
			}

			#endregion
		}

	}
}