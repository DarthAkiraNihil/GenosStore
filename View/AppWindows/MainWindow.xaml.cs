﻿using GalaSoft.MvvmLight.Messaging;
using GenosStore.View.Main;
using System;
using System.Windows;
using System.Windows.Input;
using static GenosStore.Utility.AbstractViewModel;

namespace GenosStore.View.AppWindows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

			Messenger.Default.Register<NavigateArgs>(this, (x) => {
				MainFrame.Navigate(new Uri(x.URL, UriKind.Relative));
			});

			MainFrame.Content = new MainPage();
        }

		private void closeButton_Click(object sender, RoutedEventArgs e) {
			Application.Current.Shutdown();
		}

		private void minimizeButton_Click(object sender, RoutedEventArgs e) {
			WindowState = WindowState.Minimized;
		}

		private void OnMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
			if (e.LeftButton == MouseButtonState.Pressed) {
				DragMove();
			}
		}
	}
}