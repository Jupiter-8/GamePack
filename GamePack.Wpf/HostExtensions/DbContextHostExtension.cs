using GamePack.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace GamePack.Wpf.HostExtensions
{
    public static class DbContextHostExtension
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("sqlite");
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);

                services.AddDbContext<AppDbContext>(configureDbContext);
                services.AddSingleton(new AppDbContextFactory(configureDbContext));

                services.AddScoped(sp =>
                {
                    var dbContextFactory = sp.GetRequiredService<AppDbContextFactory>();
                    return dbContextFactory.CreateDbContext();
                });
            });

            return host;
        }
    }
}
