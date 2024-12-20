using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.Navigation;
using GenosStore.View.Admin;
using GenosStore.View.Main;
using GenosStore.ViewModel.Admin;
using GenosStore.ViewModel.Main;

namespace GenosStore.View.AppWindows {
    public partial class AdminMainWindow : Window {
        private IServices _services;
        
        public AdminMainWindow(IServices services, User currentUser) {
            _services = services;
            InitializeComponent();

            Messenger.Default.Register<NavigationArgs>(this, (x) => {
                MainFrame.Content = _services.Navigation.PageResolver.Resolve(x);
                WindowTitle.Content = x.Title;
            });
			
            MainFrame.Content = new DashboardPage { DataContext = new DashboardPageModel(services, currentUser) };
            WindowTitle.Content = "Главная страница";
        }
        
        private void closeButton_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }

        private void maximizeButton_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                DragMove();
            }
        }
    }
}