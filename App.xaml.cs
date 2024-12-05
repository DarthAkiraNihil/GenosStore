using System.Windows;
using GenosStore.Services.Interface;
using GenosStore.Utility.Converters;
using GenosStore.Utility.NinjectModules;
using GenosStore.Utility.NinjectModules.ServiceModules;
using GenosStore.View.AppWindows;
using Ninject;

namespace GenosStore {
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application {

		private void App_OnStartup(object sender, StartupEventArgs e) {
			
			var kernel = new StandardKernel(
				new CommonServicesModule(),
				new ItemCharacteristicsModule(),
				new ItemSimpleComputerComponentsModule(),
				new ItemsModule(),
				new OrderEntitiesModule(),
				new UserEntitiesModule(),
				new ServicesModule(),
				new RepositoriesModule("genos_store")
			);

			IServices services = kernel.Get<IServices>();
			Base64ImageConverter.SetOnce(services.Common.Cache.Images);

			var window = new AuthRegisterWindow(services);
			window.Show();
			
		}
	}
}
