using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Playground.Config
{
    public class EnvironmentConfig
    {
        public static async Task Run(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            // Application code should start here.

            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration.AddEnvironmentVariables(prefix: "CustomPrefix_");
                    
                    foreach ((string key, string value) in
                        configuration.Build().AsEnumerable().Where(t => t.Value is not null))
                    {
                        Console.WriteLine($"{key}={value}");
                    }
                });
    }
}