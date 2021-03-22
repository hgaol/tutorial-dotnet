// https://docs.microsoft.com/en-us/dotnet/core/extensions/configuration

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Playground.Config.Model;

namespace Playground.Config
{
    public static class JsonConfig
    {
        static TransientFaultHandlingOptions options;

        public static async Task Run(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            // Application code should start here.

            await host.RunAsync();

            Console.WriteLine($"TransientFaultHandlingOptions.Enabled={options.Enabled}");
            Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={options.AutoRetryDelay}");
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();

                    IHostEnvironment env = hostingContext.HostingEnvironment;

                    configuration
                        .AddJsonFile("resources/appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"resources/appsettings.{env.EnvironmentName}.json", true, true);

                    IConfigurationRoot configurationRoot = configuration.Build();

                    options = new();
                    configurationRoot.GetSection(nameof(TransientFaultHandlingOptions))
                        .Bind(options);
                });
    }
}