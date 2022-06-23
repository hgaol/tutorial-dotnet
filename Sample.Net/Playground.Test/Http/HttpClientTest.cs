using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Playground.Test.Http
{
    public class HttpClientTest
    {
        private HttpClient client;

        private string[] uris = new[] { "https://example.com", "https://www.baidu.com" };

        public void init()
        {
            client = new HttpClient();
        }

        // [Fact]
        public async Task HttpInstanceTest()
        {
            init();
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