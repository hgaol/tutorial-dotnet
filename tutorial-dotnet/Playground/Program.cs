using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Playground.Config;
using Playground.DI;
using Playground.Logging;

namespace Playground
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // await JsonConfig.Run(args);
            // await XmlConfig.Run(args);
            // await IniConfig.Run(args);
            // await EnvironmentConfig.Run(args);
            // await CliConfig.Run(args);

            // await OperationDemo.Run(args);

            // LoggingDemo.Run(args);
            ConsoleLogger.Run(args);
        }
    }
}
