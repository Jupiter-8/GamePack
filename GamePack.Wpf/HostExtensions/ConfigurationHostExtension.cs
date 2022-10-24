﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GamePack.Wpf.HostExtensions
{
    public static class ConfigurationHostExtension
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("appsettings.json");
                c.AddEnvironmentVariables();
            });

            return host;
        }
    }
}
