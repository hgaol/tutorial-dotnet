using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Playground.Azure;
using Playground.Config;
using Playground.DI;
using Playground.Enum;
using Playground.Identity;
using Playground.Json;
using Playground.Logging;
using Playground.Reflection;

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

            // ConfigUtils.Run();

            // await OperationDemo.Run(args);

            // LoggingDemo.Run(args);
            // ConsoleLogger.Run(args);

            // ClientCredentialFlow.Run();

            // Json
            // JObjectDemo.Run();

            // enums
            // EnumDemo.Run();

            #region Kusto

            Azure.Kusto.Kusto.QueryData();

            #endregion

            #region Reflection

            // ReflectionDemo.Run();            

            #endregion
        }
    }
}
