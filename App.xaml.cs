using System.Windows;
using System.Windows.Threading;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.Converters;
using GenosStore.Utility.NinjectModules;
using GenosStore.Utility.NinjectModules.NavigationModules;
using GenosStore.Utility.NinjectModules.ServiceModules;
using GenosStore.View.AppWindows;
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
			
			var window = new AuthRegisterWindow(services);
			window.Show();
			
		}
		
		void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
			Utilities.SpawnErrorMessageBox("Something went wrong", 
			    $"Возникла ошибка в работе приложения:\n\n{e.Exception.Message}\n\nДальнейшая работа приложения может быть нестабильной. Возможно, причина в проводимых технических работах. Рекомендуем связаться с разработчиками системы.");
			e.Handled = true;
		}
	}
}
