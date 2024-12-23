﻿using System;
using GalaSoft.MvvmLight.Messaging;
using GenosStore.View.Main;
using System.Windows;
using System.Windows.Input;
using GenosStore.Model.Entity.User;
using GenosStore.Services;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.Navigation;
using GenosStore.ViewModel.AppWindows;
using GenosStore.ViewModel.Main;

namespace GenosStore.View.AppWindows
{
    public partial class MainWindow : Window {
	    
	    private IServices _services;
        public MainWindow(IServices services, User currentUser)
        {
	        _services = services;
            InitializeComponent();

			Messenger.Default.Register<NavigationArgs>(this, (x) => {
				MainFrame.Content = _services.Navigation.PageResolver.Resolve(x);
				WindowTitle.Content = x.Title;
			});
			
			MainFrame.Content = new MainPage { DataContext = new MainPageModel(services, currentUser) };
			WindowTitle.Content = "Главная страница";
			
			MainWindowModel.CloseMain += Close;
        }

		private void closeButton_Click(object sender, RoutedEventArgs e) {
			if (Utilities.SpawnQuestionMessageBox("Внимание! Вы покидаете приложение!", "Вы уверены, что хотите выйти из приложения?")) {
				Application.Current.Shutdown();
			}
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