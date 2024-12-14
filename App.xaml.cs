using System.Windows;
using GenosStore.Services.Interface;
using GenosStore.Utility.Converters;
using GenosStore.Utility.NinjectModules;
using GenosStore.Utility.NinjectModules.NavigationModules;
using GenosStore.Utility.NinjectModules.ServiceModules;
using GenosStore.View.AppWindows;
using Microsoft.Extensions.Logging;
using Ninject;
using QuestPDF.Infrastructure;

namespace GenosStore {
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application {

		private void App_OnStartup(object sender, StartupEventArgs e) {
			
			QuestPDF.Settings.License = LicenseType.Community;
			
			var kernel = new StandardKernel(
				new CommonServicesModule(),
				new ItemCharacteristicsModule(),
				new ItemSimpleComputerComponentsModule(),
				new ItemsModule(),
				new OrderEntitiesModule(),
				new UserEntitiesModule(),
				new PageUrlResolverModule(),
				new NavigationServicesModule(),
				new ServicesModule(),
				new RepositoriesModule("genos_store")
			);

			IServices services = kernel.Get<IServices>();
			Base64ImageConverter.SetOnce(services.Common.Cache.Images);

			// if (services.Common.Authorization.CreateAdmin("amogus@amogus.net", "p3n1s_Mus1C")) {
			// 	MessageBox.Show("penis music");
			// }
			

			var window = new AuthRegisterWindow(services);
			window.Show();
			
		}
	}
}
