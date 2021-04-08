using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Playground.Logging
{
    public class LoggingWorker : BackgroundService
    {
        private readonly ILogger<LoggingWorker> log;

        public LoggingWorker(ILogger<LoggingWorker> logger)
        {
            this.log = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                log.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}