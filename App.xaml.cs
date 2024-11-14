using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommonServiceLocator;
using GenosStore.Services.Interface;
using GenosStore.Utility.NinjectModules;
using GenosStore.View.AppWindows;
using Ninject;

namespace GenosStore {
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application {

		private void App_OnStartup(object sender, StartupEventArgs e) {
			
			var kernel = new StandardKernel(
				new ServicesModule(),
				new RepositoriesModule("genos_store")
			);

			IServices services = kernel.Get<IServices>();

			var window = new AuthRegisterWindow(services);
			window.Show();
			
		}
	}
}
