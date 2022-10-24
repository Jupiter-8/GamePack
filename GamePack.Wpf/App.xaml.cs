using GamePack.DataAccess;
using GamePack.Wpf.HostExtensions;
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
                .AddConfiguration();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            AppDbContextFactory contextFactory = _host.Services.GetRequiredService<AppDbContextFactory>();
            using (AppDbContext dbContext = contextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            Window window = new MainWindow();
            window.Show();

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
