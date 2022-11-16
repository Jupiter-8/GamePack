using GamePack.Wpf.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GamePack.Wpf.HostExtensions
{
    public static class StoresHostExtension
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddSingleton<UserStore>();
            });

            return host;
        }
    }
}
