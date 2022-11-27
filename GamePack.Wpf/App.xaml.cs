using GamePack.DataAccess;
using GamePack.Wpf.Factories;
using GamePack.Wpf.HostExtensions;
using GamePack.Wpf.Pages;
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
                .AddStores()
                .AddTypeFactory<LoadingPage>()
                .AddTypeFactory<SignInPage>()
                .AddTypeFactory<SignInWithGamepackPage>()
                .AddTypeFactory<PreparingToLaunchStorePage>()
                .AddTypeFactory<SignUpPage>()
                .AddTypeFactory<HomePage>()
                .AddTypeFactory<ProfilePage>()
                .AddTypeFactory<MainPage>()
                .AddTypeFactory<SettingsPage>()
                .AddTypeFactory<LibraryPage>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            AppDbContextFactory contextFactory = _host.Services.GetRequiredService<AppDbContextFactory>();
            using (AppDbContext dbContext = contextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            MainWindow = new MainWindow(_host.Services.GetRequiredService<IAbstractFactory<LoadingPage>>());
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
