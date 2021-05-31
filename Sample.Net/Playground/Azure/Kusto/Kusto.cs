using System;
using System.Collections.Generic;
using Kusto.Cloud.Platform.Data;
using Kusto.Data;
using Kusto.Data.Common;
using Kusto.Data.Net.Client;
using Playground.Config;

namespace Playground.Azure.Kusto
{
    public class Kusto
    {
        public static void QueryData()
        {
            var config = ConfigUtils.ReadFromJsonFile<KustoOptions>("./resources/secret.kusto.json");

            var kcsb = new KustoConnectionStringBuilder(config.Cluster, config.Database)
                .WithAadApplicationKeyAuthentication(config.ApplicationId, config.ApplicationSecret, config.TenantId);

            try
            {
                using (var client = KustoClientFactory.CreateCslQueryProvider(kcsb))
                {
                    // var objectReader = new ObjectReader<IdAndLevel>(client.ExecuteQuery(config.ServiceTreeQuery));
                    // var list = objectReader.ToList();
                    var list = client.QueryList<TwoString>(config.ServiceTreeQuery);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"command execute failed : {ex}");
            }
        }

        public class TwoString
        {
            public string Id { get; set; }
            public string Level { get; set; }
        }

        public class KustoOptions
        {
            public string TenantId { get; set; }
            public string ApplicationId { get; set; }
            public string ApplicationSecret { get; set; }
            public string Cluster { get; set; }
            public string Database { get; set; }
            public string ServiceTreeQuery { get; set; }
        }
    }
}