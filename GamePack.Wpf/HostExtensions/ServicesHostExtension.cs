using GamePack.Services.Implementations;
using GamePack.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GamePack.Wpf.HostExtensions
{
    public static class ServicesHostExtension
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddTransient<IUserService, UserService>();
            });

            return host;
        }
    }
}
