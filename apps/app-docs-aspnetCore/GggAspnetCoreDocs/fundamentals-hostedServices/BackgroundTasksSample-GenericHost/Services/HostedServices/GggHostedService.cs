using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTasksSample.Services.HostedServices
{
    public class GggHostedService : IHostedService
    {
        private readonly ILogger _logger;

        public GggHostedService(ILogger<GggHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "GggHostedService is starting.");
            DoWork();
            return Task.CompletedTask;
        }

        private void DoWork()
        {
            _logger.LogInformation(
                "GggHostedService is working.");

            void Callback(object state)
            {
                try
                {
                    _logger.LogInformation("GggHostedService Callback: " + state + " " + DateTime.Now.ToString("R"));
                }
                catch (Exception e)
                {
                    _logger.LogInformation("GggHostedService Callback exception: ");
                    _logger.LogError(e.Message);
                }
            }

            Timer timer = new Timer(Callback, "started", 0, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            _logger.LogInformation("GggHostedService Timer started: " + timer);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "GggHostedService is stopping.");

            return Task.CompletedTask;
        }
    }
}