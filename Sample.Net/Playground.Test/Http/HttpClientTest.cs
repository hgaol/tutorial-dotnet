using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playground.Test.Http
{
    [TestClass]
    public class HttpClientTest
    {
        private HttpClient client;

        private string[] uris = new[] { "https://example.com", "https://www.baidu.com", "https://localhost:5001/test/hello" };

        [TestInitialize]
        public void init()
        {
            client = new HttpClient();
        }

        [TestMethod]
        public async Task HttpInstanceTest()
        {
            List<Task<HttpResponseMessage>> rets = new List<Task<HttpResponseMessage>>();
            for (int i = 0; i < uris.Length; i++)
            {
                var i1 = i;
                var task = Task.Run(async () => await client.GetAsync(uris[i1]));
                rets.Add(task);
            }

            var list = await Task.WhenAll(rets);
            foreach (var httpResponseMessage in list)
            {
                Console.WriteLine(httpResponseMessage.StatusCode + httpResponseMessage.ToString());
            }
        }
    }
}