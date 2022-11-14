using GamePack.DataAccess;
using GamePack.Wpf.Factories;
using GamePack.Wpf.HostExtensions;
using GamePack.Wpf.Pages;
using GamePack.Wpf.Stores;
using GamePack.Wpf.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace GamePack.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddDbContext()
                .AddConfiguration()
                .AddServices()
                .AddTypeFactory<LoadingPage>()
                .AddTypeFactory<SignInPage>()
                .AddTypeFactory<SignInWithGamepackPage>()
                .AddTypeFactory<PreparingToLaunchStorePage>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            AppDbContext d = _host.Services.GetRequiredService<AppDbContext>();

            AppDbContextFactory contextFactory = _host.Services.GetRequiredService<AppDbContextFactory>();
            using (AppDbContext dbContext = contextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            NavigationStore navigationStore = new NavigationStore();

            navigationStore.CurrentViewModel = new LibraryViewModel(navigationStore);

            MainWindow = new MainWindow(_host.Services.GetRequiredService<IAbstractFactory<LoadingPage>>())
            {
                DataContext = new MainViewModel(navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
