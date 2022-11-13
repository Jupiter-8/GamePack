using GamePack.Wpf.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace GamePack.Wpf.HostExtensions
{
    public static class FactoriesHostExtension
    {
        public static IHostBuilder AddTypeFactory<T>(this IHostBuilder host)
            where T : class
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddTransient<T>();
                services.AddSingleton<Func<T>>(x => () => x.GetRequiredService<T>()!);
                services.AddSingleton<IAbstractFactory<T>, AbstractFactory<T>>();
            });

            return host;
        }
    }
}
