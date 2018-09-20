using Microsoft.Extensions.Logging;

namespace BackgroundTasksSample.Services.Scoped
{
    #region snippet1

    internal class ScopedProcessingService : IScopedProcessingService
    {
        private readonly ILogger _logger;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger)
        {
            _logger = logger;
        }

        public void DoWork()
        {
            _logger.LogInformation("Scoped Processing Service is working.");
        }
    }
    #endregion
}
