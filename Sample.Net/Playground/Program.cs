using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using org.apache.zookeeper;
using Playground.Azure;
using Playground.Config;
using Playground.DI;
using Playground.Enum;
using Playground.Identity;
using Playground.Json;
using Playground.Logging;
using Playground.Reflection;
using Playground.zk;

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

            // Azure.Kusto.Kusto.QueryData();

            #endregion

            #region Reflection

            // ReflectionDemo.Run();            

            #endregion

            #region ZK

            // await ZKHelper.Create();
            var ipadress = Dns.GetHostEntry(Dns.GetHostName())
                .AddressList;

            var pattern = "^((25[0-5]|2[0-4]\\d|[01]?\\d\\d?)($|(?!\\.$)\\.)){4}$";
            Regex rgx = new Regex(pattern);

            // var ipp = ipadress.Where(ip => rgx.IsMatch(ip.ToString())).First();
            // var ipp = ipadress.Where(ip => AddressFamily.InterNetwork == ip.AddressFamily).First();
            
            // Console.WriteLine(ipp);

            Console.WriteLine(GetLocalIPv4(NetworkInterfaceType.Ethernet));

            #endregion
        }
        
        public static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
    }
}
