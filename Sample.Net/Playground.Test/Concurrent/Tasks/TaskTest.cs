using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Playground.Test.Concurrent.Tasks
{
    public class TaskTest
    {
        [Fact]
        public async Task TestWhenAll()
        {
            List<Task<int>> ret = new List<Task<int>>();
            for (int i = 0; i < 5; i++)
            {
                var task = Task.Run(() => LongRunMethod());
                ret.Add(task);
            }

            TimeSpan ts = new TimeSpan();

            var result = await Task.WhenAll(ret);
            foreach (var item in result)
            {
                Console.WriteLine($"slept {item} milliseconds.");
            }

            Console.WriteLine($"total {ts.Duration()}");
        }

        private int LongRunMethod()
        {
            Random rand = new Random();
            var randVal = rand.Next(1000);
            Thread.Sleep(randVal);
            Console.WriteLine($"thread: {Thread.CurrentThread.Name}, randval: {randVal}");

            return randVal;
        }
    }
}